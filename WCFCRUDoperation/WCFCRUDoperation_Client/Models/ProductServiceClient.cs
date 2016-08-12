using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace WCFCRUDoperation_Client.Models
{
    public class ProductServiceClient
    {
        private string Base_URL = "http://localhost:2588/ProductService.svc/";


        public List<Product> FindAll()
        {

            try
            {
                var webClient = new WebClient();
                var json = webClient.DownloadString(Base_URL + "FindAll");
                var js = new JavaScriptSerializer();
                return js.Deserialize<List<Product>>(json);
            }
            catch
            {

                return null;
            }
        }

        public Product Find(string id)
        {

            try
            {
                var webClient = new WebClient();
                string url = string.Format(Base_URL + "FindAll/{0}", id);
                //var json = webClient.DownloadString(Base_URL + "FindAll{0}",id);
                var json = webClient.DownloadString(url);
                var js = new JavaScriptSerializer();
                return js.Deserialize<Product>(json);
            }
            catch
            {

                return null;
            }
        }

        public bool Create(Product product)
        {

            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof (Product));
                MemoryStream mem = new MemoryStream();

                ser.WriteObject(mem, product);

                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int) mem.Length);

                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadString(Base_URL + "Create", "POST", data);

                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool Edit(Product product)
        {

            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof (Product));
                MemoryStream mem = new MemoryStream();

                ser.WriteObject(mem, product);

                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int) mem.Length);

                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadString(Base_URL + "Edit", "PUT", data);

                return true;
            }
            catch
            {

                return false;
            }
        }

        public bool Delete(Product product)
        {

            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof (Product));
                MemoryStream mem = new MemoryStream();

                ser.WriteObject(mem, product);

                string data = Encoding.UTF8.GetString(mem.ToArray(), 0, (int) mem.Length);

                WebClient webClient = new WebClient();
                webClient.Headers["Content-type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                webClient.UploadString(Base_URL + "Delete", "DELETE", data);

                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}