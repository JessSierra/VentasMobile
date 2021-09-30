using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using VentasMobile.Models;

namespace VentasMobile.Services
{
   public class ApiService
    {
       
        

        public HttpClient client { get; }
        public dynamic ContentResult { get; set; }
        public ICollection<ErrorLog> Errors { get; set; }
        public bool Status { get; set; }
        public string StatusCode { get; set; }
        public HttpResponseMessage Result { get; set; }
        // clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        //  HttpClient client = new HttpClient(clientHandler);
        public ApiService()
        {
            Errors = new List<ErrorLog>();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            client = new HttpClient(clientHandler);
            client.BaseAddress = new Uri(String.Format(Constants.BaseAddressApi));
        }
        public async Task<bool> Get(string url)
        {
            try
            {
                Result = await client.GetAsync(url);

                if (!Result.IsSuccessStatusCode)
                {
                    ContentResult = await Result.Content.ReadAsStringAsync();
                    Status = false;
                }
                else
                {
                    Status = true;
                    NoLog();
                }
            }
            catch (HttpRequestException e)
            {
                NoLog();
                Status = false;
                string mesagge = e.InnerException.Message;
                return false;
            }

            return true;
        }

        public async Task<bool> Post(string url, string json)
        {
            try
            {
                var Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                Result = await client.PostAsync(url, Content);


                Result = await client.PostAsync(url, Content);
                if (!Result.IsSuccessStatusCode)
                {
                    string result = await Result.Content.ReadAsStringAsync();
                    Status = false;
                    LoadLog(result);
                }
                else
                {
                    ContentResult = await Result.Content.ReadAsStringAsync();
                    Status = true;
                    NoLog();
                }

            }
            catch (HttpRequestException e)
            {
                NoLog();
                Status = false;
                string mesagge = e.InnerException.Message;
                return false;
            }

            return true;
        }
        private void LoadLog(string _Log)
        {
            try
            {
                if (!String.IsNullOrEmpty(_Log))
                {
                    ErrorLog lg = new ErrorLog();
                    lg = JsonConvert.DeserializeObject<ErrorLog>(_Log);
                    Errors.Add(lg);

                }
                else
                {
                    ErrorLog lg = new ErrorLog();
                    lg.Key = "-1";
                    lg.Value = "-1";

                    Errors.Add(lg);
                }
            }
            catch (Exception ex)
            {
                ErrorLog lg = new ErrorLog();
                lg.Key = "-1";
                lg.Value = "-1";

                Errors.Add(lg);
            }


        }

        public void NoLog()
        {
            ErrorLog aux = new ErrorLog();
            aux.Key = "None";
            aux.Value = "None";
            Errors.Add(aux);

            Status = true;
        }
    }
}
