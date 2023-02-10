using AF.ECommerce.Domain.Entities;
using AF.ECommerce.Domain.Validadores.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AF.ECommerce.Domain.Validadores.Classe
{

    public class Cep : ICep
    {
        public async Task<Cliente> ValidarCep(string cep)
        {
            //https://viacep.com.br/ws/08253500/json/
            var url = $"https://viacep.com.br/ws/{cep}/json/";

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);

            var content = await response.Content.ReadAsStringAsync();

            var cepVerificado = JsonConvert.DeserializeObject<Cliente>(content);



            return cepVerificado;
        }
    }
}
