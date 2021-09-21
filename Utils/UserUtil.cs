using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using MvcDemo.Models;
using Firebase.Auth;
using Firebase.Database.Query;

namespace PlayMvcDemowriteWeb.Utils
{
    public class UserUtil
    {
         String fbStorage = "playwrite-20733.appspot.com";     //link to the firebase storage which stores all the images
         String fbDatabase = "https://playwrite-20733-default-rtdb.europe-west1.firebasedatabase.app/";   //link to the firebase realtime db which stores the system data

         static PwUser currUser = new PwUser();

        //returns null if the user's details are invalid or returns the user's role
        public async Task<bool> validateUser(LoginViewModel lvm)
        {
            bool valid = false;

             try{

                String apiKey = "AIzaSyAzHxSvbXQDZupvQTDUBtNKsKdwJ8F3sE8";
                
                //creates a new firebase user with the given email and password
                var auth = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
                var ab  = await auth.SignInWithEmailAndPasswordAsync(lvm.email, lvm.password);
                var token = ab.FirebaseToken;
                var user = ab.User;
                var id = user.LocalId;
                

                  var firebaseClient = new FirebaseClient(fbDatabase); 
                
                //gets the correct user from the realtime database
                  var result = await  firebaseClient      
                  .Child("Users")
                  .Child(user.LocalId)
                  .OnceAsync<PwUser>();

            //sets the static user object 
           foreach(var inUser in result)
            {
              
                currUser = new PwUser
                       { 
                            email = inUser.Object.email,
                            password = inUser.Object.password,
                            fName = inUser.Object.fName,
                            lName = inUser.Object.lName,
                            role = inUser.Object.role

                        };

            }

            //returns whether the login details provided are correct
            valid = true;

          }
          catch(Exception ex)
          {
              //if the auth obj creation fails, return false
            valid = false;
            Console.WriteLine(ex.Message);
           
          }

            return valid;
        }

        //return the current user's role
        public static String getRole()
        {
            return currUser.role;
        }

    //adds user details to firebase and returns whether the adding was successful
        public async Task<bool> addUser(PwUser inUser)
        {

          String role = "";
          bool complete = false;

            try{

            String apiKey = "AIzaSyAzHxSvbXQDZupvQTDUBtNKsKdwJ8F3sE8";

            var auth = new FirebaseAuthProvider(new FirebaseConfig(apiKey));

            var ab  = await auth.CreateUserWithEmailAndPasswordAsync(inUser.email, inUser.password);
            var token = ab.FirebaseToken;
            var user = ab.User;
            var id = user.LocalId;

             var firebaseClient = new FirebaseClient(fbDatabase); 
             var result = await firebaseClient.Child("Users").Child(id+"").PostAsync(inUser);

            role = inUser.role;
            complete = true;
            
            }
            catch(Exception ex )
            {
                Console.WriteLine(ex.Message);
                role = "";
                complete = false;

            }
          
          return complete;
        }

        

    }

}