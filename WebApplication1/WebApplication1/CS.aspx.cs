using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;



  //public class Service1 : IService1
  //  {
  //      DataTable dtb = new DataTable();
namespace WebApplication1
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterUser(object sender, EventArgs e)
        {
            int userId = 0;
            
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Insert_User"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                        cmd.Connection = con;
                        con.Open();
                        userId = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
                string message = string.Empty;
                switch (userId)
                {
                    case -1:
                        message = "Username already exists.\\nPlease choose a different username.";
                        break;
                    case -2:
                        message = "Supplied email address has already been used.";
                        break;
                    default:
                        message = "Registration successful. Activation Email has been sent.";
                        SendActivationEmail(userId);
                        break;
                }
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
            }
        }

        private void SendActivationEmail(int userId)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            string activationCode = Guid.NewGuid().ToString();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO UserActivation VALUES(@UserId, @ActivationCode)"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@UserId", userId);
                        cmd.Parameters.AddWithValue("@ActivationCode", activationCode);
                        cmd.Connection = con;
                        DataSet ds = new DataSet();
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            using (MailMessage mm = new MailMessage("sender@gmail.com", txtEmail.Text))
            {
                mm.Subject = "Account Activation";
                string body = "Hello " + txtUsername.Text.Trim() + ",";
                body += "<br /><br />Please click the following link to activate your account";
                body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("CS.aspx", "CS_Activation.aspx?ActivationCode=" + activationCode) + "'>Click here to activate your account.</a>";
                body += "<br /><br />Thanks";
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("sender@gmail.com", "<password>");
               
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
               // smtp.Send(mm);
                DataSet ds = new DataSet();
                //var pass = ds.Tables[1].Rows[1][1].ToString();


                 string pass = Convert.ToString(ds.Tables[1].Rows[1]["Email"]);
                 System.Net.Mail.MailMessage Msg = new System.Net.Mail.MailMessage();
                Msg.Subject = "MAC | Password Recovery";
                Msg.From = new MailAddress("gy@gmail.com", "support");
                Msg.To.Add(txtEmail.Text.Trim());
                Msg.Body = "Your Password is " + pass + " <br/> Sent by the Administrator.<br/><br/> <br/><br/> Thanks, <br/><br/>Site Admin <br/> MAC";
                Msg.IsBodyHtml = true;
                
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential("gy@gmail.com", "mac");
                smtp.Send(Msg);
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Your password send to your email id');", true);
            }

                //string pass = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                ////int value = 0;
                //System.Net.Mail.MailMessage Msg = new System.Net.Mail.MailMessage();
                //Msg.Subject = "MAC | Password Recovery";
               
                //Msg.To.Add(txtEmail.Text.Trim());
                //Msg.Body = "Your Password is " + pass + " <br/> Sent by the Administrator.<br/><br/> <br/><br/> Thanks, <br/><br/>Site Admin <br/> MAC";
                //Msg.IsBodyHtml = true;

                //smtp.Host = "smtp.gmail.com";
                //smtp.Port = 587;
                //smtp.EnableSsl = true;
                //smtp.Credentials = new System.Net.NetworkCredential("gy@gmail.com", "mac");
                //smtp.Send(Msg);
                //System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Your password send to your email id');", true);
            //}
            //else
            //{
            //    System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('This email id does not exists!');", true);
            //}
           
        
            
        }
    }
}