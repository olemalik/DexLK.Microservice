using System;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens; 
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text; 
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using DexLK.Product.Helpers;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace DexLK.Product.Services
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
                client.BaseAddress = new Uri($"{_appSettings.AuthBaseUrl}/{id}");
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
            catch
            {
                return null;
            } 
        } 
    } 
}
