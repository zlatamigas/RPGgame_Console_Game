using System;

namespace RPGgame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ВВедите имя: ");
            string name = Console.ReadLine();
            Console.WriteLine("Выберете пол(м/ж): ");
            string gender = Console.ReadLine();
            Console.WriteLine("Выберете рассу:(человек(ч),эльф(э), орк(о), маг(м)) ");
            string rassa = Console.ReadLine();
            if (rassa == "м")
            {
                var hero = new MagicCharacter(name, gender, rassa);
                Console.WriteLine("Вывесли информацию о персонаже ?(да/нет)");
                string ans = Console.ReadLine();
                if (ans == "да")
                {
                    Console.WriteLine(hero.ToString());
                }
                Console.WriteLine("какое использовать заклиание (Добавить здоровье(+)\nВылечить(^)\nОживить(@)\nБроня(#)" +
                    "\nОтомри!(*)\nПротивоядие(%))");
                ans = Console.ReadLine();
                switch (ans)
                {
                    case "+":
                        Console.WriteLine("выполняется " + ans);
                        break;
                    case "^":
                        Console.WriteLine("выполняется " + ans);
                        break;
                    case "@":
                        Console.WriteLine("выполняется " + ans);
                        break;
                    case "#":
                        Console.WriteLine("выполняется " + ans);
                        break;
                    case "*":
                        Console.WriteLine("выполняется " + ans);
                        break;
                    default:
                        Console.WriteLine("нет такого заклианния");
                        break;
                }
            }
            else
            {
                var hero = new CharacterInfo(name, gender, rassa);
                Console.WriteLine("Вывесли информацию о персонаже ?(да/нет)");
                string ans = Console.ReadLine();
                if (ans == "да")
                {
                    Console.WriteLine(hero.ToString());
                }
            }
        }
    }
}
