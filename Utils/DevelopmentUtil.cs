using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using MvcDemo.Models;
using Firebase.Database.Query;
using System.IO;
using Microsoft.AspNetCore.Http;
using Firebase.Storage;
using Microsoft.AspNetCore.Hosting;
using System.Linq;

namespace MvcDemo.Utils
{
    public class DevelopmentUtil
    {
        
        String fbStorage = "playwrite-20733.appspot.com";     //link to the firebase storage which stores all the images
        String fbDatabase = "https://playwrite-20733-default-rtdb.europe-west1.firebasedatabase.app/";   //link to the firebase realtime db which stores the system data

        //method gets an array of Image objects

        static String currKey="";
        static List<Activity> activitiesLst = new List<Activity>();

        public  async Task<List<Development>> getCategories()
        {

         List<Development> lstDev = new List<Development>();
        
          var firebaseClient = new FirebaseClient(fbDatabase); 

            var developments = await  firebaseClient      //gets the Image object from the db which contains the list of imageUrl objects 
                  .Child("Development")
                  .OnceAsync<Development>();
            

            foreach(var dev in developments)
            {
               lstDev.Add(new Development{ 
                            category = dev.Object.category,
                            catMilestones = dev.Object.catMilestones           
                        });
            }


            List<Development> months = lstDev.Where(d => d.category.Contains("Months")).ToList();
             months= orderList(months);   //gets list of ordered development objects
            List<Development> years = lstDev.Where(d => d.category.Contains("Years")).ToList().OrderBy(l =>l.category).ToList();
            years =orderList(years);     //gets list of ordered development objects
            
            lstDev = months.Concat(years).ToList();

          return lstDev;
        }


        //developments are ordered to ensure that the categories containing 'year' are after 'months'
        public List<Development> orderList(List<Development> devLst)   //orders the development categories
        {
            List<Development> sorted = new List<Development>();
            Dictionary<int, Development> dDev = new Dictionary<int, Development>();
            
            int key=0;
            foreach(Development dev in devLst)
            {
                key = Convert.ToInt32(dev.category.Substring(0, dev.category.IndexOf('-')));   //the first age in the category is the number that the list will be ordered by 
                dDev.Add(key, dev);

            }
            
            foreach (var item in dDev.OrderBy(x => x.Key))  //foreach ordered item in the doctionary
               {
                   sorted.Add(item.Value);  //add to the list of sorted devs
               }

          return sorted;
        }

        public async Task<bool> addCategory(Development dev)  //add Category
      {
            bool added=false;
            try{
                 var firebaseClient = new FirebaseClient(fbDatabase); 

            var result = await firebaseClient.Child("Development").PostAsync(dev);  //posts new category to firebase

            added=true;
            }

            catch(Exception ex)
            {
                added = false;
            }

            return added;
           
      }


      //gets the different milestones for each phase
      public async Task<List<Phase>> getCatPhase(String cat)
        {
          List<Phase> phases = new List<Phase>();

          Development devObj = new Development();
        
          var firebaseClient = new FirebaseClient(fbDatabase); 

            var developments = await  firebaseClient      //gets the Image object from the db which contains the list of imageUrl objects 
                  .Child("Development")
                  .OnceAsync<Development>();
            
          
            foreach(var dev in developments)
            {
              if(dev.Object.category.Equals(cat))      //if the development in the list has the category passed in
              {

                devObj = new Development{ 
                            category = dev.Object.category,
                            catMilestones = dev.Object.catMilestones          
                        };

                        currKey = dev.Key; 

                return devObj.catMilestones;

              }
            }

          return phases;
        }


        public async Task<String> pushPhaseImage(IHostingEnvironment Environment,MilestoneViewModel mvm, List<IFormFile> postedFiles)
        {
                // string wwwPath = Environment.WebRootPath;
                //  string contentPath = Environment.ContentRootPath;
          
                  string path = Path.Combine(Environment.WebRootPath, "Uploads");
                  if (!Directory.Exists(path))
                  {
                      Directory.CreateDirectory(path);
                  }

                  String downloadString="";
                  List<string> uploadedFiles = new List<string>();

                  IFormFile file= postedFiles[0];
                  string fileName = Path.GetFileName(file.FileName);
          
                    var ms = new MemoryStream();
                     file.CopyTo(ms);
                    Stream s = file.OpenReadStream();
                     // construct FirebaseStorage with path to where to upload the file and put it there
                    var task = new FirebaseStorage("playwrite-20733.appspot.com")
                        .Child("Images")
                        .Child("Development")
                        .Child(fileName)
                        .PutAsync(s);
 
                        // await the task to wait until upload is completed and get the download url
                      downloadString = await task;
                      DevelopmentUtil du = new DevelopmentUtil();
                     
                      s.Close();
                      return downloadString;
        }

        public async Task<String> pushActMedia(IHostingEnvironment Environment, List<IFormFile> postedFiles)
        {
                   //string wwwPath = Environment.WebRootPath;
                   //string contentPath = Environment.ContentRootPath;
          
                  string path = Path.Combine(Environment.WebRootPath, "Uploads");
                  if (!Directory.Exists(path))
                  {
                      Directory.CreateDirectory(path);
                  }

                  String downloadString="";
                  List<string> uploadedFiles = new List<string>();

                  IFormFile file= postedFiles[0];
                  string fileName = Path.GetFileName(file.FileName);
          
                    var ms = new MemoryStream();
                     file.CopyTo(ms);
                    Stream s = file.OpenReadStream();
                     // construct FirebaseStorage with path to where you want to upload the file and put it there
                    var task = new FirebaseStorage("playwrite-20733.appspot.com")
                        .Child("Images")
                        .Child("Activities")
                        .Child(fileName)
                        .PutAsync(s);
 
                        // await the task to wait until upload is completed and get the download url
                      downloadString = await task;

                      s.Close();
                      return downloadString;
        }


         public async void pushPhase(MilestoneViewModel mvm, String imageUrl) //pushes phase object
      {

          String catId = mvm.category;
          String milestone = mvm.milestones;
          List<String> lstMilestones = milestone.Split("-").ToList();
          lstMilestones.RemoveAt(0);

           String warnings = mvm.warnings;
           List<String> lstWarnings = warnings.Split("-").ToList();
           lstWarnings.RemoveAt(0);
           

           Phase milestone1 = new Phase();
           milestone1.title = mvm.title;
           milestone1.milestones = lstMilestones;
           milestone1.warnings = lstWarnings;
           milestone1.tips = mvm.tips;
           milestone1.imageUrl = imageUrl;
          

          List<Phase> phases = await getCatPhase(catId);
          if(phases == null)
          {
              phases = new List<Phase>();
          }
          phases.Add(milestone1);


          Development devObj = new Development();
        
          var firebaseClient = new FirebaseClient(fbDatabase); 

            var developments = await  firebaseClient     
                  .Child("Development")
                  .OnceAsync<Development>();
            

            String devId="";
            foreach(var dev in developments)          //used to get the key of the development category which equals the category of view model passed in
            { 

                if(dev.Object.category.Equals(catId))
                {
                  devId=dev.Key;
                  devObj = new Development{
                      category = dev.Object.category,
                      catMilestones = phases
                  };
                }

             
            }

             await firebaseClient.Child("Development").Child(devId).PutAsync(devObj);

    }


    public async void deleteCatPhase(String index) //delete phase
      {
          
          Development devObj = new Development();
        
          var firebaseClient = new FirebaseClient(fbDatabase); 

           var developments = await  firebaseClient.Child("Development").OnceAsync<Development>();
            
          
            foreach(var dev in developments)
            {

              if(dev.Key.Equals(currKey))            //gets the key of the development category that needs to be altered
              {
                 devObj = new Development{ 
                            category = dev.Object.category,
                            catMilestones = dev.Object.catMilestones          
                        };

                        currKey = dev.Key; 
              }
               
            }

            int inIndex = Convert.ToInt32(index);
            await firebaseClient.Child("Development").Child(currKey).DeleteAsync(); //deletes the old category

            devObj.catMilestones.RemoveAt(inIndex); 

           await firebaseClient.Child("Development").PostAsync(devObj); // pushes the category with the new list of phases
      }

      public  async Task<List<Activity>> fetchActivities(String catId)  //gets activities
        {

         List<Activity> lstAct = new List<Activity>();
        
          var firebaseClient = new FirebaseClient(fbDatabase); 

            var activities = await  firebaseClient     
                  .Child("Activities")
                  .OnceAsync<Activity>();
            

            foreach(var act in activities)
            {
               lstAct.Add(new Activity{ 
                          category = act.Object.category,
                          title = act.Object.title,
                          tips = act.Object.tips,
                          mediaUrl = act.Object.mediaUrl
                        });
            }

            lstAct = lstAct.Where(a => a.category.Equals(catId)).ToList();  //fillters the list to include activities with the same category as the one passed in

          return lstAct;
            
        }

         public async void pushActivity(Activity act, String inMediaUrl)
      {
            var firebaseClient = new FirebaseClient(fbDatabase); 
            act.mediaUrl = inMediaUrl;
            await firebaseClient.Child("Activity").Child(act.category).PostAsync(act);
      }


        //gets the different milestones for each phase
      public async Task<List<Activity>> getActivities(String cat)
        {
          List<Activity> lstAct = new List<Activity>();

          Activity actObj = new Activity();
        
          var firebaseClient = new FirebaseClient(fbDatabase); 

            var activities = await  firebaseClient      //gets the Image object from the db which contains the list of imageUrl objects 
                  .Child("Activity").Child(cat)
                  .OnceAsync<Activity>();
            
          
            foreach(var a in activities)
            {
              if(a.Object.category.Equals(cat))
              {

                actObj = new Activity{ 
                            category = a.Object.category,
                            title = a.Object.title,
                            tips = a.Object.tips,
                            mediaUrl = a.Object.mediaUrl
                        };

                lstAct.Add(actObj);   
                 
              }
            }

          activitiesLst = lstAct;
          return lstAct;
        }


         public async void deleteCatActivity(Activity act) //delete activity
      {
          
          var firebaseClient = new FirebaseClient(fbDatabase); 
          String key = "";
          String editedUrl="";

             var activities = await  firebaseClient      
                  .Child("Activity").Child(act.category)
                  .OnceAsync<Activity>();
            
            foreach(var a in activities)
            {
              
              
              string str = a.Object.mediaUrl.Replace("$2F", "%2F") ;
              Console.WriteLine(act.mediaUrl);
              Console.WriteLine(str);
              if(a.Object.title.Equals(act.title) && a.Object.tips.Equals(act.tips) && a.Object.mediaUrl.Equals(str))
              {
                key = a.Key;
                Console.WriteLine(key);
              }
              
            }

            if(key!=null)
            {
                  await firebaseClient.Child("Activity").Child(act.category).Child(key).DeleteAsync();
            }

      }





    }
}