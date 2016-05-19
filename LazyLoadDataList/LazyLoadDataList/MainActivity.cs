using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using LazyLoadDataList.Service;
using LazyLoadDataList.Adapter;
using LazyLoadDataList.Data.ViewModel.Contract;
using LazyLoadDataList.Data.ViewModel.Implementation;

namespace LazyLoadDataList
{
    [Activity(Label = "DataList by Lazy load", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        #region Private Varialbles

        AlertDialogHelper alertDialog;
        IMainViewModel _mainViewModel;
        Button _refreshButton;
        ListView _listView;

        #endregion

        #region Override Methods

        /// <summary>
        /// Override method excute on Creation of activity
        /// </summary>
        /// <param name="bundle"></param>
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Initialize MainViewModel
            _mainViewModel = new MainViewModel(this);
            alertDialog = new AlertDialogHelper(this);

            //Initialize UI Controls
            InitializeUIControl();

            //Initialize data with controls
            InitializeData();
        }

        /// <summary>
        /// Override method excute on Destruction of activity
        /// </summary>
        protected override void OnDestroy()
        {
            _listView.Adapter = null;
            base.OnDestroy();
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Method to Initialize the UI controls
        /// </summary>
        private async void InitializeUIControl()
        {
            await Task.Run(() => {

                // Resolving the controls from the design
                _refreshButton = FindViewById<Button>(Resource.Id.refreshButton);
                _listView = FindViewById<ListView>(Resource.Id.dataList);

                // Refresh event handler to get the josn data
                _refreshButton.Click += async delegate {
                    await InitializeData();
                };
            });
        }

        /// <summary>
        /// Method to initialize the Data
        /// </summary>
        /// <returns></returns>
        private async Task InitializeData()
        {
            alertDialog.Show();

            //Get data from the viewmodel
            var data = await _mainViewModel.GetJsonData();
            if (data != null)
            {
                // Title for the actiity from the Json data
                this.Title = data.Title;

                if (_listView.Adapter != null)
                    _listView.Adapter = null;

                // Creation of List Adapter with Json data
                var adp = new DataListAdapter(this, data.Rows);
                _listView.Adapter = adp;
            }
            alertDialog.Dismiss();
        }

        #endregion

    }
}

