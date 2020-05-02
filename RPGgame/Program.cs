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
                if (name == "")
                    throw new ArgumentException("Пустое имя!");

                Console.WriteLine("Выберите пол(м/ж): ");
                string g = Console.ReadLine();
                CharacterInfo.Gender gender = CharacterInfo.Gender.male;
                if (g == "м")
                    gender = CharacterInfo.Gender.male;
                else if (g == "ж")
                    gender = CharacterInfo.Gender.female;
                else
                    throw new ArgumentException("Неизвестный пол!");

                Console.WriteLine("Выберете рассу:(человек(ч),эльф(э), орк(о), маг(м)) ");
                string r = Console.ReadLine();
                CharacterInfo.Race rassa = CharacterInfo.Race.human;
                rassa = r switch
                {
                    "э" => CharacterInfo.Race.elf,
                    "ч" => CharacterInfo.Race.human,
                    "о" => CharacterInfo.Race.ork,
                    "м" => CharacterInfo.Race.wizard,
                    _ => throw new ArgumentException("Неизвестная раса!"),
                };

                Console.WriteLine("\n/////////////////////////////////////////////////////////////////////////////////////////////////\n");
                Console.WriteLine("Вам на встречу идет против ник но у нас ничего нет ");

                var boss = new CharacterInfo("Босс", CharacterInfo.Gender.male, CharacterInfo.Race.ork);
                var hero = new MagicCharacter(name, gender, rassa);

                string otvet = "0";
                do
                {
                    if (boss.CurrentHealth == 0)
                    {
                        Console.WriteLine("Вы убили босса ))))");
                        return;
                    }
                    Console.WriteLine("Что вы хотите сделать: \n");
                    Console.WriteLine(" 1 - Текущая информация о герое\n" +
                                  " 2 - Посмотреть характеристики противника\n" +
                                  " 3 - Пополнить артефакты\n" +
                                  " 4 - Использовать артефакт\n" +
                                  " 5 - Посмотреть инвентарь\n" +
                                  " 6 - Выкинуть артефакт\n" +
                                  " 7 - Выучить закинания (только если вы маг)\n" +
                                  " 8 - Использовать заклинание (только если вы маг)\n" +
                                  " 9 - Посмотреть выученные заклинания(только если вы маг)\n" +
                                  "10 - Забыть заклинание (только если вы маг)\n" +
                                  " 0 - Завершить игру\n");
                    otvet = Console.ReadLine();

                    switch (otvet)
                    {
                        case "1"://инфа о герое
                            {
                                Console.WriteLine(hero.ToString());
                                break;
                            }
                        case "2"://инфа о боссе
                            {
                                Console.WriteLine(boss.ToString());
                                break;
                            }
                        case "3"://пополнить артефакты
                            {
                                Console.WriteLine("Какой артефакт вы хотите приобрести" +
                                   "\nБутылка с живой водой(+)" +
                                   "\nБутылка с мертвой водой(-)" +
                                   "\nПосох «Молния»(@)" +
                                   "\nДекокт из лягушачьих лапок(#)" +
                                   "\nЯдовитая слюна(*)" +
                                   "\nГлаз василиска(%)" +
                                   "\nИсцеляющий камень(&)");
                                string ans1 = Console.ReadLine();

                                switch (ans1)
                                {
                                    case "+":
                                        {
                                            Console.WriteLine("На какой обьем (10 25 50)");
                                            int size = int.Parse(Console.ReadLine());

                                            Aqua.LiveBottle s = Aqua.LiveBottle.small;

                                            if (size != 10 && size != 25 && size != 50)
                                            {
                                                Console.WriteLine("Бутылки такого размера нету!");
                                                break;
                                            }
                                            if (size == 25)
                                                s = Aqua.LiveBottle.medium;
                                            if (size == 50)
                                                s = Aqua.LiveBottle.big;

                                            if (hero.AddArtifact(new Aqua(s)))
                                                Console.WriteLine("Добавленно!!");
                                            else
                                                Console.WriteLine("Недостаточно места в инвенторе!!!");
                                            break;
                                        }
                                    case "-":
                                        {
                                            Console.WriteLine("На какой обьем (10 25 50)");
                                            int size = int.Parse(Console.ReadLine());

                                            Deadwater.DeadBottle s = Deadwater.DeadBottle.small;

                                            if (size != 10 && size != 25 && size != 50)
                                            {
                                                Console.WriteLine("Бутылки такого размера нету!");
                                                break;
                                            }
                                            if (size == 25)
                                                s = Deadwater.DeadBottle.medium;
                                            if (size == 50)
                                                s = Deadwater.DeadBottle.big;

                                            if (hero.AddArtifact(new Deadwater(s)))
                                                Console.WriteLine("Добавленно!!");
                                            else
                                                Console.WriteLine("Недостаточно места в инвенторе!!!");
                                            break;
                                        }
                                    case "@":
                                        {
                                            if (hero.AddArtifact(new LightningStaff()))
                                                Console.WriteLine("Добавленно!!");
                                            else
                                                Console.WriteLine("Недостаточно места в инвенторе!!!");
                                            break;
                                        }
                                    case "#":
                                        {
                                            if (hero.AddArtifact(new Decoction()))
                                                Console.WriteLine("Добавленно!!");
                                            else
                                                Console.WriteLine("Недостаточно места в инвенторе!!!");
                                            break;
                                        }
                                    case "*":
                                        {
                                            if (hero.AddArtifact(new PoisonousSaliva()))
                                                Console.WriteLine("Добавленно!!");
                                            else
                                                Console.WriteLine("Недостаточно места в инвенторе!!!");
                                            break;
                                        }
                                    case "%":
                                        {
                                            if (hero.AddArtifact(new BasiliskEye()))
                                                Console.WriteLine("Добавленно!!");
                                            else
                                                Console.WriteLine("Недостаточно места в инвенторе!!!");
                                            break;
                                        }
                                    case "&":
                                        {
                                            if (hero.AddArtifact(new Curing()))
                                                Console.WriteLine("Добавленно!!");
                                            else
                                                Console.WriteLine("Недостаточно места в инвенторе!!!");
                                            break;
                                        }
                                    default:
                                        Console.WriteLine("Нет такого артефакта!");
                                        break;
                                }
                                break;
                            }
                        case "4"://Использовать артефакт
                            {
                                if (hero.inventory.Count == 0)
                                {
                                    Console.WriteLine("Инвентарь пуст!");
                                    break;
                                }

                                int ans4;
                                Console.WriteLine("Для обращения к элементам вашего инвентаря, используйте приведенные ниже индексы:");
                                for (int i = 0; i < hero.inventory.Count; i++)
                                    Console.WriteLine($"{i} - {(hero.inventory[i] as Artifacts).Name}");

                                Console.Write("Введите индекс используемого элемента: ");

                                ans4 = int.Parse(Console.ReadLine());

                                if (ans4 >= 0 && ans4 < hero.inventory.Count)
                                {
                                    CharacterInfo target;
                                    if ((hero.inventory[ans4] is LightningStaff) || (hero.inventory[ans4] is BasiliskEye) || (hero.inventory[ans4] is PoisonousSaliva))
                                        target = boss;
                                    else
                                        target = hero;

                                    if ((hero.inventory[ans4] is LightningStaff) || (hero.inventory[ans4] is PoisonousSaliva) || (hero.inventory[ans4] is Curing)) {
                                        Console.WriteLine("С какой силой вы хотите его использовать?");
                                        int dam = int.Parse(Console.ReadLine());

                                        if (hero.ActivateArtifact(dam,hero.inventory[ans4] as Artifacts, target))
                                        {
                                            Console.WriteLine("Артефакт использован!!");
                                            break;
                                        }
                                        else
                                            Console.WriteLine("Использовать артефакт не удалось!!");
                                    }
                                    else
                                        if (hero.ActivateArtifact(hero.inventory[ans4] as Artifacts, target))
                                        {
                                            Console.WriteLine("Артефакт использован!!");
                                            break;
                                        }
                                        else
                                            Console.WriteLine("Использовать артефакт не удалось!!");
                                }
                                Console.WriteLine("Недействительный индекс!!");
                                break;
                            }
                        case "5"://Посмотреть инвентарь
                            {
                                if (hero.inventory.Count == 0)
                                {
                                    Console.WriteLine("Инвентарь пуст!");
                                    break;
                                }
                                foreach (var x in hero.inventory)
                                    Console.WriteLine($"{(x as Artifacts).Name}\n");
                                break;
                            }
                        case "6"://Выкинуть артефакт
                            {
                                if (hero.inventory.Count == 0)
                                {
                                    Console.WriteLine("Инвентарь пуст!");
                                    break;
                                }

                                int ans9;
                                Console.WriteLine("Для обращения к элементам вашего инвентаря, используйте приведенные ниже индексы:");
                                for (int i = 0; i < hero.inventory.Count; i++)
                                    Console.WriteLine($"{(hero.inventory[i] as Artifacts).Name} - {i}");

                                Console.Write("Введите индекс удаляемого элемента: ");

                                ans9 = int.Parse(Console.ReadLine());

                                if (ans9 >= 0 && ans9 < hero.inventory.Count)
                                {
                                    if (hero.ThrowArtifact(hero.inventory[ans9] as Artifacts))
                                    {
                                        Console.WriteLine("Артефакт выброшен!!");
                                        break;
                                    }
                                    else
                                        Console.WriteLine("Выбросить артефакт не удалось!!");
                                }
                                Console.WriteLine("Недействительный индекс!!");

                                break;
                            }
                        case "7"://Выучить закинания
                            {
                                if (hero.race == CharacterInfo.Race.wizard)
                                {
                                    if (hero.learnedSpells.Count == 5)
                                    {
                                        Console.WriteLine("Максимальное количество заклинаний выучено!!");
                                        break;
                                    }

                                    Console.WriteLine("Какое заклиание вы хотите выучить" +
                                       "\nДобавить здоровье(+)" +
                                       "\nВылечить(^)" +
                                       "\nОживить(@)" +
                                       "\nБроня(#)" +
                                       "\nОтомри!(*)" +
                                       "\nПротивоядие(%)");
                                    string ans2 = Console.ReadLine();

                                    switch (ans2)
                                    {
                                        case "+":
                                            {
                                                if (hero.LearnSpell(new Addhelth()))
                                                    Console.WriteLine("Выучено!!");
                                                else
                                                    Console.WriteLine("Было выучено ранее!!!");
                                                break;
                                            }
                                        case "^":
                                            {
                                                if (hero.LearnSpell(new ToCure()))
                                                    Console.WriteLine("Выучено!!");
                                                else
                                                    Console.WriteLine("Было выучено ранее!!!");
                                                break;
                                            }
                                        case "%":
                                            {
                                                if (hero.LearnSpell(new Antidot()))
                                                    Console.WriteLine("Выучено!!");
                                                else
                                                    Console.WriteLine("Было выучено ранее!!!");
                                                break;
                                            }
                                        case "@":
                                            {
                                                if (hero.LearnSpell(new Revive()))
                                                    Console.WriteLine("Выучено!!");
                                                else
                                                    Console.WriteLine("Было выучено ранее!!!");
                                                break;
                                            }
                                        case "#":
                                            {
                                                if (hero.LearnSpell(new Armor()))
                                                    Console.WriteLine("Выучено!!");
                                                else
                                                    Console.WriteLine("Было выучено ранее!!!");
                                                break;
                                            }
                                        case "*":
                                            {
                                                if (hero.LearnSpell(new NOtDie()))
                                                    Console.WriteLine("Выучено!!");
                                                else
                                                    Console.WriteLine("Было выучено ранее!!!");
                                                break;
                                            }
                                        default:
                                            Console.WriteLine("Нет такого заклинания!");
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Вы не маг!!!");
                                }
                                break;
                            }
                        case "8"://Использовать заклинание
                            {
                                if (!(hero is MagicCharacter))
                                {
                                    Console.WriteLine("Вы не маг!");
                                    break;
                                }
                                if (hero.learnedSpells.Count == 0)
                                {
                                    Console.WriteLine("Вы не знаете никаких заклинаний!");
                                    break;
                                }

                                int ans8;
                                Console.WriteLine("Для обращения к выученным заклинаниям, используйте приведенные ниже индексы:");
                                for (int i = 0; i < hero.learnedSpells.Count; i++)
                                    Console.WriteLine($"{i} - {(hero.learnedSpells[i] as Spell).Name}");

                                Console.Write("Введите индекс используемого заклинания: ");

                                ans8 = int.Parse(Console.ReadLine());

                                if (ans8 >= 0 && ans8 < hero.learnedSpells.Count)
                                {
                                    if ((hero.learnedSpells[ans8] is Armor) || (hero.learnedSpells[ans8] is Addhelth)) { 
                                        Console.WriteLine("Сколько маны вы хотите использовать?");
                                        int dam = int.Parse(Console.ReadLine());

                                        if (hero.ActivateSpell(dam, hero.learnedSpells[ans8] as Spell, hero))
                                        {
                                            Console.WriteLine("Заклинание использовано!!");
                                            break;
                                        }
                                        else
                                            Console.WriteLine("Использовать заклинание не удалось!!");
                                    }
                                    else
                                        if (hero.ActivateSpell(hero.learnedSpells[ans8] as Spell, hero))
                                        {
                                            Console.WriteLine("Заклинание использовано!!");
                                            break;
                                        }
                                        else
                                            Console.WriteLine("Использовать заклинание не удалось!!");
                                }
                                Console.WriteLine("Недействительный индекс!!");
                                break;
                            }
                        case "9"://Посмотреть выученные заклинания
                            {
                                if (!(hero is MagicCharacter))
                                {
                                    Console.WriteLine("Перонаж не маг!!");
                                    break;
                                }
                                if (hero.learnedSpells.Count == 0)
                                {
                                    Console.WriteLine("Вы не знаете никаких заклинаний!");
                                    break;
                                }
                                foreach (var x in hero.learnedSpells)
                                    Console.WriteLine($"{(x as Spell).Name}\n");
                                break;
                            }
                        case "10"://Забыть заклинание
                            {
                                if (!(hero is MagicCharacter))
                                {
                                    Console.WriteLine("Перонаж не маг!!");
                                    break;
                                }
                                if (hero.learnedSpells.Count == 0)
                                {
                                    Console.WriteLine("Вы не знаете никаких заклинаний!");
                                    break;
                                }

                                int ans10;
                                Console.WriteLine("Для обращения к изученным заклинаниям, используйте приведенные ниже индексы:");
                                for (int i = 0; i < hero.learnedSpells.Count; i++)
                                    Console.WriteLine($"{i} - {(hero.learnedSpells[i] as Spell).Name}");

                                Console.Write("Введите индекс удаляемого заклинания: ");
                                ans10 = int.Parse(Console.ReadLine());

                                if (ans10 >= 0 && ans10 < hero.learnedSpells.Count)
                                {
                                    if (hero.ForgetSpell(hero.learnedSpells[ans10] as Spell))
                                    {
                                        Console.WriteLine("Зкленание забыто!!");
                                        break;
                                    }
                                    else
                                        Console.WriteLine("Забыть невозможно!!");
                                }
                                Console.WriteLine("Недействительный индекс!!");

                                break;
                            }
                        case "0"://выход
                            Console.WriteLine("Игра завершена!");
                            return;
                        default:
                            Console.WriteLine("Такой команды нет!!");
                            break;
                    }
                    Console.WriteLine("\n/////////////////////////////////////////////////////////////////////////////////////////////////\n");
                } while (true);
            }
            catch (ArgumentException ag)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ag.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}