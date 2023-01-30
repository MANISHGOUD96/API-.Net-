using MK_web_API_Project.DB_Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MK_web_API_Project.Controllers
{
    public class EmpController : ApiController
    {
        
        REVEntities DB = new REVEntities();

        [HttpGet]
        [Route("Api/GetEMPData")]
        public List<Employee> GetData()
        {
            var rev = DB.Employees.ToList();
            return rev;
        }
         
        [HttpPost]
        [Route("Api/SaveData")]
        
        public HttpResponseMessage SaveEmp(Employee obj)
        {
            if (obj.Id == 0)
            {
                DB.Employees.Add(obj);
                DB.SaveChanges();
            }
            else
            {
                DB.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
            }
            HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
            return res;
        }
        

        [HttpGet]
        [Route("Api/EditData")]

        public Employee GetEditData(int Id)
        {
            var resedit = DB.Employees.Where(a => a.Id == Id).First();
            return resedit;
        }

        [HttpGet]
        [Route("Api/DeleteData")]

        public HttpResponseMessage DeleteData(int Id)
        {
            var delete = DB.Employees.Where(a => a.Id == Id).First();
            DB.Employees.Remove(delete);
            DB.SaveChanges();
            HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
            return res;

        }

    }
}