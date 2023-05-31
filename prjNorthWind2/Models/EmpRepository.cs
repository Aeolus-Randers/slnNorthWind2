using Microsoft.Data.SqlClient;
using System.Data;

namespace prjNorthWind2.Models
{
    public class EmpRepository : IEmpRepository
    {
        string cnstr = "Data Source=192.168.0.8;Initial Catalog=wagor;TrustServerCertificate=true;User ID=sa;Password=gor,wa120122";
            public IList<tEmp> GetAll()
        {
            SqlConnection connection=new SqlConnection(cnstr);
            connection.Open();
            SqlCommand command=new SqlCommand("select id,學號,姓名,英文姓名,中文班別,中文班座號 from C學生基本資料 where 離校原因='' and 校區='西屯校' order by 中文班別,中文班座號 ",connection);
            SqlDataReader reader=command.ExecuteReader();
            IList<tEmp> students = new List<tEmp>();
            while(reader.Read()) 
            {
                students.Add(new tEmp
                {
                    Stdid = reader.GetInt32(0),
                    StdNum = reader.GetString(1),
                    StdCName = reader.GetString(2),
                    StdEName = reader.GetString(3),
                    StdCClass = reader.GetString(4),
                    StdCNum = reader.GetInt16(5),
                }); 
            }
            return students;
        }
    }
}
