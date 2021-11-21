using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Firebase.Storage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcDemo.Models;
using MvcDemo.Utils;

namespace MvcDemo.Controllers
{
    public class HomeController : Controller
    {

         private IHostingEnvironment Environment;
 
         public HomeController(IHostingEnvironment _environment)
         {
           Environment = _environment;
         }
       
       [HttpGet]
        public IActionResult Index()   //Home page
        {
            return View();
        }


         [HttpGet]
        public async Task<IActionResult> Gallery()
        {
            try{

                StorageUtil su = new StorageUtil();
                List<String> imageUrls  = await su.fetchImageUrls();      //gets list of image urls from util class
                ViewBag.Urls= imageUrls;
                
                ViewBag.Error = TempData["Error"]+"";
                return View(imageUrls);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return RedirectToAction("Index", "Home");
        }
            
        }

        [HttpPost]
        public async Task<IActionResult> AddImages(List<IFormFile> postedFiles)
        {

            if(postedFiles!=null && postedFiles.Count>0)
            {
                 try 
                    {
                            string wwwPath = this.Environment.WebRootPath;
                            string contentPath = this.Environment.ContentRootPath;
                    
                            string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }
                            foreach (IFormFile postedFile in postedFiles)
                            {
                                String ext = postedFile.FileName;

                            if(ext.Contains("JPEG")|| ext.Contains("JPG")||ext.Contains("PNG")|| ext.Contains("jpeg"))
                            {
                                
                                string fileName = Path.GetFileName(postedFile.FileName);
                                var ms = new MemoryStream();
                                    postedFile.CopyTo(ms);
                                    Stream s = postedFile.OpenReadStream();

                                    // Construct FirebaseStorage with path to where you want to upload the file and put it there
                                        var task = new FirebaseStorage("playwrite-20733.appspot.com")
                                            .Child("Images")
                                            .Child("Gallery")
                                            .Child(fileName)
                                            .PutAsync(s);
                    
                                            // Await the task to wait until upload is completed and get the download url
                                            var downloadUrl = await task;

                                            Image image = new Image{
                                            imageUrl = downloadUrl};
                                    
                                    StorageUtil su = new StorageUtil();
                                    su.uploadImageUrl(image);
                                    return RedirectToAction("Gallery", "Home");
                            }

                            else{
                                TempData["Error"] ="Please select images only.";
                                
                                return RedirectToAction("Gallery", "Home");
                            }
                            

                            }

                    
                   
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        TempData["Error"] ="An error occurred when uploading your images. Please try again later.";
                        
                        return RedirectToAction("Gallery", "Home");
                    }

            return RedirectToAction("Gallery", "Home");
            }

            else
            {
                TempData["Error"] ="Please select the images to be uploaded";
                 return RedirectToAction("Gallery", "Home");
            }


           
        }




        

        

        [HttpGet]
        public IActionResult Contact() //contact us page
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Contact vm)
        {
            if(ModelState.IsValid)
            {
                try
                {
		
		   //(Lock, 2020)
                    MailMessage msz = new MailMessage();
                    msz.From = new MailAddress(vm.Email);//Email which you are getting from view
								
                    msz.To.Add("8towersolutions@gmail.com");//Where mail will be sent 
                    msz.Subject = vm.Subject;
                    msz.Body = "Request from: "+vm.Email+" - "+vm.Phone+"\n"+vm.Message; //format the body of the email to be sent
                    SmtpClient smtp = new SmtpClient();

                    smtp.Host = "smtp.gmail.com";

                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential
					("8towersolutions@gmail.com", "8Tower$olutions");

                    smtp.EnableSsl = true;

                    smtp.Send(msz);   //sends email

                    ModelState.Clear();
                    ViewBag.Message = "Thank you for contacting us.";  //message displayed to the user on successfully sending the email
                  
                }
                catch(Exception ex )
                {
                    ModelState.Clear();
                    ViewBag.Message = $" Sorry we are facing Problem here {ex.Message}"; // message displayed if there was an error in sending the email
                   
                }              
            }

          return View();
          
        }



        
       
    }
}

//Lock, M. 2020.How to send email in ASP.NET C#.[online] Available at: <https://stackoverflow.com/questions/18326738/how-to-send-email-in-asp-net-c-sharp>




