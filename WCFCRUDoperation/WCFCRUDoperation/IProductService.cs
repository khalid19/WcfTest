using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFCRUDoperation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "FindAll", ResponseFormat = WebMessageFormat.Json)]
        List<Product> FindAll();
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "FindAll/{id}", ResponseFormat = WebMessageFormat.Json)]
        Product Find(string id);
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Create", ResponseFormat = WebMessageFormat.Json,RequestFormat = WebMessageFormat.Json)]
        bool Create(Product product);
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Edit", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool Edit(Product product);
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Delete", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool Delete(Product product);
    }
}
