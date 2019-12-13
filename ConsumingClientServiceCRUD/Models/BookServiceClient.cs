using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace ConsumingClientServiceCRUD.Models
{
    public class BookServiceClient
    {
    string BASE_URL = "http://localhost:60603/BookServices.svc";

        public List<Book> getAllBooks()
        {
            var syncClient = new WebClient();
            var content = syncClient.DownloadString(BASE_URL + "/Book");
            var json_serializer = new JavaScriptSerializer();
            return json_serializer.Deserialize<List<Book>>(content);
        }
    }
}