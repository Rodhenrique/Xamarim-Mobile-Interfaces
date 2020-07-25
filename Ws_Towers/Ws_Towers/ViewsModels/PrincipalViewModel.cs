using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Ws_Towers.Models;

namespace Ws_Towers.ViewsModels
{
    public class PrincipalViewModel : BaseViewModel
    {
        private List<Eventos> _Eventos;
        public List<Eventos> eventos
        {
            get { return _Eventos; }
            set
            {
                _Eventos = value;
                OnPropertyChanged();
            }
        }
        public ICommand btnAdicionarCommand { get; set; }


        public PrincipalViewModel()
        {
            eventos = new List<Eventos>();

            getJogos();
        }

        private void getJogos()
        {
            try
            {
                HttpClient client = ServiceConect.getClient;

                HttpResponseMessage response = client.GetAsync("Jogo/Principal").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    eventos = JsonConvert.DeserializeObject<List<Eventos>>(json);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
