using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace PinSeed.Services
{
    public interface IFirebaseStorageService
    {

        Task SaveImage(Stream stream);

        Task Register();

        Task GetRegisters();

    }







}
