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

namespace Tutorial1
{
    class MyCoustomClassAdeper:BaseAdapter<MyCoustomClass>
    {
        private List<MyCoustomClass> items;
        private Activity context;
        public MyCoustomClassAdeper(Activity context, List<MyCoustomClass> items)
            : base()
        {
            this.items = items;
            this.context = context;
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.listViewTemplate1, null);
            }
            view.FindViewById<TextView>(Resource.Id.myTestTextView1).Text = string.Format("{0}", item.Id);
            view.FindViewById<TextView>(Resource.Id.myTestTextView2).Text = string.Format("{0} {1}", item.Name , item.Roll);
            return view;
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override MyCoustomClass this[int position]
        {
            get {return items[position]; }
        }
    }
}