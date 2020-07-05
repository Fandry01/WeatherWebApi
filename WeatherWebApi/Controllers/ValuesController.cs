using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using System.Xml.Linq;

namespace WeatherWebApi.Controllers
{
    
    public class ValuesController : ApiController
    {
        
        public string Get(string Lat,string Lon)
        {
            
            try
            {

                string URLString = "https://data.buienradar.nl/1.0/feed/xml";
                DataSet ds = new DataSet();
                ds.ReadXml(URLString);
                DataRow[] foundRows;
                foundRows = ds.Tables["weerstation"].Select("lat='" + Lat + "' and lon='" + Lon + "'");
                var temp = foundRows[0].ItemArray[6];
                return temp.ToString(); 
            }

            catch (Exception ex)
            {
                return "Error";
            }
            

        }

        
    }
}
