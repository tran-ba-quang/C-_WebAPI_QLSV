using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace WebQuanLySinhVien.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class SinhVienController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            Provider p = new Provider();
            DataTable dt = p.Select(CommandType.Text, "SELECT * FROM SinhVien");
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dt);
            return JSONString;
        }
        [HttpPost]
        public void Post([FromBody] SinhVien sv)
        {
            
            Provider p = new Provider();
            string strSql = "INSERT INTO SinhVien VALUES(@ID,@TEN,@GIOITINH,@TUOI,@DIEMTOAN,@DIEMVAN,@DIEMANH,@DIEMTRUNGBINH,@HOCLUC)";
            sv.Diemtrungbinh = (sv.Diemtoan + sv.Diemanh + sv.Diemvan) / 3;
            if (sv.Diemtrungbinh >= 8)
            {
                sv.Hocluc = "Gioi";
            }
            else if (sv.Diemtrungbinh >= 6.5 && sv.Diemtrungbinh < 8)
            {
                sv.Hocluc = "Kha";
            }
            else if (sv.Diemtrungbinh >= 5 && sv.Diemtrungbinh < 6.5)
            {
                sv.Hocluc = "Trung Binh";
            }
            else
            {
                sv.Hocluc = "Yeu";
            }
            p.ExecuteNonQuery(CommandType.Text, strSql,
               new SqlParameter { ParameterName = "@ID", Value = sv.Id },
               new SqlParameter { ParameterName = "@TEN", Value = sv.Ten },
               new SqlParameter { ParameterName = "@GIOITINH", Value = sv.Gioitinh },
               new SqlParameter { ParameterName = "@TUOI", Value = sv.Tuoi },
               new SqlParameter { ParameterName = "@DIEMTOAN", Value = sv.Diemtoan },
               new SqlParameter { ParameterName = "@DIEMVAN", Value = sv.Diemvan },
               new SqlParameter { ParameterName = "@DIEMANH", Value = sv.Diemanh },
               new SqlParameter { ParameterName = "@DIEMTRUNGBINH", Value = sv.Diemtrungbinh },
               new SqlParameter { ParameterName = "@HOCLUC", Value = sv.Hocluc }

                );
        }

        [HttpPut("/id")]
        public void Put(string id, [FromBody] SinhVien sv)
        {
            Provider p = new Provider();
            string strSql = "UPDATE SinhVien " +
                            "SET TEN=@TEN, GIOITINH=@GIOITINH, TUOI=@TUOI, DIEMTOAN=@DIEMTOAN, DIEMVAN=@DIEMVAN, DIEMANH=@DIEMANH, DIEMTRUNGBINH=@DIEMTRUNGBINH, HOCLUC=@HOCLUC " +
                            "WHERE ID=@ID";
            sv.Diemtrungbinh = (sv.Diemtoan + sv.Diemanh + sv.Diemvan) / 3;
            if (sv.Diemtrungbinh >= 8)
            {
                sv.Hocluc = "Gioi";
            }
            else if (sv.Diemtrungbinh >= 6.5 && sv.Diemtrungbinh < 8)
            {
                sv.Hocluc = "Kha";
            }
            else if (sv.Diemtrungbinh >= 5 && sv.Diemtrungbinh < 6.5)
            {
                sv.Hocluc = "Trung Binh";
            }
            else if(sv.Diemtrungbinh >= 0 && sv.Diemtrungbinh < 5)
            {
                sv.Hocluc = "Yeu";
            }
            p.ExecuteNonQuery(CommandType.Text, strSql,
            new SqlParameter { ParameterName = "@ID", Value = sv.Id },
            new SqlParameter { ParameterName = "@TEN", Value = sv.Ten },
            new SqlParameter { ParameterName = "@GIOITINH", Value = sv.Gioitinh },
            new SqlParameter { ParameterName = "@TUOI", Value = sv.Tuoi },
            new SqlParameter { ParameterName = "@DIEMTOAN", Value = sv.Diemtoan },
            new SqlParameter { ParameterName = "@DIEMVAN", Value = sv.Diemvan },
            new SqlParameter { ParameterName = "@DIEMANH", Value = sv.Diemanh },
            new SqlParameter { ParameterName = "@DIEMTRUNGBINH", Value = sv.Diemtrungbinh},
            new SqlParameter { ParameterName = "@HOCLUC", Value = sv.Hocluc }
             );
        }

        [HttpDelete("/id")]
        public void Delete(string id)
        {
            Provider p = new Provider();
            string strSql = "DELETE SinhVien WHERE ID = @ID";
            p.ExecuteNonQuery(CommandType.Text, strSql,
                new SqlParameter { ParameterName = "@ID", Value = id }
                 );
        }

        [HttpGet("/ten")]
        public IActionResult Search(string ten)
        {
            Provider p = new Provider();
            string strSql = "SELECT * FROM SinhVien WHERE TEN LIKE '%' + @TEN + '%'";
            DataTable dt = p.Select(CommandType.Text, strSql,
                new SqlParameter { ParameterName = "@TEN", Value = ten }
                );
            string JSONString = JsonConvert.SerializeObject(dt);
            return new JsonResult(JSONString);
        }
    }
}
