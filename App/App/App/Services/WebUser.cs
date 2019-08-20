using App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace App.Services
{
    public class WebUser
    {
        private User SelectedUser;
        private UserData Data;
        private UserList List;

        string json = "";
        public async Task<User> GetData(int id)
        { 
            string uri = "https://internshiptaskuserslist.azurewebsites.net/api/users/" + id + "?code=9XuCxWZqJavOAWHPcWD/97mMeJkK0mSVMA9A6MQ9n4R1B/6fpsxGqw==";
            var request = HttpWebRequest.CreateHttp(uri);
            request.Method = WebRequestMethods.Http.Get;
            request.ContentType = "application/json; charset=utf-8";
            await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null).ContinueWith(task =>
            {
                var response = (HttpWebResponse)task.Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader responseReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    string responseData = responseReader.ReadToEnd();
                    json = responseData.ToString();
                    responseReader.Close();
                    if (!String.IsNullOrEmpty(json))
                    {

                        Data = JsonConvert.DeserializeObject<UserData>(json);                    
                        SelectedUser = new User { FirstName = Data.Data.FirstName, LastName = Data.Data.LastName, Age = Data.Data.Age, City = Data.Data.City };                                              
                    }
                }
            });       
            return SelectedUser;
        }
        public async Task<UserList> GetUsers()
        {            
            var request = HttpWebRequest.CreateHttp("https://internshiptaskuserslist.azurewebsites.net/api/users?code=gbgu4CbgdAlsS0xIVaNkckK4vTd0qIFNxaQYzIHLaqyomquJwuy/ig==");
            request.Method = WebRequestMethods.Http.Get;
            request.ContentType = "application/json; charset=utf-8";
            await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null).ContinueWith(task =>
            {
                var response = (HttpWebResponse)task.Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader responseReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    string responseData = responseReader.ReadToEnd();
                    json = responseData.ToString();
                    responseReader.Close();
                    if (!String.IsNullOrEmpty(json))
                    {
                        List = JsonConvert.DeserializeObject<UserList>(json);                           
                    }
                } 
            });                 
            return List;
        }
    }
}
