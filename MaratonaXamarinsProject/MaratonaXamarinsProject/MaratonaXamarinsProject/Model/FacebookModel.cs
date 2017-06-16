using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaratonaXamarinsProject.Model
{
    public class FacebookModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        public string Access_token { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Picture Picture { get; set; }

    }
    public class Picture
    {
        /// <summary>
        /// 
        /// </summary>
        public Data Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        
    }
    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public bool Is_silhouette { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; }
    }
}
