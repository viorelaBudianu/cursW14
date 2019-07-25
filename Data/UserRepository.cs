
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UserRepository:IUserRepository
    {  
        public void DeleteUser(User user)
        {
            try
            {
                string connectionString = "Data Source=.; Initial Catalog=w14;Integrated Security=True;";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand comanda = new SqlCommand();
                comanda.Connection = connection;

                comanda.CommandText = "DELETE from USERS Where ID=@Id";
                SqlParameter parameterUserN = new SqlParameter("@Id", System.Data.DbType.String);
                parameterUserN.Value = user.Id;

                comanda.ExecuteScalar();

                connection.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void AddUser(User user)
        {
           
            try
            {
                string connectionString = "Data Source=.; Initial Catalog=w14;Integrated Security=True;";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand comanda = new SqlCommand();
                comanda.Connection = connection;

                comanda.CommandText = "Insert into USERS values (@Username,@Email,@City,@Description,@Street)";
                SqlParameter parameterUserN = new SqlParameter("@Username", System.Data.DbType.String);
                parameterUserN.Value = user.UserName;

                SqlParameter parameterEmail = new SqlParameter("@Email", System.Data.DbType.String);
                parameterEmail.Value = user.Email;

                SqlParameter parameterCity = new SqlParameter("@City", System.Data.DbType.String);
                parameterCity.Value = user.City;

                SqlParameter parameterDesc = new SqlParameter("@Description", System.Data.DbType.String);
                parameterDesc.Value = user.Description;

                SqlParameter parameterStreet = new SqlParameter("@Street", System.Data.SqlDbType.Decimal);
                parameterStreet.Value = user.Street;

                comanda.Parameters.Add(parameterUserN);
                comanda.Parameters.Add(parameterEmail);
                comanda.Parameters.Add(parameterCity);
                comanda.Parameters.Add(parameterDesc);
                comanda.Parameters.Add(parameterStreet);
                var returned = comanda.ExecuteScalar();

                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
                

        public List<User> GetAll()
        {
            string connectionString = "Data Source=.; Initial Catalog=w14;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Select * from dbo.USERS";

            SqlDataReader ss = command.ExecuteReader();

            List<User> list = new List<User>();

            while (ss.Read())
            {
                User user = new User();
                user.Id = (int?)ss[0];
                user.UserName = ss[1] as string;
                user.Email = (string)ss["EMAIL"];
                user.City = (string)ss["CITY"];
                user.Description = (string)ss["DESCRIPTION"];
                user.Street = (string)ss["STREET"];
                list.Add(user);

            }
            ss.Close();
            connection.Close();
            return list;
        }

        
    }
}
