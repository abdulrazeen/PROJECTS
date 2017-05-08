using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace facebook_service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string validate_login(string username,string password);
         [OperationContract]
        string insert_user(string first_name,string last_name,string mobile_no,string email,string password ,string gender,string dob,string image);

        [OperationContract]
          string sendmail(string email);

        [OperationContract]
        string search(string first_name, string last_name,string image);

        [OperationContract]
        string send_request(string user_one, string user_two,string action_user);

        [OperationContract]
        string accept_request(string user_one, string user_two, string action_user);

        [OperationContract]
        string show_request(string user_one);

        [OperationContract]
        string friendship(string user_one);

        [OperationContract]
        string unfriend(string user_one, string user_two, string action_user);


        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    
}
