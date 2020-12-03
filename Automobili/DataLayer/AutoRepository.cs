using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AutoRepository
    {
        public List<Automobil> GetAutomobilis()
        {
            List<Automobil> automobilList = new List<Automobil>();
            string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Automobili;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                string commandText = "Select * from Automobili";
                SqlCommand com = new SqlCommand(commandText, con);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    Automobil a = new Automobil(dr.GetInt32(0), dr.GetString(1), dr.GetInt32(2), dr.GetDecimal(3), dr.GetInt32(4));
                    automobilList.Add(a);
                }
            }

            return automobilList;
        }
        public int insertAuto(Automobil a)
        {
            int result;
            string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Automobili;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                string commandText = "Insert into Automobili (Marka,GodinaProizvodnje,Cena,ZapreminaMotora) values(@marka,@godinaProizvodnje,@cena,@zapreminaMotora)";
                SqlCommand com = new SqlCommand(commandText, con);
                com.Parameters.AddWithValue("@Marka", a.marka);
                com.Parameters.AddWithValue("@godinaProizvodnje", a.godinaProizvodnje);
                com.Parameters.AddWithValue("@cena", a.cena);
                com.Parameters.AddWithValue("@zapreminaMotora", a.zapreminaMotora);
                result = com.ExecuteNonQuery();

            }
            return result;
        }


        public int deleteAuto(string automobilMarka)
        {
            int result;
            string conString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Automobili;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                string commandText = "Delete from Automobili where Marka=@marka";
                SqlCommand com = new SqlCommand(commandText, con);
                com.Parameters.AddWithValue("@marka", automobilMarka);
                result = com.ExecuteNonQuery();
            }
            return result;
        }
        public int UpdateAuto(Automobil a)
        {
            int result;
            string constring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Automobili;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();
                string com = "Update Automobili SET Marka =@Marka, GodinaProizvodnje = @godinaProizvodnje, Cena = @cena, ZapreminaMotora=@zapreminaMotora where Id=@Id";
                SqlCommand command = new SqlCommand(com, con);
                command.Parameters.AddWithValue("@Id", a.id);
                command.Parameters.AddWithValue("@Marka", a.marka);
                command.Parameters.AddWithValue("@godinaProizvodnje", a.godinaProizvodnje);
                command.Parameters.AddWithValue("@cena", a.cena);
                command.Parameters.AddWithValue("@zapreminaMotora", a.zapreminaMotora);

                result = command.ExecuteNonQuery();

            }
            return result;
        }
    }
}
