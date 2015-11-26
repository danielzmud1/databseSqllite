using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using db.ORM;

namespace db
{
    [Activity(Label = "db", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var db = new DataBase();
            db.createDatabase();

            var mEditTextInsert = FindViewById<EditText>(Resource.Id.edInsert);
            var mButtonInsert = FindViewById<Button>(Resource.Id.btnInsert);
            mButtonInsert.Click += delegate
            {
                db.insertUpdateData(new User { FirstName = mEditTextInsert.Text });
            };

            db.insertUpdateData(new User { FirstName = "Kazik" });
            db.insertUpdateData(new User { FirstName = "Szymon" });
            db.insertUpdateData(new User { FirstName = "Maciej" });


            var mEditTextGet = FindViewById<EditText>(Resource.Id.edGet);
            var mButtonGet = FindViewById<Button>(Resource.Id.btnGet);

            //mButtonGet.Click += delegate { mEditTextGet.Text = db.findNumberRecords().ToString(); }; 
            //mButtonGet.Click += mButtonGet_Click;
        
            mButtonGet.Click += delegate
            {
                var contactList = db.FnGetAllContactList();
                //Task.WhenAll(contactList);

                var x = contactList;
                string str = string.Empty;
                foreach (var item in x)
                {
                    str += item.FirstName;
                    
                    //mEditTextGet.Text += item.FirstName;
                }
                mEditTextGet.Text = str;
                //var contacts = await Task.Run();


                System.Threading.Tasks.Task.Delay(100);
            };
            

        }

    
    }
}

