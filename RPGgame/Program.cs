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
                    Console.WriteLine(" 1 - Текущая информация о герое\n" +
                                  " 2 - Посмотреть характеристику противника\n" +
                                  " 3 - Пополнить артефакты\n" +
                                  " 4 - Использовать артефакт\n" +
                                  " 5 - Посмотреть инвентарь\n" +
                                  " 6 - Выкинуть артефакт\n" +
                                  " 7 - Выучить закинания (только если вы маг)\n" +
                                  " 8 - Использовать заклинание (только если вы маг)\n" +
                                  " 9 - Посмотреть выученные заклинания(только если вы маг)\n" +
                                  "10 - Забыть заклинание (только если вы маг)\n" +
                                  "0 - Завершить игру\n");
                    otvet = int.Parse(Console.ReadLine());

                    switch (otvet)
                    {
                        case 1://
                            {
                                Console.WriteLine(hero.ToString());
                                break;
                            }
                        case 2://
                            {
                                Console.WriteLine(boss.ToString());
                                break;
                            }
                        case 3:
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
                        case 4://
                            {
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
                                                        if (hero.ActivateArtifact(x as Aqua, hero))
                                                        {
                                                            Console.WriteLine("Использовано!!");
                                                            break;
                                                        }
                                                        else
                                                            Console.WriteLine("Невозможно использовать!!!");
                                                        break;
                                                    }

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

                                            foreach (var x in hero.inventory)
                                                if (x is Deadwater)
                                                    if ((x as Deadwater).bottle == s)
                                                    {
                                                        if (hero.ActivateArtifact(x as Deadwater, hero))
                                                        {
                                                            Console.WriteLine("Использовано!!");
                                                            break;
                                                        }
                                                        else
                                                            Console.WriteLine("Невозможно использовать!!!");
                                                        break;
                                                    }
                                            break;
                                        }
                                    case "@":
                                        {
                                            Console.WriteLine("С какой мощностью вы хотите его использовать");
                                            int uron = int.Parse(Console.ReadLine());
                                            foreach (var x in hero.inventory)
                                                if (x is LightningStaff)
                                                    if (hero.ActivateArtifact(uron, x as LightningStaff, hero))
                                                    {
                                                        Console.WriteLine("Использовано!!");
                                                        break;
                                                    }
                                                    else
                                                        Console.WriteLine("Невозможно использовать!!!");
                                            break;
                                        }
                                    case "#":
                                        {
                                            foreach (var x in hero.inventory)
                                                if (x is FrogsFeet)
                                                    if (hero.ActivateArtifact(x as FrogsFeet, hero))
                                                    {
                                                        Console.WriteLine("Использовано!!");
                                                        break;
                                                    }
                                                    else
                                                        Console.WriteLine("Невозможно использовать!!!");
                                            break;
                                        }
                                    case "*":
                                        {
                                            Console.WriteLine("С какой мощностью вы хотите его использовать");
                                            int mosch = int.Parse(Console.ReadLine());
                                            foreach (var x in hero.inventory)
                                                if (x is PoisonousSaliva)
                                                    if (hero.ActivateArtifact(mosch, x as PoisonousSaliva, hero))
                                                    {
                                                        Console.WriteLine("Использовано!!");
                                                        break;
                                                    }
                                                    else
                                                        Console.WriteLine("Невозможно использовать!!!");
                                            break;
                                        }
                                    default:
                                        Console.WriteLine("В инвентаре нет такого артефакта?");
                                        break;
                                }
                                break;
                            }
                        case 5:
                            {
                                if (hero.inventory.Count == 0)
                                {
                                    Console.WriteLine("Инвентарь пуст!");
                                    break;
                                }
                                foreach (var x in hero.inventory)
                                    Console.WriteLine($"{x}\n");
                                break;
                            }
                        case 6://
                            {
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
                                                        if (hero.ThrowArtifact(x as Aqua))
                                                        {
                                                            Console.WriteLine("Выброшенно!!");
                                                            break;
                                                        }
                                                        else
                                                            Console.WriteLine("Невозможно Выбросить!!!");
                                                        break;
                                                    }
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

                                            foreach (var x in hero.inventory)
                                                if (x is Deadwater)
                                                    if ((x as Deadwater).bottle == s)
                                                    {
                                                        if (hero.ActivateArtifact((x as Deadwater), hero))
                                                        {
                                                            Console.WriteLine("Выброшенно!!");
                                                            break;
                                                        }
                                                        else
                                                            Console.WriteLine("Невозможно Выбросить!!!");
                                                        break;
                                                    }
                                            break;
                                        }
                                    case "@":
                                        {
                                            foreach (var x in hero.inventory)
                                                if (x is LightningStaff)
                                                    if (hero.ThrowArtifact(x as LightningStaff))
                                                    {
                                                        Console.WriteLine("Выброшенно!!");
                                                        break;
                                                    }
                                                    else
                                                        Console.WriteLine("Невозможно Выбросить!!!");
                                            break;
                                        }
                                    case "#":
                                        {
                                            foreach (var x in hero.inventory)
                                                if (x is FrogsFeet)
                                                    if (hero.ThrowArtifact(x as FrogsFeet))
                                                    {
                                                        Console.WriteLine("Выброшенно!!");
                                                        break;
                                                    }
                                                    else
                                                        Console.WriteLine("Невозможно Выбросить!!!");
                                            break;
                                        }
                                    case "*":
                                        {
                                            foreach (var x in hero.inventory)
                                                if (x is PoisonousSaliva)
                                                    if (hero.ThrowArtifact(x as PoisonousSaliva))
                                                    {
                                                        Console.WriteLine("Выброшенно!!");
                                                        break;
                                                    }
                                                    else
                                                        Console.WriteLine("Невозможно Выбросить!!!");
                                            break;
                                        }
                                    default:
                                        Console.WriteLine("В инвентаре нет такого артефакта?");
                                        break;
                                }
                                break;
                            }
                        case 7://
                            {
                                if (hero.race == CharacterInfo.Race.wizard)
                                {
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
                                                    Console.WriteLine("Добавленно !!");
                                                else
                                                    Console.WriteLine("Не достаточно места!!!");
                                                break;
                                            }
                                        case "^":
                                            {
                                                if (hero.LearnSpell(new ToCure()))
                                                    Console.WriteLine("Добавленно !!");
                                                else
                                                    Console.WriteLine("Не достаточно места!!!");
                                                break;
                                            }
                                        case "@":
                                            {
                                                if (hero.LearnSpell(new Antidot()))
                                                    Console.WriteLine("Добавленно !!");
                                                else
                                                    Console.WriteLine("Не достаточно места!!!");
                                                break;
                                            }
                                        case "#":
                                            {
                                                if (hero.LearnSpell(new Revive()))
                                                    Console.WriteLine("Добавленно !!");
                                                else
                                                    Console.WriteLine("Не достаточно места!!!");
                                                break;
                                            }
                                        case "*":
                                            {
                                                if (hero.LearnSpell(new Armor()))
                                                    Console.WriteLine("Добавленно !!");
                                                else
                                                    Console.WriteLine("Не достаточно места!!!");
                                                break;
                                            }
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
                            }
                        case 8://
                            {
                                if (hero.race == CharacterInfo.Race.wizard)
                                {
                                    Console.WriteLine("Какое использовать заклиание" +
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
                                            {
                                                Console.WriteLine("С какой силой вы хотите его использовать");
                                                int dam = int.Parse(Console.ReadLine());
                                                foreach (var x in hero.learnedSpells)
                                                    if (x is Addhelth)
                                                        if (hero.ActivateSpell(dam, x as Addhelth, hero))
                                                        {
                                                            Console.WriteLine("Использовано!!");
                                                            break;
                                                        }
                                                        else
                                                            Console.WriteLine("Невозможно использовать!!!");
                                                break;
                                            }
                                        case "-":
                                            {
                                                foreach (var x in hero.learnedSpells)
                                                    if (x is ToCure)
                                                        if (hero.ActivateSpell(x as ToCure, hero))
                                                        {
                                                            Console.WriteLine("Использовано!!");
                                                            break;
                                                        }
                                                        else
                                                            Console.WriteLine("Невозможно использовать!!!");
                                                break;
                                            }
                                        case "@":
                                            {
                                                foreach (var x in hero.learnedSpells)
                                                    if (x is Antidot)
                                                        if (hero.ActivateSpell(x as Antidot, hero))
                                                        {
                                                            Console.WriteLine("Использовано!!");
                                                            break;
                                                        }
                                                        else
                                                            Console.WriteLine("Невозможно использовать!!!");
                                                break;
                                            }
                                        case "#":
                                            {
                                                Console.WriteLine("С какой силой вы хотите его использовать");
                                                int dam = int.Parse(Console.ReadLine());
                                                foreach (var x in hero.learnedSpells)
                                                    if (x is Armor)
                                                        if (hero.ActivateSpell(dam, x as Armor, hero))
                                                        {
                                                            Console.WriteLine("Использовано!!");
                                                            break;
                                                        }
                                                        else
                                                            Console.WriteLine("Невозможно использовать!!!");
                                                break;
                                            }
                                        case "*":
                                            {
                                                foreach (var x in hero.learnedSpells)
                                                    if (x is NOtDie)
                                                        if (hero.ActivateSpell(x as NOtDie, hero))
                                                        {
                                                            Console.WriteLine("Использовано!!");
                                                            break;
                                                        }
                                                        else
                                                            Console.WriteLine("Невозможно использовать!!!");
                                                break;
                                            }
                                        case "%":
                                            {
                                                foreach (var x in hero.learnedSpells)
                                                    if (x is Antidot)
                                                        if (hero.ActivateSpell(x as Antidot, hero))
                                                        {
                                                            Console.WriteLine("Использовано!!");
                                                            break;
                                                        }
                                                        else
                                                            Console.WriteLine("Невозможно использовать!!!");
                                                break;
                                            }
                                        default:
                                            Console.WriteLine("нет такого заклинания");
                                            break;
                                    }
                                }
                                else
                                    Console.WriteLine("вы не маг!!!");
                                break;
                            }
                        case 9:
                            {
                                if (hero.race == CharacterInfo.Race.wizard)
                                {
                                    if (hero.learnedSpells.Count == 0)
                                    {
                                        Console.WriteLine("Вы не знаете никаких заклинаний!");
                                        break;
                                    }
                                    foreach (var x in hero.learnedSpells)
                                        Console.WriteLine($"{x}\n");                           
                                }
                                else
                                    Console.WriteLine("Вы не маг!!!");
                                break;
                            }               
                        case 10://
                            {
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
                                            {
                                                foreach (var x in hero.learnedSpells)
                                                    if (x is Addhelth)
                                                        if (hero.ForgetSpell(x as Addhelth))
                                                        {
                                                            Console.WriteLine("Забыто!!");
                                                            break;
                                                        }
                                                        else
                                                            Console.WriteLine("Такого заклинания вы еще не знаете!!!");
                                                break;
                                            }
                                        case "-":
                                            {
                                                foreach (var x in hero.learnedSpells)
                                                    if (x is ToCure)
                                                        if (hero.ForgetSpell(x as ToCure))
                                                        {
                                                            Console.WriteLine("Забыто!!");
                                                            break;
                                                        }
                                                        else
                                                            Console.WriteLine("Такого заклинания вы еще не знаете!!!");
                                                break;
                                            }
                                        case "@":
                                            {
                                                foreach (var x in hero.learnedSpells)
                                                    if (x is Antidot)
                                                        if (hero.ForgetSpell(x as Antidot))
                                                        {
                                                            Console.WriteLine("Забыто!!");
                                                            break;
                                                        }
                                                        else
                                                            Console.WriteLine("Такого заклинания вы еще не знаете!!!");
                                                break;
                                            }
                                        case "#":
                                            {
                                                foreach (var x in hero.learnedSpells)
                                                    if (x is Armor)
                                                        if (hero.ForgetSpell(x as Armor))
                                                        {
                                                            Console.WriteLine("Забыто!!");
                                                            break;
                                                        }
                                                        else
                                                            Console.WriteLine("Такого заклинания вы еще не знаете!!!");
                                                break;
                                            }
                                        case "*":
                                            {
                                                foreach (var x in hero.learnedSpells)
                                                    if (x is NOtDie)
                                                        if (hero.ForgetSpell(x as NOtDie))
                                                        {
                                                            Console.WriteLine("Забыто!!");
                                                            break;
                                                        }
                                                        else
                                                            Console.WriteLine("Такого заклинания вы еще не знаете!!!");
                                                break;
                                            }
                                        case "%":
                                            {
                                                foreach (var x in hero.learnedSpells)
                                                    if (x is Antidot)
                                                        if (hero.ForgetSpell(x as Antidot))
                                                        {
                                                            Console.WriteLine("Забыто!!");
                                                            break;
                                                        }
                                                        else
                                                            Console.WriteLine("Такого заклинания вы еще не знаете!!!");
                                                break;
                                            }
                                        default:
                                            Console.WriteLine("нет такого заклинания");
                                            break;
                                    }
                                }
                                else
                                    Console.WriteLine("вы не маг!!!");
                                break;
                            }   
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