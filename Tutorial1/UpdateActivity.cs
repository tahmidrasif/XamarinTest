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
    [Activity(Label = "UpdateActivity")]
    public class UpdateActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.UpdateTask);

            Button seachButton = FindViewById<Button>(Resource.Id.btnSearchById);
            seachButton.Click += seachButton_Click;
            // Create your application here

            Button updateButton = FindViewById<Button>(Resource.Id.btnUpdateById);
            updateButton.Click += updateButton_Click;
        }

        private void seachButton_Click(object sender, EventArgs e)
        {
            DBRepository db=new DBRepository();

            EditText txtId = FindViewById<EditText>(Resource.Id.txtId);
            EditText txtTask = FindViewById<EditText>(Resource.Id.txtTask);
            txtTask.Text=db.GetById(int.Parse(txtId.Text));

        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                DBRepository db = new DBRepository();

                EditText txtId = FindViewById<EditText>(Resource.Id.txtId);
                EditText txtTask = FindViewById<EditText>(Resource.Id.txtTask);

                string message=db.Update(int.Parse(txtId.Text), txtTask.Text);
                Toast.MakeText(this, message, ToastLength.Short).Show();
            }
            catch (Exception exception)
            {
                
                throw exception;
            }
           

        }
    }
}