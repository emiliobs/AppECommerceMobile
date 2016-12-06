using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ECommerceMobile.Models;
using Newtonsoft.Json;

namespace ECommerceMobile.Services
{
    public class ApiService
    {
        public async Task<Response> Login(string email, string password)
        {
            try
            {
                var loginRequest = new LoginRequest()
                {
                    Email =  email,
                    Password = password
                };

                var resquest = JsonConvert.SerializeObject(loginRequest);
                var content = new StringContent(resquest, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                client.BaseAddress= new Uri("http://zulu-software.com");
                var url = "/ECommerce/api/Users/Login";

                var response = await client.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    return  new Response()
                    {
                        IsSuccess = false,
                        Message = "Usuario o Contraseña Incorrectos."
                    };
                }

                var result = await response.Content.ReadAsStringAsync();

                var user = JsonConvert.DeserializeObject<User>(result);

                return  new Response()
                {
                    IsSuccess = true,
                    Message = "Login OK.!",
                    Result = result

                };

            }
            catch (Exception ex)
            {

                return new Response()
                {

                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
