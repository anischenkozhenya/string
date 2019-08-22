using System;
using System.Text.RegularExpressions;

//Напишите консольное приложение, позволяющие пользователю зарегистрироваться 
//под «Логином», состоящем только из символов латинского алфавита, и пароля,
//состоящего из цифр и символов.

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Регулярное выражение для пароля(буквы и цифры)
            Regex numberlit = new Regex(@"^[A-Za-z0-9\S]+$");

            //Регулярное выражение для Логина(буквы)
            Regex liter = new Regex(@"^[a-zA-Z]+$");

            //Переменная для выхода из цикла
            bool check = false;

            //Переменные для хранения логина и пароля
            string login;
            string password;

            do
            {
                Console.WriteLine("Введите логин(Только Символы латинскими буквами)");
                login = Console.ReadLine();
                if (liter.IsMatch(login))
                {
                    Console.WriteLine("Логин соответствует требованиям");
                    check = true;
                }
                else
                {
                    Console.WriteLine("НЕВЕРНЫЕ СИМВОЛЫ");
                }
            } while (check == false);
            do
            {
                Console.WriteLine("Введите пароль(Цифры и символы)");
                password = Console.ReadLine();
                if (numberlit.IsMatch(password))
                {
                    Console.WriteLine("Пароль соответствует требованиям");
                    check = false;
                }
                else
                {
                    Console.WriteLine("НЕВЕРНЫЕ СИМВОЛЫ");
                }
            } while (check == true);

            Console.WriteLine(string.Format(@"Принятый логин -'{0}'
Пароль         -'{1}'"
                                             , login, password));
            Console.WriteLine("Для выходы нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}

