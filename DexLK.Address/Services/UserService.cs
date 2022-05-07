using System;
using Microsoft.Extensions.Options;
using DexLK.Address.Helpers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DexLK.Address.Services
{
    public interface IUserService
    {
        string _token { get; set; }

        Task<User> GetById(int id);
    }

    public class UserService : IUserService
    {
        public string _token { get; set; }

        public AppSettings _appSettings { get; set; }


        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public async Task<User> GetById(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://host.docker.internal:49187/api/users/4");//$"{_appSettings.AuthBaseUrl}/{id}");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization =   new AuthenticationHeaderValue("Bearer", _token);
                var response = await client.GetAsync(id.ToString());
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Internal server Error");
                }
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<User>(content);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
