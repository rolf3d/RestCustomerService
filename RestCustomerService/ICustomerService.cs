using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestCustomerService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICustomerService" in both code and config file together.
    [ServiceContract]
    public interface ICustomerService
    {

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "customers/")]
        IList<Customer> GetCustomers();

        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "customers/{id}")]
        Customer GetCustomersFromId(string id);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "customers/{id}")]
        Customer DeleteCustomer(string id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
        BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "customers/")]
        Customer PostCustomer(Customer c);

        [OperationContract]
        [WebInvoke(Method = "PUT",
            ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "customers/{id}")]
        Customer PutCustomer(string id, Customer c);
    }



}
