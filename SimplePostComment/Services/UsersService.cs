using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SimplePostComment.Models;

namespace SimplePostComment.Services
{
    public class UsersService : IUsersService
    {
            // ConfiguarionManager is a class
            // it has a static property called "ConnectionStrings".
            // we "index" into that using square brackets.
            // then we get the ConnectionString property of that.

            // In C# parlance, this is a "field".

            string connectionString =
                ConfigurationManager.ConnectionStrings["DefaultConnection"]
                .ConnectionString;

        public List<User> GetAll()
        {
            // 1. create and open a SqlConnection
            // 2. create a SqlCommand
            // 3. Execute the command, which will give us a SqlDataReader
            // 4. We'll use the SqlDataReader to loop over all the rows coming from the query

            // 1. 
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // 2.
                var command = con.CreateCommand();
                // "var" is exactly the same as: SqlCommand command = con.CreateCommand();

                command.CommandText = "Users_GetAll";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // 3. 
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    var results = new List<User>();

                    while (reader.Read())
                    {
                        // this loop will happen once for every row coming out of the database

                        var user = new User();
                        user.Id = (int)reader["id"];
                        user.FirstName = (string)reader["FirstName"];
                        user.LastName = (string)reader["LastName"];
                        user.DisplayName = (string)reader["DisplayName"];
                        user.Email = (string)reader["Email"];
                        user.Password = (string)reader["Password"];
                        user.Sex = (bool)reader["Sex"];
                        user.Age = (int)reader["Age"];
                        user.ZipCode = (int)reader["ZipCode"];
                        user.Verified = (bool)reader["Verified"];
                        user.DateCreated = (DateTime)reader["DateCreated"];
                        user.DateModified = (DateTime)reader["DateModified"];

                        #region OTHER WAY TO DO IT
                        // This is the exact same as above, but uses C# "Object Initializer" syntax
                        //var user2 = new User
                        //{
                        //      Id = (int)reader["id"],
                        //      Name = (string)reader["name"],
                        //      DateCreated = (DateTime)reader["DateCreated"]
                        //      DateModified = (DateTime)reader["DateModified"]
                        //};
                        #endregion

                        // be sure to add the user to the List<User>
                        results.Add(user);
                    }

                    return results;
                }
            }

            // no more con (thanks to the "using")
        }
    }
}