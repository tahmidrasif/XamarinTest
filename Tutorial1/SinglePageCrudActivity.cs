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
    [Activity(Label = "SinglePageCrudActivity")]
    public class SinglePageCrudActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.CrudLayout);

            Button btnForm = FindViewById<Button>(Resource.Id.btnCrudAdd);
            btnForm.Click += btnForm_Click;

            ListView lstViewCrud = FindViewById<ListView>(Resource.Id.lstCrud);
            DBRepository db=new DBRepository();
            var output=db.GetAll();

            var data = GetAllList();

            lstViewCrud.Adapter = new CustomTaskAdepter(this, output); 
        }

        protected override void OnRestart()
        {
            base.OnRestart();
            Toast.MakeText(this, "Restart", ToastLength.Short).Show();

            ListView lstViewCrud = FindViewById<ListView>(Resource.Id.lstCrud);
            DBRepository db = new DBRepository();
            var output = db.GetAll();
            lstViewCrud.Adapter = new CustomTaskAdepter(this, output);
        }

        protected override void OnResume()
        {
            base.OnResume();
            Toast.MakeText(this, "Resume", ToastLength.Short).Show();
            //SetContentView(Resource.Layout.CrudLayout);
            //Button btnForm = FindViewById<Button>(Resource.Id.btnCrudAdd);
            //btnForm.Click += btnForm_Click;
            //ListView lstViewCrud = FindViewById<ListView>(Resource.Id.lstCrud);
            //DBRepository db = new DBRepository();
            //var output = db.GetAll();
            //lstViewCrud.Adapter = new CustomTaskAdepter(this, output);

        }

        public void btnForm_Click(object sender, EventArgs e)
        {
            //FragmentTransaction fragment = FragmentManager.BeginTransaction();
            //DialogForm dialog = new DialogForm();         
            //dialog.Show(fragment, "My Tag");

            //Dialog dialog = new Dialog(this);
            // dialog.SetContentView(Resource.Layout.CrudFormLayout);
            // dialog.SetCancelable(true);
            // dialog.SetTitle("ListView");
            // dialog.Show();
            StartActivity(typeof(InsertTaskActivity));
        }

        public List<MyCoustomClass> GetAllList()
        {
            List<MyCoustomClass> list = new List<MyCoustomClass>()
            {
                new MyCoustomClass() {Id = 1, Name = "Rasif", Roll = "111"},
                new MyCoustomClass() {Id = 2, Name = "Rasif1", Roll = "112"},
                new MyCoustomClass() {Id = 3, Name = "Rasif1", Roll = "113"},
                new MyCoustomClass() {Id = 4, Name = "Rasif1", Roll = "114"},
            };
            return list;
        } 
        
    }

    public class MyCoustomClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Roll { get; set; }    
    }
}