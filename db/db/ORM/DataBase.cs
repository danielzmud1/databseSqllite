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
using SQLite;
using System.Threading.Tasks;

namespace db.ORM
{
    class DataBase
    {
        private SQLiteConnection mCon;

        public string createDatabase()
        {
            try
            {
                string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                mCon = new SQLiteConnection(System.IO.Path.Combine(folder, "db.db"));
                mCon.DropTable<User>();

                {
                    mCon.CreateTable<User>();
                    return "Database created";
                }
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }

        public void insertUpdateData(User data)
        {

            //var db = new SQLiteAsyncConnection(path);
            if ( mCon.Insert(data) != 0)
                 mCon.Update(data);
        }

        //to read all record
        public  List<User> FnGetAllContactList()
        {
         
            var lstAllContact = mCon.Query<User>("select * from User");
            lstAllContact.ToList();
            
            return lstAllContact;
           
        }
        //to read matching record with string


    }
}