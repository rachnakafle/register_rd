using Microsoft.AspNetCore.Mvc;
using Registration_RelationalDB.Helpers;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class RegisterController : Controller
    {
        private IConfiguration _config;
        CommonHelper _helper;

        public RegisterController(IConfiguration config)
        {
            _config = config;
            //_helper = helper;
            _helper = new CommonHelper(_config);
        }


        [HttpGet]
        public IActionResult Register()
        {
            //HttpContext context = HttpContext.Items["Rachana"];
            //HttpContext context = HttpContext.Session;
            //var data = HttpContext.Items["Rachana"];
            var data = HttpContext.Session.GetString("Rachana");
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel vm)
        {
            //string UserExistsQuery = $"Select * from [Table_2] where  UserName = '{vm.UserName}'" + $" OR Email = '{vm.Email}'";
            string UserExistsQuery = $"Select * from [RDB_Table] where  UserName = '{vm.UserName}'" + $" OR Email = '{vm.Email}'";
            bool userExists = _helper.UserAlreadyExists(UserExistsQuery);
            if (userExists == true)
            {
                ViewBag.Error = "UserName and Email Already Exists";
                return View("Register", vm);
            }

            //string Query = "Insert into [Table_2](UserName,Email,Password,Name," + $"ContactNumber,Address,RoleId)values('{vm.UserName}','{vm.Email}','{vm.Password}'" + $", '{vm.Name}', '{vm.ContactNumber}, '{vm.Address}', '{2}')";

            string Query = "Insert into [RDB_Table](UserName,Email,Password,Name," + $"ContactNumber,Address)values('{vm.UserName}','{vm.Email}','{vm.Password}'" + $",'{vm.Name}', '{vm.ContactNumber}', '{vm.Address}')";

            int result = _helper.DMLTransaction(Query);
            if (result > 0)
            {

                EntryIntoSession(vm.UserName);
                return RedirectToAction("Register", "Register");
                //return View();
            }
            return View();
        }

        private void EntryIntoSession(string UserName)
        {
            HttpContext.Session.SetString("Rachana", UserName);
           
        }
    }
}