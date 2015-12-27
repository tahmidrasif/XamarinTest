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
    [Activity(Label = "RemoveActivity")]
    public class RemoveActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.RemoveTask);

            Button searchButton = FindViewById<Button>(Resource.Id.btnRemoveSearch);
            searchButton.Click += searchButton_Click;

            Button removeButton = FindViewById<Button>(Resource.Id.btnRemoveTask);
            removeButton.Click += removeButton_Click;

            // Create your application here
        }

        public void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                DBRepository db = new DBRepository();

                EditText txtId = FindViewById<EditText>(Resource.Id.txtRemoveId);
                EditText txtTask = FindViewById<EditText>(Resource.Id.txtRemoveTask);
                txtTask.Text = db.GetById(int.Parse(txtId.Text));
                Toast.MakeText(this, "Found", ToastLength.Short).Show();
            }
            catch (Exception exception)
            {
                
               Toast.MakeText(this,exception.Message,ToastLength.Short).Show();
            }
            
        }

        public void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                DBRepository db = new DBRepository();

                EditText txtId = FindViewById<EditText>(Resource.Id.txtRemoveId);
                var msg = db.Delete(int.Parse(txtId.Text));
                Toast.MakeText(this, msg, ToastLength.Short).Show();
            }
            catch (Exception exception)
            {

                Toast.MakeText(this, exception.Message, ToastLength.Short).Show();
            }
            
        }
    }
}