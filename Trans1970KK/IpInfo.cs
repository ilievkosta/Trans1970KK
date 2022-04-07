using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Trans1970KK
{
    public class IpInfo
    {
        [JsonProperty("ip")]
        public string Ip { get; set; }


        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("region_name")]
        public string Region { get; set; }

        [JsonProperty("country_name")]
        public string Country { get; set; }

        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }


        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        public IpInfo GetUserLocationDetailsyByIp(string ip)
        {
            var ipInfo = new IpInfo();
            try
            {
                var info = new WebClient().DownloadString("http://freegeoip.net/json/" + ip);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
            }
            catch (Exception ex)
            {
                //Exception Handling
            }

            return ipInfo;
        }

    }
}
