using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Firebase.Storage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcDemo.Models;
using MvcDemo.Utils;
namespace MvcDemo.Controllers
{
    public class DevelopmentController : Controller
    {
        private IHostingEnvironment Environment;
 
         public DevelopmentController(IHostingEnvironment _environment)
         {
           Environment = _environment;
         }



        [HttpGet]
      public  async Task<IActionResult> AgeCategories()  //displays the different age groups 
      {

        try{

          DevelopmentUtil du = new DevelopmentUtil();

          List<Development> developments = await du.getCategories();   //gets the list of age groups from the util class

          return View(developments);   //passes the list to the view
        }

        catch(Exception ex)
        {
          Console.WriteLine(ex.Message);
          return RedirectToAction("Index", "Home");
        }

      }

      [HttpGet]
      public async Task<IActionResult> AgeCatPhase(String id)      //displays the view with the different milestones to the user
      {
        
        try{
               DevelopmentUtil du = new DevelopmentUtil();
              List<Phase> milestones = await du.getCatPhase(id);   //gets the milestones with selected category

              ViewBag.CatId = id;
              return View(milestones);      //passes list of milestones to view

        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return RedirectToAction("Index", "Home");
        }
        
      }

      [HttpPost]
      public async Task<IActionResult> AddCategory(String ageCat)    //add a category heading
      {

          try{
            DevelopmentUtil du = new DevelopmentUtil();
            Development dev = new Development();
            dev.category = ageCat;

            bool success = await du.addCategory(dev);         //returns a bool of whether the category was added

            return RedirectToAction("AgeCategories", "Development");

        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return RedirectToAction("Index", "Home");
        }
        
      }


       [HttpGet]
      public IActionResult AddCatPhase(String id)       // displays view to add a phase in for a category
      {
       
       try{

        ViewBag.CatId = id;
        return View();

        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return RedirectToAction("Index", "Home");
        }

        
      }

        [HttpPost]
      public async Task<IActionResult> AddCatPhase(MilestoneViewModel mvm, List<IFormFile> postedFiles)  //adds the phase 
      {

          try{
              ViewBag.CatId = mvm.category;
          
              if(ModelState.IsValid)
                {
                      String downloadString = "";
                      DevelopmentUtil du = new DevelopmentUtil();
                      
                      if(postedFiles!= null && postedFiles.Count>0)   //if the user has selected media 
                      {
                        downloadString =  await du.pushPhaseImage(Environment, mvm,postedFiles);  // push the image and get the download url
                      }

                        du.pushPhase(mvm,downloadString);    //push the actual phase object
                        return RedirectToAction("AgeCategories");
                }

              else
                {
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
      public async Task<IActionResult> DeleteCatPhase(String id)
      {

        try{

            DevelopmentUtil du = new DevelopmentUtil();
            du.deleteCatPhase(id);                 //delete a phase from the category based on the id (which is the index)
           
            return RedirectToAction("AgeCategories");
       
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return RedirectToAction("Index", "Home");
        }

           
      }

       [HttpGet]
      public async Task<IActionResult> AgeCatActivities(String id)     //displays the ativities for an age group
      {

        try{

          ViewBag.CatId = id;
          DevelopmentUtil dUtil = new DevelopmentUtil();
          List<Activity> activities = await dUtil.getActivities(id); //gets activities for age group (which is the id passed in)

          return View(activities);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return RedirectToAction("Index", "Home");
        }
         
      }


       [HttpGet]
      public IActionResult AddCatActivity(String id)  //returns view to add an activity
      {
            try{

           ViewBag.CatId = id;
           return View();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return RedirectToAction("Index", "Home");
        }
          
      }


       [HttpPost]
      public async Task<IActionResult> AddCatActivity(Activity act, List<IFormFile> postedFiles) // add an activity for a specific age group
      {


          try{


            ViewBag.CatId = act.category; //viewbags are used to display the age category on the view
         
             if(ModelState.IsValid)
              {
                    String downloadString = "";
                    DevelopmentUtil du = new DevelopmentUtil();
                    
                    if(postedFiles!= null && postedFiles.Count>0)        //if the user has selected media
                    {
                       downloadString =  await du.pushActMedia(Environment, postedFiles);   // get the download url after pushing the image
                    }

                      du.pushActivity(act,downloadString);  //push the actual object
                      return RedirectToAction("AgeCatActivities", new {@id=ViewBag.CatId});
              }

             else
              {
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
      public async Task<IActionResult> DeleteCatActivity(String cat, String title,String tips,String media)  //delete a particular activity for an age group
      {

            try{

              Activity act = new Activity{
              category = cat,
              title = title,
              tips = tips,
              mediaUrl = media
            };                            //create a new activity

            DevelopmentUtil du = new DevelopmentUtil();
            du.deleteCatActivity(act);          
           
            return RedirectToAction("AgeCategories");
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return RedirectToAction("Index", "Home");
        }
            
      }




        

    }
}
