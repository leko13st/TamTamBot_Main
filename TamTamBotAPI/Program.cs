using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamTamBotAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[Bot-Program for sending messages in the messanger TamTam]\r\n[Input data]:");

            bool exit = false;
            while (!exit)
            {
                //Входные данные
                Console.Write("Token: ");
                string token = Console.ReadLine();
                Console.Write("Id_chat: ");
                string id_chat = Console.ReadLine();
                Console.Write("Message: ");
                string message = Console.ReadLine();
                
                //Создание класса для отправки сообщения
                SenderClass send = new SenderClass(token, id_chat, message);
                send.Post().GetAwaiter().GetResult();

                //Вывод результата на экран
                string ans = null;
                ans = "Code: " + send.answer + " Message: ";
                if (send.answer == 0) ans += "Ok";
                else ans += "Error";

                Console.WriteLine(ans);

                //Запрос на повторную процедуру
                Console.WriteLine("\r\nRepeat? (y)/(n): ");
                string rep = null;
                while (rep != "y" && rep != "n")
                    rep = Console.ReadLine();

                if (rep == "n") exit = true;
            }
        }
    }
}
