using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using App.Models;
using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;
using App.Pages;
using Rg.Plugins.Popup.Services;
using FreshMvvm.Popups;
using App.Services;

namespace App.PageModels
{
    public class UserListPageModel : FreshMvvm.FreshBasePageModel
    {
        
        WebUser webUser = new WebUser();
        Task<User> task;
        public ObservableCollection<User> Users { get; set; }
        List<User> UsersCopy;
        public override void Init(object initData)
        {
            base.Init(initData);
            if (initData is ObservableCollection<User> user)
            {
                Users = new ObservableCollection<User>(user);
                UsersCopy = new List<User>(Users).ToList();
            }
        }               
        
        User selectedUser;
        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {                
                {
                    if (value != selectedUser)
                    {
                        selectedUser = value;
                        ShowDetailsCommandExecute();
                    }
                }
            }
        }    
        
        string _searchUser;
        public string SearchUser
        {
            get { return _searchUser; }
            set
            {
                _searchUser = value;
                SearchUserCommandExecute();
            }
        }
        
        private async void ShowDetailsCommandExecute()
        {
            try
            {
                task = webUser.GetData(SelectedUser.Id);
                var tmp = await task;
                await CoreMethods.PushPopupPageModel<MyPopupPageModel>(tmp);
            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Błąd", "Aplikacja wymaga dostępu do internetu", "Ok");
            }
        }
        private void SearchUserCommandExecute()
        {
            
            if (UsersCopy != null && UsersCopy.Count > 0)
            {
                var temp = UsersCopy.Where(x => x.FirstName.ToLower().Contains(SearchUser.ToLower()) || x.LastName.ToLower().Contains(SearchUser));
                List<User> newList = new List<User>();              
                Users.Clear();
                foreach(User item in temp)
                {
                    Users.Add(item);
                }                
            }
        }
    }
} 
