using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

//Напишите шуточную программу «Дешифратор», которая 
//бы в текстовом файле могла бы заменить все предлоги на слово «ГАВ!».

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\";
            Process.Start("explorer.exe", path);
            string str = File.ReadAllText(path+"File.txt", Encoding.Default);
            Console.WriteLine(str);
            Console.WriteLine(new string('-', 20));
            string newstr = Regex.Replace(str, @"\W(в)\W|\W(от)\W|\W(на)\W|\W(у)\W|\W(за)\W|\W(с)\W|\W(под)\W|\W(над)\W", @" ГАВ! ");
            Console.WriteLine(newstr);
            File.WriteAllText(path+"NewFile.txt", newstr, Encoding.Default);
            Console.WriteLine("Для выхода нажмите любую кнопку...");
            Console.ReadKey();
        }
    }
}
