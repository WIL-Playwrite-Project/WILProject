using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using MvcDemo.Models;
using Firebase.Database.Query;

namespace MvcDemo.Utils
{
    public class StorageUtil
    {
        
        String fbStorage = "playwrite-20733.appspot.com";     //link to the firebase storage which stores all the images
        String fbDatabase = "https://playwrite-20733-default-rtdb.europe-west1.firebasedatabase.app/";   //link to the firebase realtime db which stores the system data

      

        //method gets an array of Image objects
        public  async Task<List<String>> fetchImageUrls()
        {
         
            List<String> imageUrls = new List<String>();
            var firebaseClient = new FirebaseClient(fbDatabase);       //creates a firebase client object used to get data from the realtime database 

             var images = await  firebaseClient      //gets the Image object from the db which contains the list of imageUrl objects 
                  .Child("Gallery")
                  .OnceAsync<Image>();
            
                foreach(var image in images)
                  {

                        imageUrls.Add( image.Object.imageUrl);
                    
                  }

                return imageUrls;
            
        }

        public async void uploadImageUrl(Image image)
      {
          var firebaseClient = new FirebaseClient(fbDatabase);       //creates a firebase client object used to get data from the realtime database 

          var result = await firebaseClient.Child("Gallery").PostAsync(image);
      }


    }
}