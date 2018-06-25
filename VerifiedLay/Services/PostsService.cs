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
                cmd.Parameters.AddWithValue("@PostContentsJSON", req.PostContentsJSON);

                cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                int id = (int)cmd.Parameters["@Id"].Value;
                return id;
            }
        }

        public List<Post> GetAll()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                var cmd = con.CreateCommand();

                cmd.CommandText = "Posts_GetAll";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    var results = new List<Post>();

                    while (reader.Read())
                    {
                        var post = new Post();
                        post.Id = (int)reader["Id"];
                        post.UserId = (int)reader["UserId"];
                        post.PostText = (string)reader["PostText"];
                        post.Location = (string)reader["Location"];
                        post.Latitude = (decimal)reader["Latitude"];
                        post.Longitude = (decimal)reader["Longitude"];
                        post.DateCreated = (DateTime)reader["DateCreated"];
                        post.DateModified = (DateTime)reader["DateModified"];

                        results.Add(post);
                    }

                    return results;
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                var cmd = con.CreateCommand();

                cmd.CommandText = "Posts_Delete";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(PostUpdateRequest req)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                var cmd = con.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "Posts_Edit";

                cmd.Parameters.AddWithValue("@Id", req.Id);
                cmd.Parameters.AddWithValue("@UserId", req.UserId);
                cmd.Parameters.AddWithValue("@PostText", req.PostText);
                cmd.Parameters.AddWithValue("@Location", req.Location);
                cmd.Parameters.AddWithValue("@Latitude", req.Latitude);
                cmd.Parameters.AddWithValue("@Longitude", req.Longitude);
                cmd.Parameters.AddWithValue("@PostContentsJSON", req.PostContentsJSON);

                cmd.ExecuteNonQuery();
            }
        }
    }
}