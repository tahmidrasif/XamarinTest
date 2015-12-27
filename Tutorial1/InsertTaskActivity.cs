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
    [Activity(Label = "InsertTaskActivity")]
    public class InsertTaskActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.InserTask);
            // Create your application here
            Button buttonSave = FindViewById<Button>(Resource.Id.btnSave);
            buttonSave.Click += buttonSave_Click;
        }

        void buttonSave_Click(object sender, EventArgs e)
        {
            EditText txtTask = FindViewById<EditText>(Resource.Id.txtTask);
            DBRepository db=new DBRepository();
            string result=db.Insert(txtTask.Text);
            Toast.MakeText(this,result,ToastLength.Short).Show();
            
        }
    }
}