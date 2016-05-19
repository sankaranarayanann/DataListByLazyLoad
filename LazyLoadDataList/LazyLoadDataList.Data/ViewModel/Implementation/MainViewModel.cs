using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LazyLoadDataList.Service;
using LazyLoadDataList.Data.Model;
using System.Threading.Tasks;
using LazyLoadDataList.Data.ViewModel.Contract;

namespace LazyLoadDataList.Data.ViewModel.Implementation
{
    /// <summary>
    /// Implement class for IMainViewModel
    /// </summary>
    public class MainViewModel : IMainViewModel
    {
        #region Private variables

        Activity _activity;

        #endregion

        #region Constructor

        public MainViewModel(Activity activity)
        {
            _activity = activity;
        }

        #endregion

        #region Interface implementation

        /// <summary>
        /// Method to get json data
        /// </summary>
        /// <returns></returns>
        public async Task<Facts> GetJsonData()
        {
            return await ServiceHelper.Instance.DownloadWebClientData<Facts>(AppConstant.WebRequestURL); ;
        }

        #endregion

    }
}