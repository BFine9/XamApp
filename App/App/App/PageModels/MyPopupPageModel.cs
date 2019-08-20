using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using App.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;

namespace App.PageModels
{
    public class MyPopupPageModel : FreshBasePageModel
    {
        public User UserData { get; set; } 
      
        public override void Init(object value)
        {
            base.Init(value);  
            if (value is User user)
            {                
                UserData = new User { FirstName = user.FirstName, LastName = user.LastName, City = user.City, Age = user.Age };
            }
        }
        public Command Close => new Command(
            async () =>
            {
                await PopupNavigation.Instance.PopAsync();
            });       
    }
}
