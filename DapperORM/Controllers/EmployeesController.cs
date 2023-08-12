using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DapperORM.Models;
using Dapper;
namespace DapperORM.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", 0);
            dynamicParameters.Add("@functions", "GetAll");
            return View(dapperFunctions.StoreProcedureList<Employees>("SelectAllEmployee", dynamicParameters));
        }

        [HttpGet]
        public ActionResult CreateUpdate(int id = 0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@functions", "GetByID");
                dynamicParameters.Add("@id", id);
                return View(dapperFunctions.StoreProcedureList<Employees>("SelectAllEmployee", dynamicParameters).FirstOrDefault<Employees>());
            }
          
        }

        [HttpPost]
        public ActionResult CreateUpdate(Employees employeesModel)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@id", employeesModel.id);
            dynamicParameters.Add("@fname", employeesModel.fname);
            dynamicParameters.Add("@mname", employeesModel.mname);
            dynamicParameters.Add("@lname", employeesModel.lname);
            dynamicParameters.Add("@age", employeesModel.age);
       
            dapperFunctions.StoreProcedureNoReply("InsertUpdateEmployee", dynamicParameters);
            return RedirectToAction("Index");

        }
    }
}