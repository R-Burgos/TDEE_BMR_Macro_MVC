using Microsoft.AspNetCore.Mvc;
using TDEE_BMR_Macro_MVC.Models;

namespace TDEE_BMR_Macro_MVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserCalculatedInfo(UserModel userModel) 
        {
            CalculationsModel cal = new CalculationsModel();
            cal.GetApiTDEE(userModel);
            cal.GetApiBMR(userModel);



            return View("UserCalculatedInfo", userModel);
        }
    }
}
