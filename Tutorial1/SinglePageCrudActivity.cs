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
          //  ListAdapter = new CustomTaskAdepter(this, output);
           // lstViewCrud.Adapter = output;
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
    }
}