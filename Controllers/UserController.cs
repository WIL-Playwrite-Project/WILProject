using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcDemo.Models;
using PlayMvcDemowriteWeb.Utils;

namespace MvcDemo.Controllers
{
    public class User : Controller
    {
       
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
       public async Task<IActionResult> Login(LoginViewModel lvm)
       {

           try{

           UserUtil au = new UserUtil();
          
          if(await au.validateUser(lvm))
          {
              String role = UserUtil.getRole();
              HttpContext.Session.SetString("UserRole", role);   //sets the user role session to the user's role
              return RedirectToAction("Index", "Home");
          }
          else
          {
            ViewBag.Error="Invalid Login Details";
            return View();
          }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return RedirectToAction("Index", "Home");
        }

       }

        [HttpGet]
        public ActionResult Logout()
        {
            
            HttpContext.Session.Clear();        //clears the session 
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult AddUser()
        {
            ViewData["Roles"] = getRoles();
            return View();
              
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(PwUser inUser, String RoleType)
        {
                try{

                    inUser.role = RoleType;
                    Console.WriteLine(inUser.email + inUser.fName+inUser.lName+inUser.password+inUser.role);

                    if(!inUser.email.Equals("")||!inUser.password.Equals("")||!inUser.fName.Equals("")||!inUser.lName.Equals("")||!inUser.role.Equals(""))  //makes sure none of the fields are empty
                    {
                        inUser.role = RoleType;
                        UserUtil au = new UserUtil();
                        

                            if(await au.addUser(inUser))         //if the user is added successfully
                            {

                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ViewData["Roles"] = getRoles();
                                ViewBag.Error="Error adding user. Please try again later.";
                                return View();
                        }
                    }

                    else
                    {
                        ViewData["Roles"] = getRoles();
                        ViewBag.Error="Please ensure that all the fields have been filled in.";
                        return View();
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return RedirectToAction("Index", "Home");
                }

            
        }


         public List<SelectListItem> getRoles() //gets list of roles for employees
        {
            List<SelectListItem> roleItems = new List<SelectListItem>();
            roleItems.Add(new SelectListItem { Value = "General", Text ="General"});
            roleItems.Add(new SelectListItem { Value = "Admin", Text ="Admin"});
            
            
            return roleItems;
        }

        

    }
}
