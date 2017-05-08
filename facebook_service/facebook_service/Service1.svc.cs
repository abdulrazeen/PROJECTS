using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using facebook_service;




namespace facebook_service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        DataTable dtb = new DataTable();
        public string DataTableToJSONWithJSONNet(DataTable table)
        {
            return JsonConvert.SerializeObject(table);
        }
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        public string validate_login(string username, string password)
        {
            string conString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Select *from SIGN_UP where EMAIL='" + username + "' and PASSWORD='" + password + "'", connection);
                    SqlDataReader dr = cmd.ExecuteReader();
                   
                    dtb.Load(dr);
                    //string a = JsonConvert.SerializeObject(dtb);
                    connection.Close();
                    if (dtb.Rows.Count >= 1)
                    {
                        dtb.Columns.Add("ResponseCode", typeof(System.Int32));
                        dtb.Columns["ResponseCode"].Expression = "'200'";
                        dtb.Columns.Add("Msg", typeof(System.String));
                        dtb.Columns["Msg"].Expression = "'Login Succesful'";
                        string a = DataTableToJSONWithJSONNet(dtb);
                        return a;
                    }
                    else
                    {
                        dtb = CheckEmailExist(username, password);
                        if (dtb.Rows.Count >= 1)
                        {
                            dtb.Columns.Add("ResponseCode", typeof(System.Int32));
                            dtb.Columns["ResponseCode"].Expression = "'500'";
                            dtb.Columns.Add("Msg", typeof(System.String));
                            dtb.Columns["Msg"].Expression = "'password Incorrect,Login failed'";
                            string a = DataTableToJSONWithJSONNet(dtb);
                            return a;
                        }
                        else
                        {
                            dtb.Columns.Add("ResponseCode", typeof(System.Int32));
                            dtb.Columns["ResponseCode"].Expression = "'404'";
                            dtb.Columns.Add("Msg", typeof(System.String));
                            dtb.Columns["Msg"].Expression = "'Email doesnt exist,Login failed'";
                            string a = DataTableToJSONWithJSONNet(dtb);
                            string b = "[{\"ResponseCode\":404,\"Msg\"" + ":\"Email doesnt exist,Login failed \"}]";
                            return b;
                        }
                    }
                }
            }




            catch (Exception ex)
            {

                return ex.ToString();

                //return "error"+ex;
            }
            finally
            {
                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }




        public string insert_user(string first_name, string last_name, string mobile_no, string email, string password, string gender, string dob, string image)
        {
               // <add name="conn" providerName="System.Data.SqlClient" connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=facebook;Integrated Security=True;MultipleActiveResultSets=True"/>
            //SqlConnection con = new SqlConnection("Data Source=RAZEEN-PC\\SQLEXPRESS;Initial Catalog=facebook;Integrated Security=True;MultipleActiveResultSets=True");
            string conString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            try
            {
                using (connection)
                {
                    //SqlConnection con = new SqlConnection("Data Source=RAZEEN-PC\\SQLEXPRESS;Initial Catalog=facebook;Integrated Security=True;MultipleActiveResultSets=True");
                    connection.Open();
                    //FileUpload FL1 = new FileUpload();
                    //String myprofpic = "C://Users//Abdul Razeen//documents//visual studio 2012//Projects//MvcApplication2//MvcApplication2//Images" + image;
                    //FL1.SaveAs(myprofpic);
                    SqlCommand cmd = new SqlCommand("insert into SIGN_UP(FIRST_NAME,LAST_NAME,MOBILE_NO,EMAIL,PASSWORD,GENDER,DOB,image) VALUES('" + first_name + "','" + last_name + "','" + mobile_no + "','" + email + "','" + password + "','" + gender + "','" + dob + "','" + image + "')", connection);

                                     
                // SqlDataReader dr = cmd.ExecuteReader();
                     //SqlCommand snd = new SqlCommand(cmd,con);
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                   {


                      //sendmail();



                       return ("success");
                   }
                   else
                    {
                       return ("fail");
                   }
                    //connection.Close();
                    //cmd.Dispose();
                    //return null;
                    //connection.Close();
                
                    

        
                   //return "insert into SIGN_UP(FIRST_NAME,LAST_NAME,MOBILE_NO,EMAIL,PASSWORD,GENDER,DOB,image) VALUES('" + first_name + "','" + last_name + "','" + mobile_no + "','" + email + "','" + password + "','" + gender + "','" + dob + "','" + image + "')";
                  // return "success";
                   connection.Close();
                }
            }
            catch (Exception ex)
            {
                return "error" + ex;
            }
                    
        }
        public string send_request(string user_one, string user_two,string action_user)
        {
             string conString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            try
            {
                using (connection)
                {
                    connection.Open();

                   
                    SqlCommand cmd = new SqlCommand("INSERT INTO relationship (user_one_id,user_two_id,status,action_user_id) VALUES('" + user_one + "','" + user_two + "',0,'" + action_user + "')", connection);

                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        return ("success");
                    }
                    else
                    {
                        return ("fail");
                    }
                   
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                return "error" + ex;
            }

        }
        public string show_request(string user_one)
        {
            string conString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            try
            {
                using (connection)
                {
                    connection.Open();


                    SqlCommand cmd = new SqlCommand("select first_name,last_name,id,image from sign_up join relationship on user_two_id ='" + user_one + "' and status=0 where sign_up.id=relationship.user_one_id", connection);

                    SqlDataReader dr = cmd.ExecuteReader();

                    dtb.Load(dr);

                    connection.Close();

                    if (dtb.Rows.Count >= 1)
                    {
                        dtb.Columns.Add("ResponseCode", typeof(System.Int32));
                        dtb.Columns["ResponseCode"].Expression = "'200'";
                        dtb.Columns.Add("Status", typeof(System.String));
                        dtb.Columns["Status"].Expression = "'Success'";
                        string a = DataTableToJSONWithJSONNet(dtb);
                        return a;
                    }
                    else
                    {

                        dtb.Columns.Add("ResponseCode", typeof(System.Int32));
                        dtb.Columns["ResponseCode"].Expression = "'403'";
                        dtb.Columns.Add("Status", typeof(System.String));
                        dtb.Columns["Status"].Expression = "'Name doesnt exist'";
                        string a = DataTableToJSONWithJSONNet(dtb);
                        string b = "[{\"ResponseCode\":403,\"Msg\"" + ":\"Name doesnt exist\"}]";
                        return b;

                    }



                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
                //return "error" + ex;
            }
            finally
            {
                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }
        public string accept_request(string user_one, string user_two,string action_user)
        {
            string conString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            try
            {
                using (connection)
                {
                    connection.Open();


                    SqlCommand cmd = new SqlCommand(" UPDATE relationship SET status = 1,action_user_id= '" + action_user + "'  WHERE user_one_id ='" + user_two + "' AND user_two_id = '" + user_one + "' or user_one_id = '" + user_one + "' AND user_two_id ='" + user_two + "'", connection);
                 

                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        return ("success");
                    }
                    else
                    {
                        return ("fail");
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                return "error" + ex;
            }

        }
        public string unfriend(string user_one, string user_two, string action_user)
        {
            string conString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            try
            {
                using (connection)
                {
                    connection.Open();



                    SqlCommand cmd = new SqlCommand(" UPDATE relationship SET status = 2,action_user_id= '" + action_user + "' WHERE (user_one_id ='" + user_one + "' or user_two_id = '" + user_one + "')", connection);

                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        return ("success");
                    }
                    else
                    {
                        return ("fail");
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                return "error" + ex;
            }

        }
        public string friendship(string user_one)
        {
            string conString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    //select first_name,last_name,id,image from sign_up join relationship on (user_one_id=87 or user_two_id=87) and status=1 and id!=87 where sign_up.id=relationship.user_one_id  or sign_up.id=relationship.user_two_id 
                    SqlCommand cmd = new SqlCommand("select first_name,last_name,id,image from sign_up join relationship on (user_one_id='" + user_one + "' or user_two_id='" + user_one + "') and status=1 and id!='" + user_one + "' where (sign_up.id=relationship.user_one_id  or sign_up.id=relationship.user_two_id) ", connection);
                    //cmd = new SqlCommand("select first_name,last_name,id,image from sign_up join relationship on action_user_id='" + user_one + "' and user_one_id!='" + user_one + "' and status=1 where sign_up.id=relationship.user_one_id", connection);

                    SqlDataReader dr = cmd.ExecuteReader();

                    dtb.Load(dr);

                    connection.Close();

                    if (dtb.Rows.Count >= 1)
                    {
                        dtb.Columns.Add("ResponseCode", typeof(System.Int32));
                        dtb.Columns["ResponseCode"].Expression = "'200'";
                        dtb.Columns.Add("Status", typeof(System.String));
                        dtb.Columns["Status"].Expression = "'Success'";
                        string a = DataTableToJSONWithJSONNet(dtb);
                        return a;
                    }
                    else
                    {

                        dtb.Columns.Add("ResponseCode", typeof(System.Int32));
                        dtb.Columns["ResponseCode"].Expression = "'403'";
                        dtb.Columns.Add("Status", typeof(System.String));
                        dtb.Columns["Status"].Expression = "'Name doesnt exist'";
                        string a = DataTableToJSONWithJSONNet(dtb);
                        string b = "[{\"ResponseCode\":403,\"Msg\"" + ":\"Name doesnt exist\"}]";
                        return b;

                    }



                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
                //return "error" + ex;
            }
            finally
            {
                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }
        public string search(string first_name, string last_name,string image)
        {
            // <add name="conn" providerName="System.Data.SqlClient" connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=facebook;Integrated Security=True;MultipleActiveResultSets=True"/>
            //SqlConnection con = new SqlConnection("Data Source=RAZEEN-PC\\SQLEXPRESS;Initial Catalog=facebook;Integrated Security=True;MultipleActiveResultSets=True");
            string conString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(conString);
            try
            {
                using (connection)
                {
                    //SqlConnection con = new SqlConnection("Data Source=RAZEEN-PC\\SQLEXPRESS;Initial Catalog=facebook;Integrated Security=True;MultipleActiveResultSets=True");
                    connection.Open();
                    //FileUpload FL1 = new FileUpload();
                    //String myprofpic = "C://Users//Abdul Razeen//documents//visual studio 2012//Projects//MvcApplication2//MvcApplication2//Images" + image;
                    //FL1.SaveAs(myprofpic);
                   
                    //SqlCommand cmd = new SqlCommand("Select first_name from SIGN_UP where FIRST_NAME like '%a' ", connection);

                    SqlCommand cmd = new SqlCommand("Select id,first_name,image from SIGN_UP where FIRST_NAME like'" + first_name + "%'", connection); //EMAIL='" + username + "'  
                    //SqlCommand cmd = new SqlCommand("Select first_name from SIGN_UP where FIRST_NAME like'a%'", connection); 
                    SqlDataReader dr = cmd.ExecuteReader();

                    dtb.Load(dr);
                   
                    connection.Close();

                    if (dtb.Rows.Count >= 1)
                    {
                        dtb.Columns.Add("ResponseCode", typeof(System.Int32));
                        dtb.Columns["ResponseCode"].Expression = "'200'";
                        dtb.Columns.Add("Status", typeof(System.String));
                        dtb.Columns["Status"].Expression = "'Success'";
                        string a = DataTableToJSONWithJSONNet(dtb);
                        return a;
                    }
                    else
                    {
                        
                            dtb.Columns.Add("ResponseCode", typeof(System.Int32));
                            dtb.Columns["ResponseCode"].Expression = "'403'";
                            dtb.Columns.Add("Status", typeof(System.String));
                            dtb.Columns["Status"].Expression = "'Name doesnt exist'";
                            string a = DataTableToJSONWithJSONNet(dtb);
                            string b = "[{\"ResponseCode\":403,\"Msg\"" + ":\"Name doesnt exist\"}]";
                            return b;
                       
                    }


                    
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
                //return "error" + ex;
            }
            finally
            {
                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }

        }

        //public string sendmail()
        //{



            //string mail = Frommail.Text;
            // string fun = Tomail.Text;
            //string sub = Subjectmail.Text;
            // string bdy = documail.Text;


            //MailMessage msg = new MailMessage();
           
            //msg.From = new MailAddress("abdulrazeen81@gmail.com");
            //msg.To.Add("nihaljbn@gmail.com");
            ////msg.Subject = sub;
            //// msg.Body = bdy;
            //msg.IsBodyHtml = true;

            //SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.gmail.com";
            //smtp.Credentials = new NetworkCredential("abdulrazeen81@gmail.com", "abdul");
            //smtp.EnableSsl = true;


        //    MailMessage mm = new MailMessage();
        //      mm.To.Add("abdulrazeen81@gmail.com");
        //      mm.From = new MailAddress("09a6e27c486b63");
        //      mm.Body = "hello world";
        //      mm.IsBodyHtml = true;
        //      mm.Subject = "Verification";
        //      SmtpClient smcl = new SmtpClient();
        //      smcl.Host = "smtp.mailtrap.io";
        //      smcl.Port = 2525;
        //      smcl.Credentials = new NetworkCredential("09a6e27c486b63", "a7914998b170bb");
        //      smcl.EnableSsl = true;
        //      smcl.Send(mm);




        //    try
        //    {
        //        //smtp.Send(msg);
        //        return "success";
        //    }




        //    catch (Exception ex)
        //    {
        //        return "error"+ex;
        //    }
        //}

        public string sendmail(string email)
        {
            var client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("09a6e27c486b63", "a7914998b170bb"),
                EnableSsl = true
            };
            client.Send("abc@gmail.com",email, "Hello world", "testbody");
            Console.WriteLine("Sent");
            Console.ReadLine();
             try
             {
                 //smtp.Send(msg);
                 return "success";
             }




             catch (Exception ex)
             {
                 return "error" + ex;
             }
        }

        public DataTable CheckEmailExist(string username, string password)
        {
            string connString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            SqlConnection connection = new SqlConnection(connString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("select * from sign_up where email='" + username + "'", connection);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dtb = new DataTable();
                    dtb.Load(dr);
                    connection.Close();
                    return dtb;
                }
            }
            catch (Exception ex)
            {

                return null;

                //return "error"+ex;
            }
            finally
            {
                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}


        
   

        
    

