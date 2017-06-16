using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonaXamarinsProject.Model
{

    public class FacebookTokenModel
    {
        public string access_token { get; set; }
        public DateTime expires_on { get; set; }
        public string provider_name { get; set; }
        public User_Claims[] user_claims { get; set; }
        public string user_id { get; set; }
    }

    public class User_Claims
    {
        public string typ { get; set; }
        public string val { get; set; }
    }
    
}
