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

    [RoutePrefix("api/Department")]
    public class DepartmentController : ControllerBase
    {
        
        public DepartmentController()
        {
            
        }


        public IHttpActionResult Get()
        {
            var departments = DbContext.Departments.Where(x => x.IsDeleted == false).Include(x => x.Employees).ToList();
            var viewModels = departments.ConvertAll(x => new DepartmentViewModel(x));

            return Ok(viewModels);
        }


        public IHttpActionResult Get(string id)
        {
            var department = DbContext.Departments.Include(x => x.Employees).FirstOrDefault(x => x.Id == id);
            var viewModel = new DepartmentViewModel(department);


            return Ok(viewModel);
        }


        public IHttpActionResult Post(Department model)
        {

            model.Id = Guid.NewGuid().ToString();
            model.CreationTime = DateTime.Now;

            var isExist = DbContext.Departments.AsNoTracking().Any(x => x.IsDeleted == false && x.DepartmentName.ToLower() == model.DepartmentName.ToLower() && x.Id != model.Id);
            if (isExist) return BadRequest($"{model.DepartmentName} already exist. Please try with diffrent one");

            var department = DbContext.Departments.Add(model);
            DbContext.SaveChanges();

            return Ok(department);
        }


        public IHttpActionResult Put(Department model)
        {
            model.ModificationTime = DateTime.Now;

            var isExist = DbContext.Departments.AsNoTracking().Any(x => x.IsDeleted == false && x.DepartmentName.ToLower() == model.DepartmentName.ToLower() && x.Id != model.Id);
            if (isExist) return BadRequest($"{model.DepartmentName} already exist. Please try with diffrent one");


            DbContext.Entry(model).State = EntityState.Modified;
            DbContext.SaveChanges();

            return Ok(model.Id);
        }



        public IHttpActionResult Delete(string id)
        {
            var department = DbContext.Departments.Find(id);

            if (department == null) return BadRequest("Entry not found!");

            DbContext.Departments.Remove(department);
            var saveChanges = DbContext.SaveChanges() > 0;

            return Ok(saveChanges);
        }
    }
}