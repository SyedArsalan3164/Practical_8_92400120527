using System.Collections.Generic;
using System.Data.SqlClient;

namespace Practical8.Models
{
    public class ItemRepository
    {
        string cs = @"Server=(localdb)\MSSQLLocalDB;Database=InventoryDB;Trusted_Connection=True;";

        // CREATE
        public void Add(Item i)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Items (ItemName, Quantity, Price) VALUES (@n, @q, @p)", con);
                cmd.Parameters.AddWithValue("@n", i.Name);
                cmd.Parameters.AddWithValue("@q", i.Quantity);
                cmd.Parameters.AddWithValue("@p", i.Price);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // READ
        public List<Item> GetAll()
        {
            List<Item> list = new List<Item>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Items", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new Item
                    {
                        Id = (int)dr["ItemId"],
                        Name = dr["ItemName"].ToString(),
                        Quantity = (int)dr["Quantity"],
                        Price = (decimal)dr["Price"]
                    });
                }
            }
            return list;
        }

        // UPDATE
        public void Update(Item i)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Items SET Quantity=@q, Price=@p WHERE ItemId=@id", con);
                cmd.Parameters.AddWithValue("@q", i.Quantity);
                cmd.Parameters.AddWithValue("@p", i.Price);
                cmd.Parameters.AddWithValue("@id", i.Id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE
        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Items WHERE ItemId=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
