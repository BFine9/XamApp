using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using App.Models;
using App.Services;
using FreshMvvm;
using Xamarin.Forms;

namespace App.PageModels
{
    public class FirstPageModel : FreshBasePageModel
    {
        public FirstPageModel()
        {
            task = webUser.GetUsers();
        }
        WebUser webUser = new WebUser();
        Task<UserList> task;

        ObservableCollection<User> Users;
        public Command ShowUsers => new Command(async () =>
        {
            try
            {
                if (task.IsFaulted) task = webUser.GetUsers();
                var tmp = await task;
                Users = new ObservableCollection<User>(tmp.Data);
                await CoreMethods.PushPageModel<UserListPageModel>(Users);
            }catch
            {
                await Application.Current.MainPage.DisplayAlert("Błąd", "Aplikacja wymaga dostępu do internetu", "Ok");
            }           
        });
    }
}
