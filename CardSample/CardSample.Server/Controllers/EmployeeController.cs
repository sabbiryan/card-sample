using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using CardSample.Server.Models;
using CardSample.Server.ViewModels;

namespace CardSample.Server.Controllers
{

    [RoutePrefix("api/Employee")]
    public class EmployeeController : ControllerBase
    {
        
        public EmployeeController()
        {
            
        }


        public IHttpActionResult Get()
        {
            var employees = DbContext.Employees.Where(x => x.IsDeleted == false).Include(x=> x.Department).ToList();
            var viewModels = employees.ConvertAll(x => new EmployeeViewModel(x));

            return Ok(viewModels);
        }


        public IHttpActionResult Get(string id)
        {
            var employee = DbContext.Employees.Find(id);
            var viewModel = new EmployeeViewModel(employee);


            return Ok(viewModel);
        }


        public IHttpActionResult Post(Employee model)
        {

            model.Id = Guid.NewGuid().ToString();
            model.CreationTime = DateTime.Now;

            var isExist = DbContext.Employees.AsNoTracking().Any(x => x.IsDeleted == false && x.Name.ToLower() == model.Name.ToLower() && x.Id != model.Id);
            if (isExist) return BadRequest($"{model.Name} already exist. Please try with diffrent one");

            var employee = DbContext.Employees.Add(model);
            DbContext.SaveChanges();

            return Ok(employee);
        }


        public IHttpActionResult Put(Employee model)
        {
            model.ModificationTime = DateTime.Now;

            var isExist = DbContext.Employees.AsNoTracking().Any(x => x.IsDeleted == false && x.Name.ToLower() == model.Name.ToLower() && x.Id != model.Id);
            if (isExist) return BadRequest($"{model.Name} already exist. Please try with diffrent one");


            DbContext.Entry(model).State = EntityState.Modified;
            DbContext.SaveChanges();

            return Ok(model.Id);
        }



        public IHttpActionResult Delete(string id)
        {
            var employee = DbContext.Employees.Find(id);

            if (employee == null) return BadRequest("Entry not found!");

            DbContext.Employees.Remove(employee);
            var saveChanges = DbContext.SaveChanges() > 0;

            return Ok(saveChanges);
        }
    }
}