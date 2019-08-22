using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
//Создайте текстовый файл-чек по типу «Наименование товара – 0.00(цена) грн.» 
//с определенным количеством наименований товаров и датой совершения покупки.
//Выведите на экран информацию из чека в формате текущей локали пользователя и в формате локали
//en-US.

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\";
            CultureInfo mycul = CultureInfo.CurrentCulture;
            CultureInfo culture = new CultureInfo("eu-US");
            Console.WriteLine(mycul.Name);
            string str = File.ReadAllText(path+"Check.txt", Encoding.Default);
            string pattern = @"(?<day>[0-9]{2}).(?<mon>[0-9]{2}).(?<year>[0-9]{4})\s(?<hour>[0-9]{1,2}):(?<min>[0-9]{1,2}):(?<sec>[0-9]{1,2})\s""(?<name>[а-яА-Яa-zA-Z0-9.]*)""\s-\s(?<coast>[0-9,]*)\s(?<value>[а-яА-яa-zA-Z.])*";
            foreach (Match item in Regex.Matches(str, pattern))
            {
                double coast = Convert.ToDouble((item.Groups["coast"].Value));
                string moneyRU = coast.ToString("C", mycul);
                string moneyUS = coast.ToString("C", culture);
                DateTime time = new DateTime(Convert.ToInt32(item.Groups["year"].Value),
                Convert.ToInt32(item.Groups["mon"].Value), Convert.ToInt32(item.Groups["day"].Value), Convert.ToInt32(item.Groups["hour"].Value), Convert.ToInt32(item.Groups["min"].Value), Convert.ToInt32(item.Groups["sec"].Value));
                string timeru = time.ToString(mycul);
                string timeUS = time.ToString(culture);
                Console.WriteLine(string.Format("Ru------{0} Название товара:'{1}' Цена:{2}\n" +
                    "US------{3} Название товара:'{1}' Цена:{4}", timeru, item.Groups["name"], moneyRU, timeUS, moneyUS));
            }
            Console.WriteLine("Для выходы нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}
