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
        private SQLiteAsyncConnection mCon;

        public async Task<string> createDatabase()
        {
            try
            {
                string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                mCon = new SQLiteAsyncConnection(System.IO.Path.Combine(folder, "db.db"));
                mCon.DropTableAsync<User>();
                {
                    await mCon.CreateTableAsync<User>();
                    return "Database created";
                }
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }

        public async void insertUpdateData(User data)
        {

            //var db = new SQLiteAsyncConnection(path);
            if (await mCon.InsertAsync(data) != 0)
                await mCon.UpdateAsync(data);



        }



        /*
         public async Task<string> findNumberRecords()
         {
         
             //var db = new SQLiteAsyncConnection(path);
             // this counts all records in the database, it can be slow depending on the size of the database
             var count = await mCon.ExecuteScalarAsync<string>("SELECT * FROM User");
            
             //var count = await mCon.ExecuteScalarAsync<string>("SELECT * FROM User");

             // for a non-parameterless query
             // var count = db.ExecuteScalarAsync<int>("SELECT Count(*) FROM Person WHERE FirstName="Amy");

             return count;
          }
          */

        //to read all record
        public async Task<List<User>> FnGetAllContactList()
        {
            var lstAllContact = await mCon.QueryAsync<User>("select * from User");
            List<User> x = lstAllContact.ToList();

            /*
           // FnStopActivityIndicator();
            var contacts =  Task.WhenAll(lstAllContact.Select(
                 c => new User()
                {
                   // phones = (await ContactBLL.GetContactPhones(c.ContactID)).ToList(),
                    firstName = c.FirstName
                   // lastName = c.LastName
                }));
            */
            System.Threading.Tasks.Task.Delay(1000);
            return lstAllContact;
        }
        //to read matching record with string


    }
}