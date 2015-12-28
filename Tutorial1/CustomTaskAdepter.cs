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
using Tutorial1.ORM;

namespace Tutorial1
{
    class CustomTaskAdepter:BaseAdapter<TodoTask>
    {
        private List<TodoTask> items;
        private Activity context;
        public CustomTaskAdepter(Activity context, List<TodoTask> items)
            : base()
        {
            this.context = context;
            this.items = items;
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
            view.FindViewById<TextView>(Resource.Id.myTestTextView2).Text = string.Format("{0}", item.Task);
            return view;
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override TodoTask this[int position]
        {
            get { return items[position]; }
        }
    }
}