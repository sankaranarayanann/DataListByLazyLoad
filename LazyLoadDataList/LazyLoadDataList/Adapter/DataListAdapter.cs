using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using LazyLoadDataList.Data.Model;
using Square.Picasso;

namespace LazyLoadDataList.Adapter
{
    /// <summary>
    /// Adapter class derives from Base Adapter
    /// </summary>
    public class DataListAdapter : BaseAdapter
    {
        #region Private variables

        Activity activity;
        Rows[] rows;

        #endregion

        #region Constructor

        public DataListAdapter(Activity _activity, Rows[] _rows)
        {
            // Initilize the local values
            activity = _activity;
            rows = _rows;
        }

        #endregion

        #region Override Methods

        public override int Count
        {
            get
            {
                return rows.Count();
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return (Java.Lang.Object)rows.GetValue(position);
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = rows[position];
            ViewHolder holder;

            View view = convertView;
            if (view == null)
            {
                view = activity.LayoutInflater.Inflate(Resource.Layout.DataListItemLayout, null);

                holder = new ViewHolder();
                holder.titleText = (TextView)view.FindViewById(Resource.Id.text);
                holder.descriptionText = (TextView)view.FindViewById(Resource.Id.text1);
                holder.image = (ImageView)view.FindViewById(Resource.Id.image);

                view.Tag = holder;
            }
            else
                holder = (ViewHolder)view.Tag;

            // Assign row values
            holder.titleText.Text = rows[position].Title;
            holder.descriptionText.Text = rows[position].Description;
            ImageView image = holder.image;
            
            // Image lazy load
            var url = rows[position].ImageHref;
            if (!string.IsNullOrEmpty(url))
                Picasso.With(activity).Load(url).Into(image);

            return view;
        }

        #endregion

        /// <summary>
        /// Private class used while virtualizing the controls
        /// </summary>
        class ViewHolder : Java.Lang.Object
        {
            public TextView titleText;
            public TextView descriptionText;
            public ImageView image;
        }

    }

    

}