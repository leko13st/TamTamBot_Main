using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TamTamBotAPI
{
    class SenderClass
    {
        //Поля класса
        HttpClient client = new HttpClient();

        string token { get; set; }
        string id_chat { get; set; }
        string message { get; set; }

        public int answer { get; set; }

        public SenderClass(string token, string id_chat, string message)
        {
            this.token = token;
            this.id_chat = id_chat;
            this.message = message;
        }

        //Метод отправки сообщения
        public async Task Post()
        {
            Product mes = new Product(message); //Создание объекта с сообщением

            client.BaseAddress = new Uri("https://botapi.tamtam.chat"); //Определение хоста
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")); //Определение формата передачи данных

            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(
                    "/messages?access_token=" + token + "&chat_id=" + id_chat, mes); //Отправка данных в формате JSON
                response.EnsureSuccessStatusCode(); //Метод, вызывающий исключение при коде ошибки
                answer = 0;
            }
            catch { answer = 1; }
        }
    }
}
