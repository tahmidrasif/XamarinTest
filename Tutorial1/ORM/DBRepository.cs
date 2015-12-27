using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using SQLite;


namespace Tutorial1.ORM
{
    class DBRepository
    {
        public string CreateDb()
        {
            try
            {
                var output = "";
                output += "Creating Db";
                string dbPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                    "oredemo.db3");
                var db = new SQLiteConnection(dbPath);
                output += "\n Db Created";
                return output;
            }
            catch (Exception exception)
            {
                throw exception;
            }
          
        }

        public string CreateTable()
        {
            try
            {
                string dbPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                   "oredemo.db3");
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<TodoTask>();
                string result = "Table Created";
                return result;
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        public string Insert(string task)
        {
            try
            {
                string dbPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                   "oredemo.db3");
                var db = new SQLiteConnection(dbPath);
                TodoTask aTask=new TodoTask();
                aTask.Task = task;
                db.Insert(aTask);
                return "Added";
            }
            catch (Exception exception)
            {
                return exception.Message;

            }
        }

        public string GetAll()
        {
            string dbPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                   "oredemo.db3");
            var db = new SQLiteConnection(dbPath);
            string output = "";
            TableQuery<TodoTask> table = db.Table<TodoTask>();

          //  return table.ToList();
            foreach (var todoTask in table)
            {
                output += "\n" + todoTask.Id + "------" + todoTask.Task;
            }

            return output;
        }

        public string GetById(int id)
        {
            string dbPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                  "oredemo.db3");
            var db = new SQLiteConnection(dbPath);
            TodoTask item=db.Get<TodoTask>(x => x.Id == id);
            return item.Task;
        }

        public string Update(int id,string task)
        {
            string dbPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                  "oredemo.db3");
            var db = new SQLiteConnection(dbPath);
            TodoTask item = db.Get<TodoTask>(x => x.Id == id);
            item.Task = task;
            db.Update(item);
            return "Updated";
        }

        public string Delete(int id)
        {
            string dbPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                 "oredemo.db3");
            var db = new SQLiteConnection(dbPath);
            TodoTask item = db.Get<TodoTask>(x => x.Id == id);
            db.Delete(item);
            return "Deleted";
        }
    }
}