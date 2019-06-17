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
            try
            {
                //Получаем переменные из командной строки для нашего процесса
                String[] arguments = Environment.GetCommandLineArgs();
                //присвеиваем определённые параметры определённым переменным
                string token = arguments[1];
                string id_chat = arguments[2];
                string message = arguments[3];
                //Создаём класс для отправки сообщений
                SenderClass send = new SenderClass(token, id_chat, message);
                send.Post().GetAwaiter().GetResult();
                //Проверяем отправили ли сообщение и выводим результат на экран
                string ans = null;
                ans = "Code: " + send.answer + " Message: ";
                if (send.answer == 0) ans += "Ok";
                else ans = "1";
                Console.WriteLine(ans);
            }
            catch
            {
                Console.WriteLine("1");
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
