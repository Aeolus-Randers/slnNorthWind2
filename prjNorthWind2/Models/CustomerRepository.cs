using Microsoft.Data.SqlClient;
namespace prjNorthWind2.Models
{
    public class CustomerRepository:ICustomerRepository
    {
        string cnstr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\MyDoc\\MyDoc\\Visual Studio 2022\\slnNorthWind2\\prjNorthWind2\\App_Data\\Northwind.mdf;Integrated Security=True;Connect Timeout=30;";
        public IList<t客戶> GetAll()
        {
            SqlConnection connection= new SqlConnection(cnstr);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM 客戶", connection);
            SqlDataReader reader = command.ExecuteReader();
            IList<t客戶> customers = new List<t客戶>();
            while (reader.Read())
            {
                customers.Add(new t客戶
                {
                    f客戶編號 = reader.GetString(0),
                    f公司名稱 = reader.GetString(1),
                    f連絡人 = reader.GetString(2),
                    f連絡人職稱 = reader.GetString(3),
                    f地址 = reader.GetString(4),
                    f電話 = reader.GetString(9),
                    f傳真電話 = reader.GetString(10)
                });
            }
            return customers;


        }


    }
}
