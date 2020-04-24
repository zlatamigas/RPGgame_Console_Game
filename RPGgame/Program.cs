using System;

namespace RPGgame
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите имя: ");
                string name = Console.ReadLine();
                if(name=="")
                    throw new ArgumentException("Empty name!");
                Console.WriteLine("Выберите пол(м/ж): ");
                string g = Console.ReadLine();
                CharacterInfo.Gender gender = CharacterInfo.Gender.male;
                if (g == "м")
                    gender = CharacterInfo.Gender.male;
                else
                    if (g == "ж")
                    gender = CharacterInfo.Gender.female;
                else
                    throw new ArgumentException("Unknown gender!");
                Console.WriteLine("Выберете рассу:(человек(ч),эльф(э), орк(о), маг(м)) ");
                string r = Console.ReadLine();
                CharacterInfo.Race rassa = CharacterInfo.Race.human;

                switch (r)
                {
                    case "э":
                        rassa = CharacterInfo.Race.elf;
                        break;
                    case "ч":
                        rassa = CharacterInfo.Race.human;
                        break;
                    case "о":
                        rassa = CharacterInfo.Race.ork;
                        break;
                    case "м":
                        rassa = CharacterInfo.Race.wizard;
                        break;
                    default:
                        throw new ArgumentException("Unknown race!");
                }

                if (rassa == CharacterInfo.Race.wizard)
                {
                    var hero = new MagicCharacter(name, gender, rassa);
                    Console.WriteLine("Вывести информацию о персонаже ?(да/нет)");
                    string ans = Console.ReadLine();
                    if (ans == "да")
                    {
                        Console.WriteLine(hero.ToString());
                    }
                    Console.WriteLine("какое использовать заклиание \n(Добавить здоровье(+)\nВылечить(^)\nОживить(@)\nБроня(#)" +
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
                    Console.WriteLine("Вывеслти информацию о персонаже ?(да/нет)");
                    string ans = Console.ReadLine();
                    if (ans == "да")
                    {
                        Console.WriteLine(hero.ToString());
                    }
                }
            }
            catch (ArgumentException ag) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ag.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
