using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

//Напишите программу, которая бы позволила вам по указанному 
//адресу web-страницы выбирать все ссылки на другие страницы,
//номера телефонов, почтовые адреса и сохраняла полученный результат в файл.


namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите адрес web-страницы");
            string url = Console.ReadLine();

            //Создаем web-запрос
            WebRequest web = WebRequest.Create(url);

            //Получаем ответ на web-запрос
            WebResponse response = web.GetResponse();

            //Выводим статус подключения
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            //Поток с данными ответа на web-запрос
            Stream stream = response.GetResponseStream();

            //Приводимся к классу StreamReader
            StreamReader reader = new StreamReader(stream);

            //Записываем данные в строку
            string siteresponse = reader.ReadToEnd();

            //Создаем переменную stringbilder
            StringBuilder stringBuilder = new StringBuilder();

            //Промежуточная строка
            string str;
            stringBuilder.Clear();
            reader.Close();

            //Открываем папку с файлом в который будем записывать файл
            string path = @"..\..\";
            string pathFile = path + "File.txt";
            Process.Start("explorer.exe", path);
            var file = new FileInfo(pathFile);

            //Поток для записи 
            StreamWriter writer = File.CreateText(pathFile);
            //href = "https://vk.com/anishchenko_zhenya" />
            //Регулярное выражение для ссылок для сайтов
            Regex link = new Regex(@"href=\s*("")(?<link>(http)\S+)("")\W*>");
            stringBuilder.Append("irl on site:\n");

            //Получить массив совпадений
            foreach (Match m in link.Matches(siteresponse))
            {
                str = (m.Groups["link"].ToString());
                //Console.WriteLine(str);
                stringBuilder.AppendFormat("{0}\n", str);
            }
            //Console.WriteLine(stringBuilder);
            //+375 29 602 - 53 - 33
            //Регулярное выражение для ссылок для телефонов белорусские телефоны
            Regex phone = new Regex(@"(?<phone>[+375\s]{5}[0-9]{2}[\s][0-9]{3}[\s\-]{1,}[0-9]{2}[\s\-]{1,}[0-9]{2})
|(?<phone>[+375\s]{5}[0-9]{2}[\s][0-9]{3}[\s\-]{1,}[0-9]{4})");
            stringBuilder.Append("Phone numbers:\n");
            foreach (Match m in phone.Matches(siteresponse))
            {
                //Console.WriteLine(m.Groups["phone"]);
                str = (m.Groups["phone"].ToString());
                //Console.WriteLine(str);
                stringBuilder.AppendFormat("{0}\n", str);
            }

            //Регулярное выражение для ссылок для имаилов
            Regex mail = new Regex(@"(?<mail>[0-9a-zA-Z!#$%&'*+/=?^_'{|}~-]{1,}@[A-Za-z0-9]{2,}[.]{1}[a-zA-Z]{2,})\W+");
            stringBuilder.Append("Imails on site:\n");
            foreach (Match m in mail.Matches(siteresponse))
            {
                //Console.WriteLine(m.Groups["mail"]);
                str = (m.Groups["mail"].ToString());
                //Console.WriteLine(str);
                stringBuilder.AppendFormat("{0}\n", str);
            }

            stringBuilder.Append('-', 20);
            //Console.WriteLine(stringBuilder);
            writer.Write(stringBuilder);
            stringBuilder.Clear();
            writer.Close();
            Console.WriteLine("Файл записан.");
            Console.ReadKey();
        }
    }
}
