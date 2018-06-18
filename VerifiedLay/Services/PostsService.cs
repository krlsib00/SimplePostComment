using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VerifiedLay.Models;

namespace VerifiedLay.Services
{
    public class PostsService : IPostsService
    {
        string connectionString =
                ConfigurationManager.ConnectionStrings["DefaultConnection"]
                .ConnectionString;

        public int Create(PostCreateRequest req)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "Posts_Create";

                cmd.Parameters.AddWithValue("@UserId", req.UserId);
                cmd.Parameters.AddWithValue("@PostText", req.PostText);
                cmd.Parameters.AddWithValue("@Location", req.Location);
                cmd.Parameters.AddWithValue("@Latitude", req.Latitude);
                cmd.Parameters.AddWithValue("@Longitude", req.Longitude);
                //cmd.Parameters.AddWithValue("@PostContentJSON", req.PostContentJSON);

                cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                int id = (int)cmd.Parameters["@Id"].Value;
                return id;
            }
        }

    }
}