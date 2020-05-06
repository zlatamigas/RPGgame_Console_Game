using System;

namespace RPGgame
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            CharacterInfo hero;

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

                Console.WriteLine("Выберете рассу:(человек(ч), эльф(э), орк(о), дух(д)) ");
                string r = Console.ReadLine();
                CharacterInfo.Race rassa = CharacterInfo.Race.human;
                rassa = r switch
                {
                    "э" => CharacterInfo.Race.elf,
                    "ч" => CharacterInfo.Race.human,
                    "о" => CharacterInfo.Race.ork,
                    "д" => CharacterInfo.Race.spirit,
                    _ => throw new ArgumentException("Неизвестная раса!"),
                };

                Console.WriteLine("Желаете ли обладать магией? (да/нет)");
                string ans = Console.ReadLine();

                if (ans == "да")
                    hero = new MagicCharacter(name, gender, rassa);
                else if (ans == "нет")
                    hero = new CharacterInfo(name, gender, rassa);
                else
                    throw new ArgumentException("Мы вас не понимаем!");
            }
            catch (ArgumentException ag)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ag.Message);
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            var boss = new CharacterInfo("Босс", CharacterInfo.Gender.male, CharacterInfo.Race.ork);
            for (int i = 0; i < 9; i++)
            {
                boss.AddArtifact(new PoisonousSaliva());
                boss.AddArtifact(new LightningStaff());
            }
            boss.Experiance = 120;

            Console.WriteLine("\n/////////////////////////////////////////////////////////////////////////////////////////////////\n");
                Console.WriteLine("Вам на встречу идет противник но у вас ничего нет.");

            string otvet = "0";
            do
            {
                if (boss.CurrentHealth == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Вы убили босса ))))");
                    Console.ForegroundColor = ConsoleColor.White;
                    hero.Experiance += boss.Experiance;
                    Console.WriteLine("Ваш опыт: "+ (hero.Experiance).ToString()+" xp");
                    return;
                }

                int ind = rnd.Next(0, boss.inventory.Count);
                if (boss.ActivateArtifact(30, boss.inventory[ind] as Artifacts, hero))
                {
                    Console.WriteLine("Вас атаковали!!\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Ваши текущие данные:\n" + hero.ToString()+'\n');
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (hero.CurrentHealth == 0) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nВы проиграли!");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }

                Console.WriteLine("Что вы хотите сделать: \n");
                Console.WriteLine(" 1 - Завершить игру\n" +
                                " 2 - Посмотреть характеристики противника\n" +
                                " 3 - Пополнить артефакты\n" +
                                " 4 - Использовать артефакт\n" +
                                " 5 - Посмотреть инвентарь\n" +
                                " 6 - Выкинуть артефакт\n" +
                                " 7 - Выучить закинания (только если вы маг)\n" +
                                " 8 - Использовать заклинание (только если вы маг)\n" +
                                " 9 - Посмотреть выученные заклинания(только если вы маг)\n" +
                                "10 - Забыть заклинание (только если вы маг)\n");
                otvet = Console.ReadLine();
                Console.WriteLine("\n/////////////////////////////////////////////////////////////////////////////////////////////////\n");
                switch (otvet)
                {
                    case "1"://Выход
                        {
                            Console.WriteLine("Игра завершена!");
                            return;
                        }
                    case "2"://Информация о боссе
                        {
                            Console.WriteLine(boss.ToString());
                            break;
                        }
                    case "3"://Пополнить артефакты
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

                                if ((hero.inventory[ans4] is LightningStaff) || (hero.inventory[ans4] is PoisonousSaliva) || (hero.inventory[ans4] is Curing))
                                {
                                    Console.WriteLine("С какой силой вы хотите его использовать (учтите, что сила использования артефакта ограничевается его мощностью)?");
                                    int dam = int.Parse(Console.ReadLine());

                                    if (hero.ActivateArtifact(dam, hero.inventory[ans4] as Artifacts, target))
                                    {
                                        Console.WriteLine("Артефакт использован!!");
                                        break;
                                    }
                                    else
                                        Console.WriteLine("Использовать артефакт не удалось!!");
                                }
                                else if (hero.ActivateArtifact(hero.inventory[ans4] as Artifacts, target))
                                {
                                    Console.WriteLine("Артефакт использован!!");
                                    break;
                                }
                                else
                                    Console.WriteLine("Использовать артефакт не удалось!!");
                            }
                            else
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
                                Console.WriteLine($"{(x as Artifacts).Name}");
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
                            else
                                Console.WriteLine("Недействительный индекс!!");

                            break;
                        }
                    case "7"://Выучить закинания
                        {
                            if (hero.GetType() != typeof(MagicCharacter))
                            {
                                Console.WriteLine("Вы не маг!!!");
                                break;
                            }
                            if ((hero as MagicCharacter).learnedSpells.Count == 5)
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
                                        if ((hero as MagicCharacter).LearnSpell(new Addhelth()))
                                            Console.WriteLine("Выучено!!");
                                        else
                                            Console.WriteLine("Было выучено ранее!!!");
                                        break;
                                    }
                                case "^":
                                    {
                                        if ((hero as MagicCharacter).LearnSpell(new ToCure()))
                                            Console.WriteLine("Выучено!!");
                                        else
                                            Console.WriteLine("Было выучено ранее!!!");
                                        break;
                                    }
                                case "%":
                                    {
                                        if ((hero as MagicCharacter).LearnSpell(new Antidot()))
                                            Console.WriteLine("Выучено!!");
                                        else
                                            Console.WriteLine("Было выучено ранее!!!");
                                        break;
                                    }
                                case "@":
                                    {
                                        if ((hero as MagicCharacter).LearnSpell(new Revive()))
                                            Console.WriteLine("Выучено!!");
                                        else
                                            Console.WriteLine("Было выучено ранее!!!");
                                        break;
                                    }
                                case "#":
                                    {
                                        if ((hero as MagicCharacter).LearnSpell(new Armor()))
                                            Console.WriteLine("Выучено!!");
                                        else
                                            Console.WriteLine("Было выучено ранее!!!");
                                        break;
                                    }
                                case "*":
                                    {
                                        if ((hero as MagicCharacter).LearnSpell(new NOtDie()))
                                            Console.WriteLine("Выучено!!");
                                        else
                                            Console.WriteLine("Было выучено ранее!!!");
                                        break;
                                    }
                                default:
                                    Console.WriteLine("Нет такого заклинания!");
                                    break;
                            }
                            break;
                        }
                    case "8"://Использовать заклинание
                        {
                            if (hero.GetType() != typeof(MagicCharacter))
                            {
                                Console.WriteLine("Вы не маг!");
                                break;
                            }
                            if ((hero as MagicCharacter).learnedSpells.Count == 0)
                            {
                                Console.WriteLine("Вы не знаете никаких заклинаний!");
                                break;
                            }

                            int ans8;
                            Console.WriteLine("Для обращения к выученным заклинаниям, используйте приведенные ниже индексы:");
                            for (int i = 0; i < (hero as MagicCharacter).learnedSpells.Count; i++)
                                Console.WriteLine($"{i} - {((hero as MagicCharacter).learnedSpells[i] as Spell).Name}");

                            Console.Write("Введите индекс используемого заклинания: ");

                            ans8 = int.Parse(Console.ReadLine());
                            if (ans8 >= 0 && ans8 < (hero as MagicCharacter).learnedSpells.Count)
                            {
                                if (((hero as MagicCharacter).learnedSpells[ans8] is Armor) || ((hero as MagicCharacter).learnedSpells[ans8] is Addhelth))
                                {
                                    Console.WriteLine("Сколько маны вы хотите использовать (учтите, что максимальное значение используемой маны ограничевается Вашей маной)?");
                                    int dam = int.Parse(Console.ReadLine());

                                    if ((hero as MagicCharacter).ActivateSpell(dam, (hero as MagicCharacter).learnedSpells[ans8] as Spell, hero))
                                    {
                                        Console.WriteLine("Заклинание использовано!!");
                                        break;
                                    }
                                    else
                                        Console.WriteLine("Использовать заклинание не удалось!!");
                                }
                                else if ((hero as MagicCharacter).ActivateSpell((hero as MagicCharacter).learnedSpells[ans8] as Spell, hero))
                                {
                                    Console.WriteLine("Заклинание использовано!!");
                                    break;
                                }
                                else
                                    Console.WriteLine("Использовать заклинание не удалось!!");
                            }
                            else
                                Console.WriteLine("Недействительный индекс!!");
                            break;
                        }
                    case "9"://Посмотреть выученные заклинания
                        {
                            if (hero.GetType() != typeof(MagicCharacter))
                            {
                                Console.WriteLine("Вы не маг!!");
                                break;
                            }
                            if ((hero as MagicCharacter).learnedSpells.Count == 0)
                            {
                                Console.WriteLine("Вы не знаете никаких заклинаний!");
                                break;
                            }
                            foreach (var x in (hero as MagicCharacter).learnedSpells)
                                Console.WriteLine($"{(x as Spell).Name}");
                            break;
                        }
                    case "10"://Забыть заклинание
                        {
                            if (!(hero is MagicCharacter))
                            {
                                Console.WriteLine("Вы не маг!!");
                                break;
                            }
                            if ((hero as MagicCharacter).learnedSpells.Count == 0)
                            {
                                Console.WriteLine("Вы не знаете никаких заклинаний!");
                                break;
                            }

                            int ans10;
                            Console.WriteLine("Для обращения к изученным заклинаниям, используйте приведенные ниже индексы:");
                            for (int i = 0; i < (hero as MagicCharacter).learnedSpells.Count; i++)
                                Console.WriteLine($"{i} - {((hero as MagicCharacter).learnedSpells[i] as Spell).Name}");

                            Console.Write("Введите индекс удаляемого заклинания: ");
                            ans10 = int.Parse(Console.ReadLine());

                            if (ans10 >= 0 && ans10 < (hero as MagicCharacter).learnedSpells.Count)
                            {
                                if ((hero as MagicCharacter).ForgetSpell((hero as MagicCharacter).learnedSpells[ans10] as Spell))
                                {
                                    Console.WriteLine("Зкленание забыто!!");
                                    break;
                                }
                                else
                                    Console.WriteLine("Забыть невозможно!!");
                            }
                            else
                                Console.WriteLine("Недействительный индекс!!");

                            break;
                        }
                    default:
                        Console.WriteLine("Такой команды нет!!");
                        break;
                }
                Console.WriteLine("\n/////////////////////////////////////////////////////////////////////////////////////////////////\n");
            } while (true);
        }
    }
}