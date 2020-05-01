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
                Console.WriteLine("Вам на встречу идет против ник но у нас ничего нет ");
                Console.WriteLine("Что вы хотите сделать: \n");
                Console.WriteLine("1 - пополнить артифакты\n"+
                                  "2 - пополнить закинания\n" +
                                  "3 - посмотреть инвентарь\n" +
                                  "4 - посмотреть выученные заклинания\n" +
                                  "5 - Использовать артефакт\n" +
                                  "6 - Использовать заклинание\n" +
                                  "7 - текущая информация\n" +
                                  "0 - завершить игру\n");
                if (rassa == CharacterInfo.Race.wizard)
                {
                    var hero = new MagicCharacter(name, gender, rassa);
                    int otvet = int.Parse(Console.ReadLine());
                    switch (otvet)
                    {
                        case 1:
                            Console.WriteLine("какой артефакт вы хотите приобрести" +
                               "\nБутылка с живой водой(+)" +
                               "\nБутылка с мертвой водой(-)" +
                               "\nПосох «Молния»(@)" +
                               "\nДекокт из лягушачьих лапок(#)" +
                               "\nЯдовитая слюна(*)" +
                               "\nГлаз василиска(%)");
                            string ans2 = Console.ReadLine();
                            switch (ans2)
                            {
                                case "+":
                                    Console.WriteLine("выполняется " + ans2);
                                    break;
                                case "-":
                                    Console.WriteLine("выполняется " + ans2);
                                    break;
                                case "@":
                                    Console.WriteLine("выполняется " + ans2);
                                    break;
                                case "#":
                                    Console.WriteLine("выполняется " + ans2);
                                    break;
                                case "*":
                                    Console.WriteLine("выполняется " + ans2);
                                    break;
                                default:
                                    Console.WriteLine("нет такого заклианния");
                                    break;
                            }
                            break;
                        case 2:
                            Console.WriteLine("какое заклиание вы хотите пополнить" +
                               "\nДобавить здоровье(+)" +
                               "\nВылечить(^)" +
                               "\nОживить(@)" +
                               "\nБроня(#)" +
                               "\nОтомри!(*)" +
                               "\nПротивоядие(%)");
                            string ans1 = Console.ReadLine();
                            switch (ans1)
                            {
                                case "+":
                                    Console.WriteLine("выполняется " + ans1);
                                    break;
                                case "^":
                                    Console.WriteLine("выполняется " + ans1);
                                    break;
                                case "@":
                                    Console.WriteLine("выполняется " + ans1);
                                    break;
                                case "#":
                                    Console.WriteLine("выполняется " + ans1);
                                    break;
                                case "*":
                                    Console.WriteLine("выполняется " + ans1);
                                    break;
                                default:
                                    Console.WriteLine("нет такого заклианния");
                                    break;
                            }
                            break;
                        case 3:
                            if (hero.inventory.Count == 0)
                            {
                                Console.WriteLine("у вас пусто!");
                                break;
                            }
                            foreach(var x in hero.inventory)
                            {
                                Console.WriteLine($"{x}\n");//хочу что бы было типа так {х.Имя};
                            }
                            break;
                        case 4:
                            if (hero.learnedSpells.Count == 0)
                            {
                                Console.WriteLine("у вас пусто!");
                                break;
                            }
                            foreach (var x in hero.learnedSpells)
                            {
                                Console.WriteLine($"{x}\n");//хочу что бы было типа так {х.Имя};
                            }
                            break;
                        case 5:
                            Console.WriteLine("какой артефакт вы хотите приобрести" +
                               "\nБутылка с живой водой(+)" +
                               "\nБутылка с мертвой водой(-)" +
                               "\nПосох «Молния»(@)" +
                               "\nДекокт из лягушачьих лапок(#)" +
                               "\nЯдовитая слюна(*)" +
                               "\nГлаз василиска(%)");
                            string ans = Console.ReadLine();
                            switch (ans)
                            {
                                case "+":
                                    Console.WriteLine("На какой обьем (10 25 50)");
                                    int size = int.Parse(Console.ReadLine());
                                    if(size == 10)//??????????????????????????????????????????
                                    Aqua add = new Aqua(size);
                                    hero.ActivateArtifact(add,hero);
                                    break;
                                case "-":
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
                            break;
                        case 6:
                            Console.WriteLine("какое использовать заклиание" +
                               "\nДобавить здоровье(+)" +
                               "\nВылечить(^)" +
                               "\nОживить(@)" +
                               "\nБроня(#)" +
                               "\nОтомри!(*)" +
                               "\nПротивоядие(%)");
                            string ans = Console.ReadLine();
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
                            break;
                        case 7:
                            Console.WriteLine(hero.ToString());
                            break;
                        case 0:
                            return;
                        default:
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
