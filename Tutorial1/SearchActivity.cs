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
    [Activity(Label = "SearchActivity")]
    public class SearchActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SearchResult);

            Button searchButton = FindViewById<Button>(Resource.Id.btnSearch);
            searchButton.Click += searchButton_Click;
            // Create your application here
        }

        void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                DBRepository db = new DBRepository();
                EditText searchTxt = FindViewById<EditText>(Resource.Id.txtSearch);
                var result=db.GetById(int.Parse(searchTxt.Text));
                Toast.MakeText(this, result, ToastLength.Short).Show();
            }
            catch (Exception exception)
            {
                Toast.MakeText(this,exception.Message,ToastLength.Short).Show();
            }
            
        }
    }
}