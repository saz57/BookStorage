using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace StorageCore
{
    public class SQLRepository : IRepository
    {
        private string _connectionString;
        private SqlConnection _sqlConnection;

        public SQLRepository()
        {
            _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=StorageSQL; Integrated Security=True";
            _sqlConnection = new SqlConnection(_connectionString);
        }

        public List<T> Get<T>() where T : TextPaper
        {
            List<T> items = new List<T>();
            T buffItem;
            string sqlExpression = "SELECT * FROM ";
            _sqlConnection.Open(); //don't now what is right - open it async, try to do that class singleton or try to block access to databace, if connection is open by another user 

            if (typeof(T) == typeof(Book))
            {
                sqlExpression += "Book";
            }

            if (typeof(T) == typeof(Jornal))
            {

            }

            if (typeof(T) == typeof(NewsPaper))
            {

            }
            SqlCommand command = new SqlCommand(sqlExpression, _sqlConnection);
            SqlDataReader result = command.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    if (typeof(T) == typeof(Book))
                    {
                        buffItem = new Book() { Name = result.GetValue(0).ToString(), Autor = result.GetValue(1).ToString(), Content = result.GetValue(2).ToString() } as T;
                        items.Add(buffItem);
                    }

                    if (typeof(T) == typeof(Jornal))
                    {

                    }

                    if (typeof(T) == typeof(NewsPaper))
                    {

                    }
                }
            }
            _sqlConnection.Close();
            return items;
        }

        public void Put<T>(List<T> items) where T : TextPaper
        {

            List<T> itemsInDatabase = Get<T>();

            _sqlConnection.Open(); //don't now what is right - open it async, try to do that class singleton or try to block access to databace, if connection is open by another user 

            bool isFirstItem = true;
            string sqlExpression = "INSERT INTO Book (Name, Autor, Content) VALUES ";//'SomeBook1', 'SomeAutor1', 'SomeContent1'), ('SomeBook2', 'SomeAutor2', 'SomeContent2')";

            foreach (T item in items)
            {

                if (itemsInDatabase.FirstOrDefault<T>(x => x.Equals(item)) == null)
                {
                    if (!isFirstItem)
                    {
                        sqlExpression += ",";
                    }

                    if (isFirstItem)
                    {
                        isFirstItem = false;
                    }
                    sqlExpression += item.ToWritebleSql();
                }
            }

            if (!isFirstItem)
            {
                SqlCommand command = new SqlCommand(sqlExpression, _sqlConnection);
                int result = command.ExecuteNonQuery();
            }
            _sqlConnection.Close();
            /* List<string> lines = new List<string>();

             foreach (T item in items)
             {
                 lines.Add(item.ToWritebleTxt());
             }

             File.WriteAllLines(_fileName, lines);*/
        }
    }
}
