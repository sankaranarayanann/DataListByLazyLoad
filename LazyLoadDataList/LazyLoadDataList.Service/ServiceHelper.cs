using Android.Graphics;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace LazyLoadDataList.Service
{
    /// <summary>
    /// Singlton helper class for service calls
    /// </summary>
    public class ServiceHelper
    {
        #region private variables

        private static readonly object padlock = new object();
        private static ServiceHelper instance = null;

        #endregion

        #region Private Constructor

        private ServiceHelper()
        {

        }

        #endregion

        #region Public Property

        /// <summary>
        /// Singleton instance for ServiceHelper
        /// </summary>
        public static ServiceHelper Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ServiceHelper();
                    }
                    return instance;
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method gets the Url and try to download the data 
        /// in the given url.
        /// Exception will throw if url is null or empty and any connection error happens
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<T> DownloadWebClientData<T>(string url)
        {
            if (string.IsNullOrEmpty(url))
                throw new Exception("URL should not be empty");

            try
            {
                using (WebClient client = new WebClient())
                {
                    Stream data = client.OpenRead(url);
                    StreamReader reader = new StreamReader(data);
                    var jsonData = await reader.ReadToEndAsync();
                    data.Close();
                    return JsonConvert.DeserializeObject<T>(jsonData);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion
    }
}
