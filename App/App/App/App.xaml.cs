using App.Pages;
using App.PageModels;
using FreshMvvm;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace App
{
    public partial class App : Application
    {
        public App()
        {           
            var page = FreshPageModelResolver.ResolvePageModel<FirstPageModel>();
            var basicNavContainer = new FreshNavigationContainer(page);
            MainPage = basicNavContainer;          
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
