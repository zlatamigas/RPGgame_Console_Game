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
                    throw new ArgumentException("Empty name!");
                Console.WriteLine("Выберите пол(м/ж): ");
                string g = Console.ReadLine();
                CharacterInfo.Gender gender = CharacterInfo.Gender.male;
                if (g == "м")
                    gender = CharacterInfo.Gender.male;
                else if (g == "ж")
                    gender = CharacterInfo.Gender.female;
                else
                    throw new ArgumentException("Unknown gender!");
                Console.WriteLine("Выберете рассу:(человек(ч),эльф(э), орк(о), маг(м)) ");
                string r = Console.ReadLine();
                CharacterInfo.Race rassa = CharacterInfo.Race.human;
                rassa = r switch
                {
                    "э" => CharacterInfo.Race.elf,
                    "ч" => CharacterInfo.Race.human,
                    "о" => CharacterInfo.Race.ork,
                    "м" => CharacterInfo.Race.wizard,
                    _ => throw new ArgumentException("Unknown race!"),
                };
                Console.WriteLine("\n/////////////////////////////////////////////////////////////////////////////////////////////////\n");
                Console.WriteLine("Вам на встречу идет против ник но у нас ничего нет ");

                var boss = new MagicCharacter("Босс", CharacterInfo.Gender.male, CharacterInfo.Race.ork);
                var hero = new MagicCharacter(name, gender, rassa);
                int otvet = 0;
                do
                {
                    if(boss.CurrentHealth == 0)
                    {
                        Console.WriteLine("Вы убили босса ))))");
                        return;
                    }

                    Console.WriteLine("Что вы хотите сделать: \n");
                    Console.WriteLine("1 - Пополнить артефакты\n" +
                                  "2 - Выучить закинания (только если вы маг)\n" +
                                  "3 - Посмотреть инвентарь\n" +
                                  "4 - Посмотреть выученные заклинания(только если вы маг)\n" +
                                  "5 - Использовать артефакт\n" +
                                  "6 - Использовать заклинание (только если вы маг)\n" +
                                  "7 - Текущая информация\n" +
                                  "8 - Забыть заклинание (только если вы маг)\n" +
                                  "9 - Выкинуть артефакт\n" +
                                  "10 - Посмотреть характеристику противника\n" +
                                  "0 - Завершить игру\n");
                    otvet = int.Parse(Console.ReadLine());

                    switch (otvet)
                    {
                        case 1:
                            {
                                Console.WriteLine("Какой артефакт вы хотите приобрести" +
                                   "\nБутылка с живой водой(+)" +
                                   "\nБутылка с мертвой водой(-)" +
                                   "\nПосох «Молния»(@)" +
                                   "\nДекокт из лягушачьих лапок(#)" +
                                   "\nЯдовитая слюна(*)" +
                                   "\nГлаз василиска(%)");
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
                                            if (hero.AddArtifact(new FrogsFeet()))
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
                                    default:
                                        Console.WriteLine("Нет такого артифакта!");
                                        break;
                                }
                                break;
                            }

                        case 2://
                            if (hero.race == CharacterInfo.Race.wizard)
                            {
                                Console.WriteLine("какое заклиание вы хотите выучить" +
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
                                        Addhelth addhelth = new Addhelth();
                                        hero.LearnSpell(addhelth);
                                        Console.WriteLine("Добавленно !!");
                                        break;
                                    case "^":
                                        ToCure cure = new ToCure();
                                        hero.LearnSpell(cure);
                                        Console.WriteLine("Добавленно!!");
                                        break;
                                    case "@":
                                        Antidot antidot = new Antidot();
                                        hero.LearnSpell(antidot);
                                        Console.WriteLine("Добавленно !!");
                                        break;
                                    case "#":
                                        Revive revive = new Revive();
                                        hero.LearnSpell(revive);
                                        Console.WriteLine("Добавленно !!");
                                        break;
                                    case "*":
                                        Armor armor = new Armor();
                                        hero.LearnSpell(armor);
                                        Console.WriteLine("Добавленно !!");
                                        break;
                                    default:
                                        Console.WriteLine("нет такого заклинания!");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы не маг!!!");
                            }
                            break;

                        case 3:
                            {
                                if (hero.inventory.Count == 0)
                                {
                                    Console.WriteLine("Инвентарь пуст!");
                                    break;
                                }
                                foreach (var x in hero.inventory)
                                {
                                    Console.WriteLine($"{x}\n");//хочу что бы было типа так {х.Имя};
                                }
                                break;
                            }
                        case 4:
                            {
                                if (hero.race == CharacterInfo.Race.wizard)
                                {
                                    if (hero.learnedSpells.Count == 0)
                                    {
                                        Console.WriteLine("Вы не знаете никаких заклинаний!");
                                        break;
                                    }
                                    foreach (var x in hero.learnedSpells)
                                        Console.WriteLine($"{x}\n");//хочу что бы было типа так {х.Имя};                            
                                }
                                else
                                {
                                    Console.WriteLine("Вы не маг!!!");
                                }
                                break;
                            }
                        case 5:
                            Console.WriteLine("Какой артефакт вы хотите использовать" +
                               "\nБутылка с живой водой(+)" +
                               "\nБутылка с мертвой водой(-)" +
                               "\nПосох «Молния»(@)" +
                               "\nДекокт из лягушачьих лапок(#)" +
                               "\nЯдовитая слюна(*)" +
                               "\nГлаз василиска(%)");
                            string ans5 = Console.ReadLine();
                            switch (ans5)
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

                                        foreach (var x in hero.inventory)
                                            if (x is Aqua)
                                                if ((x as Aqua).bottle == s)
                                                {
                                                    if (hero.ActivateArtifact((x as Aqua), hero))
                                                        Console.WriteLine("Использовано!!");
                                                    else
                                                        Console.WriteLine("Невозможно использовать!!!");
                                                    break;
                                                }

                                        break;
                                    }















                                case "-":
                                    Console.WriteLine("На какой обьем (10 25 50)");
                                    int size1 = int.Parse(Console.ReadLine());
                                    #region /*if (size == 10)
                                    //    LiveBottle s = Aqua.LiveBottle.small;
                                    //if (size == 25)
                                    //    LiveBottle s = Aqua.LiveBottle.medium;
                                    //if (size == 50)
                                    //    LiveBottle s = Aqua.LiveBottle.big;*/
                                    #endregion
                                    Deadwater dead = new Deadwater(Deadwater.DeadBottle.small);
                                    hero.ActivateArtifact(dead, hero);
                                    Console.WriteLine("Использованно !!");
                                    break;
                                case "@":
                                    LightningStaff lightning = new LightningStaff();
                                    hero.ActivateArtifact(lightning, hero);
                                    Console.WriteLine("С какой мощностью вы хотите его использовать");
                                    int uron = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Использованно !!");
                                    break;
                                case "#":
                                    FrogsFeet frogs = new FrogsFeet();
                                    hero.ActivateArtifact(frogs, hero);
                                    Console.WriteLine("Использованно !!");
                                    break;
                                case "*":
                                    PoisonousSaliva poisonous = new PoisonousSaliva();
                                    hero.ActivateArtifact(poisonous, hero);
                                    Console.WriteLine("С какой мощностью вы хотите его использовать");
                                    int mosch = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Использованно !!");
                                    break;
                                default:
                                    Console.WriteLine("В инвентаре нет такого артефакта?");
                                    break;
                            }
                            break;
                        case 6:
                            if (hero.race == CharacterInfo.Race.wizard)
                            {
                                Console.WriteLine("какое использовать заклиание" +
                                   "\nДобавить здоровье(+)" +
                                   "\nВылечить(^)" +
                                   "\nОживить(@)" +
                                   "\nБроня(#)" +
                                   "\nОтомри!(*)" +
                                   "\nПротивоядие(%)");
                                string ans6 = Console.ReadLine();
                                switch (ans6)
                                {
                                    case "+":
                                        Addhelth addhelth = new Addhelth();
                                        hero.ActivateSpell(addhelth, hero);
                                        Console.WriteLine("С какой силой вы хотите его использовать");
                                        int dam = int.Parse(Console.ReadLine());
                                        addhelth.DoMAgicThing(dam, hero);
                                        Console.WriteLine("Использованно !!");
                                        break;
                                    case "-":
                                        ToCure cure = new ToCure();
                                        hero.ActivateSpell(cure, hero);
                                        cure.DoMAgicThing(hero);
                                        Console.WriteLine("Использованно !!");
                                        break;
                                    case "@":
                                        Antidot antidot = new Antidot();
                                        hero.ActivateSpell(antidot, hero);
                                        antidot.DoMAgicThing(hero);
                                        Console.WriteLine("Использованно !!");
                                        break;
                                    case "#":
                                        Revive revive = new Revive();
                                        hero.ActivateSpell(revive, hero);
                                        revive.DoMAgicThing(hero);
                                        Console.WriteLine("Использованно !!");
                                        break;
                                    case "*":
                                        Armor armor = new Armor();
                                        hero.ActivateSpell(armor, hero);
                                        Console.WriteLine("С какой силой вы хотите его использовать");
                                        int dameg = int.Parse(Console.ReadLine());
                                        armor.DoMAgicThing(dameg, hero);
                                        Console.WriteLine("Использованно !!");
                                        break;
                                    default:
                                        Console.WriteLine("нет такого");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("вы не маг!!!");
                            }
                            break;
                        case 7:
                            Console.WriteLine(hero.ToString());
                            break;
                        case 8:
                            if (hero.race == CharacterInfo.Race.wizard)
                            {
                                Console.WriteLine("Какое заклинание вы хотите забыть" +
                                   "\nДобавить здоровье(+)" +
                                   "\nВылечить(^)" +
                                   "\nОживить(@)" +
                                   "\nБроня(#)" +
                                   "\nОтомри!(*)" +
                                   "\nПротивоядие(%)");
                                string memory = Console.ReadLine();
                                switch (memory)
                                {
                                    case "+":
                                        Addhelth addhelth = new Addhelth();
                                        hero.ForgetSpell(addhelth);
                                        Console.WriteLine("Забыто !!");
                                        break;
                                    case "-":
                                        ToCure cure = new ToCure();
                                        hero.ForgetSpell(cure);
                                        Console.WriteLine("Забыто !!");
                                        break;
                                    case "@":
                                        Antidot antidot = new Antidot();
                                        hero.ForgetSpell(antidot);
                                        Console.WriteLine("Забыто !!");
                                        break;
                                    case "#":
                                        Revive revive = new Revive();
                                        hero.ForgetSpell(revive);
                                        Console.WriteLine("Забыто !!");
                                        break;
                                    case "*":
                                        Armor armor = new Armor();
                                        hero.ForgetSpell(armor);
                                        Console.WriteLine("Забыто !!");
                                        break;
                                    default:
                                        Console.WriteLine("нет такого заклинания в принципе!");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("вы не маг!!!");
                            }
                            break;
                        case 9:
                            Console.WriteLine("какой артефакт вы хотите выбросить" +
                               "\nБутылка с живой водой(+)" +
                               "\nБутылка с мертвой водой(-)" +
                               "\nПосох «Молния»(@)" +
                               "\nДекокт из лягушачьих лапок(#)" +
                               "\nЯдовитая слюна(*)" +
                               "\nГлаз василиска(%)");
                            string ans9 = Console.ReadLine();
                            switch (ans9)
                            {
                                case "+":
                                    Console.WriteLine("На какой обьем (10 25 50)");
                                    int size = int.Parse(Console.ReadLine());
                                    #region /*if (size == 10)
                                    //    LiveBottle s = Aqua.LiveBottle.small;
                                    //if (size == 25)
                                    //    LiveBottle s = Aqua.LiveBottle.medium;
                                    //if (size == 50)
                                    //    LiveBottle s = Aqua.LiveBottle.big;*/
                                    #endregion
                                    Aqua aqua = new Aqua(Aqua.LiveBottle.small);
                                    hero.ThrowArtifact(aqua);
                                    Console.WriteLine("Выброшенно!!");
                                    break;
                                case "-":
                                    Console.WriteLine("На какой обьем (10 25 50)");
                                    int size1 = int.Parse(Console.ReadLine());
                                    #region /*if (size == 10)
                                    //    LiveBottle s = Aqua.LiveBottle.small;
                                    //if (size == 25)
                                    //    LiveBottle s = Aqua.LiveBottle.medium;
                                    //if (size == 50)
                                    //    LiveBottle s = Aqua.LiveBottle.big;*/
                                    #endregion
                                    Deadwater deadwater = new Deadwater(Deadwater.DeadBottle.small);
                                    hero.ThrowArtifact(deadwater);
                                    Console.WriteLine("Выброшенно!!");
                                    break;
                                case "@":
                                    LightningStaff staff = new LightningStaff();
                                    hero.ThrowArtifact(staff);
                                    Console.WriteLine("Выброшенно!!");
                                    break;
                                case "#":
                                    FrogsFeet frogs = new FrogsFeet();
                                    hero.ThrowArtifact(frogs);
                                    Console.WriteLine("Выброшенно!!");
                                    break;
                                case "*":
                                    PoisonousSaliva saliva = new PoisonousSaliva();
                                    hero.ThrowArtifact(saliva);
                                    Console.WriteLine("Выброшенно!!");
                                    break;
                                default:
                                    Console.WriteLine("нет такого артифакта!");
                                    break;
                            }
                            break;
                        case 10:
                            Console.WriteLine(boss.ToString());
                            break;
                        default:
                            Console.WriteLine("Такой команды нет!!");
                            break;
                    }
                    Console.WriteLine("\n/////////////////////////////////////////////////////////////////////////////////////////////////\n");
                } while (otvet != 0);
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
