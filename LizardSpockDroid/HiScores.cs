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
using System.IO;
//using System.Core;
using System.Data;
using SQLite;
using Mono.Data.Sqlite;


namespace LizardSpockDroid
{
    public class HiScores : IDisposable
    {
        public void Dispose()
        {
        }

        //public IEnumerable<Scores> GetScore()
        //{
        //    lock (locker)
        //    {
        //        return (from i in Table<Scores>() select i).ToList();
        //    }
        //}

        //public Stock GetScore(int id)
        //{
        //    lock (locker)
        //    {
        //        return Table<Scores>().FirstOrDefault(x => x.Id == id);
        //    }
        //}

        //public int SaveScore(Scores item)
        //{
        //    lock (locker)
        //    {
        //        if (item.RowID != 0)
        //        {
        //            Update(item);
        //            return item.Id;
        //        }
        //        else {
        //            return Insert(item);
        //        }
        //    }
        //}

        //public int DeleteStock(Scores score)
        //{
        //    lock (locker)
        //    {
        //        return Delete<Scores>(score.RowID);
        //    }
        //}

        //private void GetAllData()
        //{
        //    SQLiteConnection connection = GetDBConnection();
        //    // query the database to prove data was inserted!
        //    if (connection != null)
        //    {

        //        using (var contents = connection.CreateCommand())
        //        {
        //            contents.CommandText = "SELECT WinnerName, Score from [Scores] order by Score Desc";
        //            var r = contents.ExecuteReader();
        //            Console.WriteLine("Reading data");
        //            while (r.Read())
        //                Console.WriteLine("\tKey={0}; Value={1}",
        //                                  r["_id"].ToString(),
        //                                  r["Symbol"].ToString());
        //        }
        //        CloseDBConnection(connection);
        //    }
        //}

        public void AddScore(string WinnerName, int newScore)
        {
            SQLiteConnection connection = GetDBConnection();
            Console.WriteLine("Connected");
            Scores newHiScore = new Scores() { WinnerName = WinnerName, Score = newScore };
            connection.Insert(newHiScore);
            CloseDBConnection(connection);
        }

        public List<string> GetAllScores()
        {
            SQLiteConnection connection = GetDBConnection();
            List<string> preparedScoreList = new List<string>();
            var allScores = connection.Table<Scores>().ToList();
            foreach (Scores score in allScores.OrderByDescending(c => c.Score))
            {
                preparedScoreList.Add( string.Format("{0} {1}",  score.WinnerName, score.Score));
            }
            CloseDBConnection(connection);
            return preparedScoreList;
        }

        public void DeleteAllScores()
        {
            SQLiteConnection connection = GetDBConnection();
            connection.DeleteAll<Scores>();
            CloseDBConnection(connection);
        }

        private SQLiteConnection GetDBConnection()
        {
            // determine the path for the database file
            
            Console.WriteLine("GetDBConnection");
            string dbPath = Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                "LSHiScores.db");
            Console.WriteLine(dbPath);
            SQLiteConnection connection = new SQLiteConnection(dbPath);
            connection.CreateTable<Scores>();
            return connection;
        }

        private void CloseDBConnection(SQLiteConnection connection)
        {
            connection.Close();
        }
    }
}