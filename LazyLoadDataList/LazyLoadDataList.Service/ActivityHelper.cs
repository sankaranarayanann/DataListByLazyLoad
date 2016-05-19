using Android.App;

namespace LazyLoadDataList.Service
{
    /// <summary>
    /// Helper class for 
    /// </summary>
    public class AlertDialogHelper
    {
        #region Private variables

        ProgressDialog pDialog;

        #endregion

        #region Constructor

        public AlertDialogHelper(Activity activity)
        {
            // Initilize Process Dialog with activity
            pDialog = new ProgressDialog(activity);
            pDialog.SetMessage("Please wait...");
            pDialog.SetCancelable(false);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Method to show the Process Dialog
        /// </summary>
        public void Show()
        {
            pDialog.Show();
        }

        /// <summary>
        /// Method to dismiss the Process Dialog
        /// </summary>
        public void Dismiss()
        {
            if (pDialog.IsShowing)
                pDialog.Dismiss();
        }

        #endregion
    }
}