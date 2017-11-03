using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Storage;
using Firebase;
using Firebase.Auth;
using PinSeed.Services;
using System.IO;
using System.Threading.Tasks;

namespace PinSeed.Droid.Services
{
    class FirebaseStorageService : IFirebaseStorageService

    {
        public Task GetRegisters()
        {
            throw new NotImplementedException();
        }

        public Task Register()
        {
            throw new NotImplementedException();
        }

        public  async Task SaveImage(Stream stream)
        {
            var task = new FirebaseOptions();
                   


            // Track progress of the upload
            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

           



        }
    }
}