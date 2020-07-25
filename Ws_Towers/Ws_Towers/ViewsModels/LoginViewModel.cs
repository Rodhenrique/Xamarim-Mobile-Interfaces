using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Ws_Towers.Models;
using Xamarin.Forms;

namespace Ws_Towers.ViewsModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string email { get; set; }
        public string senha { get; set; }
        public ICommand btnLoginCommand { get; set; }

        public LoginViewModel()
        {
            btnLoginCommand = new Command(login);
        }

        public void login()
        {
            
                HttpClient client = ServiceConect.getClient;

                Login login = new Login
                {
                    email = this.email,
                    senha = this.senha
                };

                string objectSerialized = JsonConvert.SerializeObject(login);

                StringContent content = new StringContent(objectSerialized, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync("Usuario/Login", content).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    Token token = JsonConvert.DeserializeObject<Token>(json);
                    MessagingCenter.Send<string>("", "SucessoLogin");
                }
                else if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    MessagingCenter.Send<String>("Usuário não encontrado", "ErroLogin");
                }
                else
                {
                    MessagingCenter.Send<String>($"Erro no servidor: StatusCode = {response.StatusCode.ToString()}", "ErroLogin");
                }
            
        }

        private class Token
        {
            public string token { get; set; }
        }
    }
}
