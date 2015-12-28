using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Tutorial1.ORM;

namespace Tutorial1
{
    [Activity(Label = "Tutorial1", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Home);

            // Get our button from the layout resource,
            // and attach an event to it
            Button createdbBtn = FindViewById<Button>(Resource.Id.btnCreateDb);
            createdbBtn.Click += createdbBtn_Click;

            Button createTableBtn = FindViewById<Button>(Resource.Id.btnCreateTbl);
            createTableBtn.Click += createTableBtn_Click;

            Button addButton = FindViewById<Button>(Resource.Id.btnInsert);
            addButton.Click += addButton_Click;

            Button getAllButton = FindViewById<Button>(Resource.Id.btnSelectAll);
            getAllButton.Click += getAllButton_Click;

            Button getByIdButton = FindViewById<Button>(Resource.Id.btnSelectById);
            getByIdButton.Click += getByIdButton_Click;

            Button updateButton = FindViewById<Button>(Resource.Id.btnUpdate);
            updateButton.Click += updateButton_Click;

            Button deleteButton = FindViewById<Button>(Resource.Id.btnDelete);
            deleteButton.Click += deleteButton_Click;

            Button crudButton = FindViewById<Button>(Resource.Id.btnCrud);
            crudButton.Click += crudButton_Click;

        }


        void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                StartActivity(typeof(RemoveActivity));

            }
            catch (Exception exception)
            {

                Toast.MakeText(this, exception.Message, ToastLength.Short).Show();
            }


        }

        void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                StartActivity(typeof(UpdateActivity));
                
            }
            catch (Exception exception)
            {
                
                Toast.MakeText(this,exception.Message,ToastLength.Short).Show();
            }
            

        }

        void getByIdButton_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(SearchActivity));

        }

        void getAllButton_Click(object sender, EventArgs e)
        {
            DBRepository db=new DBRepository();
            var output=db.GetAll();
           // Toast.MakeText(this,output,ToastLength.Short).Show();

        }

        void addButton_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(InsertTaskActivity));
        }

        void createdbBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DBRepository db = new DBRepository();
                Toast.MakeText(this, "Hello World, I'm Clicked", ToastLength.Short).Show();
                var msg = db.CreateDb();
                Toast.MakeText(this, msg, ToastLength.Short).Show();
            }
            catch (Exception exception)
            {

                var msg = exception.Message;
                Toast.MakeText(this, msg, ToastLength.Short);
            }
            
        }

        void createTableBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DBRepository db = new DBRepository();
                Toast.MakeText(this, "Hello World, I'm Clicked", ToastLength.Short).Show();
                var msg = db.CreateTable();
                Toast.MakeText(this, msg, ToastLength.Short).Show();
            }
            catch (Exception exception)
            {

                var msg = exception.Message;
                Toast.MakeText(this, msg, ToastLength.Short);
            }

        }

        void crudButton_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(SinglePageCrudActivity));
        }
    }
}

