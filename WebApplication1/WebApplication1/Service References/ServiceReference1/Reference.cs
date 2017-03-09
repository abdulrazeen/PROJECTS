﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/validate_login", ReplyAction="http://tempuri.org/IService1/validate_loginResponse")]
        string validate_login(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/validate_login", ReplyAction="http://tempuri.org/IService1/validate_loginResponse")]
        System.Threading.Tasks.Task<string> validate_loginAsync(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/insert_user", ReplyAction="http://tempuri.org/IService1/insert_userResponse")]
        string insert_user(string first_name, string last_name, string mobile_no, string email, string password, string gender, string dob, string image);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/insert_user", ReplyAction="http://tempuri.org/IService1/insert_userResponse")]
        System.Threading.Tasks.Task<string> insert_userAsync(string first_name, string last_name, string mobile_no, string email, string password, string gender, string dob, string image);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/sendmail", ReplyAction="http://tempuri.org/IService1/sendmailResponse")]
        string sendmail();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/sendmail", ReplyAction="http://tempuri.org/IService1/sendmailResponse")]
        System.Threading.Tasks.Task<string> sendmailAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : WebApplication1.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<WebApplication1.ServiceReference1.IService1>, WebApplication1.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string validate_login(string username, string password) {
            return base.Channel.validate_login(username, password);
        }
        
        public System.Threading.Tasks.Task<string> validate_loginAsync(string username, string password) {
            return base.Channel.validate_loginAsync(username, password);
        }
        
        public string insert_user(string first_name, string last_name, string mobile_no, string email, string password, string gender, string dob, string image) {
            return base.Channel.insert_user(first_name, last_name, mobile_no, email, password, gender, dob, image);
        }
        
        public System.Threading.Tasks.Task<string> insert_userAsync(string first_name, string last_name, string mobile_no, string email, string password, string gender, string dob, string image) {
            return base.Channel.insert_userAsync(first_name, last_name, mobile_no, email, password, gender, dob, image);
        }
        
        public string sendmail() {
            return base.Channel.sendmail();
        }
        
        public System.Threading.Tasks.Task<string> sendmailAsync() {
            return base.Channel.sendmailAsync();
        }
    }
}
