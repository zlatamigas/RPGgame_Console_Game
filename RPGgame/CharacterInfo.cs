using System;
using System.Collections;

namespace RPGgame
{
    public class CharacterInfo : IComparable
    {
        /* Уникальный числовой идентификатор */
        static int next_ID = 0;
        public int ID { get; private set; }

        /* Имя персонажа */
        public string Name { get; private set; }

        /* Пол */
        public enum Gender { male, female };
        public Gender gender { get; private set; }

        /* Состояние (нормальное, ослаблен, болен, отравлен, парализован, мёртв) */
        public enum State { normal, weakend, sick, poisoned, paralyzed, dead };
        public State state { get; set; }//сделал паблик сет потомучто нужно для заклиания

        /* Раса (человек, эльф, орк, дух) */
        public enum Race { human, elf, ork, spirit };
        public Race race { get; private set; }

        /* Возраст*/
        public int Age { get; private set; }

        /* Максимальное значение для здоровья персонажа;*/
        private static int maxHealth = 1000;
        public static int MaxHealth {
            get {return maxHealth;}
        }

        /* Векущее значение здоровья персонажа (неотрицательная величина);*/
        private int curHealth;
        public int CurrentHealth
        {
            get
            {
                return curHealth;
            }
            set
            {
                if (value < 0)
                    value = 0;
                if (value > MaxHealth)
                    value = MaxHealth;
                curHealth = value;
                CheckState();
            }
        }

        /* Если процент здоровья персонажа (отношение текущего здоровья персонажа к максимальному количеству здоровья) 
		становится менее 10, персонаж автоматически переходит из состояния «здоров» в состояние «ослаблен». Если процент 
		здоровья персонажа становится большим или равным 10, персонаж автоматически переходит из состояния «ослаблен» в  состояние
        «здоров». Если текущее значение здоровья равно 0, персонаж автоматически переходит из любого состояния в состояние «мертв».*/
        public void CheckState()
        {
            if (state == State.normal || state == State.weakend || state == State.dead)
            {
                if (curHealth < 100)
                    state = State.weakend;
                if (curHealth >= 100)
                    state = State.normal;
            }
            if (curHealth == 0)
                state = State.dead;
        }

        /* Уязвимость к атакам */
        public bool Invincible { get; set; }

        /* Количество опыта, набранное персонажем.*/
        public int Experiance { get; set; }

        /* Возможность разговаривать в текущий момент времени;*/
        public bool CanTalkNow { get; set; }

        /* Возможность двигаться в текущий момент времени;*/
        public bool MoveNow { get; set; }

        /* Конструктор, задающий значения неизменяемых полей и обеспечивающий уникальность идентификатора для нового объекта; */
        public CharacterInfo(string aname, Gender agender, Race arace)
        {
            ID = next_ID++;

            Name = aname;
            gender = agender;
            Age = arace switch
            {
                Race.human => 47,
                Race.ork => 231,
                Race.elf => 1500,
                Race.spirit => 478,
                _ => throw new ArgumentException("Unknown race!"),
            };
            race = arace;

            curHealth = MaxHealth;
            state = State.normal;

            CanTalkNow = false;
            MoveNow = true;
            Invincible = false;

            Experiance = 0;
            inventory = new ArrayList();
        }

        /* Сравнение персонажей по опыту через реализацию интерфейса IComparable;*/
        public int CompareTo(object obj)
        {
            if (!(obj is IComparable))
                throw new ArgumentException("Cannot compare!");

            CharacterInfo someCharacter = (CharacterInfo)obj;

            if (Experiance < someCharacter.Experiance)
                return -1;
            if (Experiance > someCharacter.Experiance)
                return 1;

            return 0;
        }

        /*У каждого персонажа игры есть мешок (inventory), куда можно помещать
        различные артефакты (количество артефактов одного вида неограниченно) и
        использовать их. Если артефакт не является возобновляемым, он исчезает из
        мешка. Можно использовать только те артефакты, которые имеются в мешке.*/
        public ArrayList inventory;

        /*«Подобрать артефакт и пополнить мешок»*/
        public bool AddArtifact(Artifacts art)
        {
            if (inventory.Count < 20)
            {
                inventory.Add(art);
                return true;
            }
            return false;
        }

        /*«Выбросить артефакт из мешка»*/
        public bool ThrowArtifact(Artifacts art)
        {
            if (inventory.Contains(art))
            {
                inventory.Remove(art);
                return true;
            }
            return false;
        }

        /*«Передать артефакт другому персонажу»*/
        public bool GiveAwayArtifact(Artifacts art, CharacterInfo target)
        {
            if (inventory.Contains(art))
                if (target.AddArtifact(art))
                {
                    inventory.Remove(art);
                    return true;
                }
            return false;
        }

        /*«Использовать артефакт»*/
        public bool ActivateArtifact(Artifacts ourartifact, CharacterInfo target)
        {
            if (inventory.Contains(ourartifact))
                if (ourartifact.power != 0)
                {
                    ourartifact.DoMAgicThing(target);
                    if (ourartifact.power == 0 && ourartifact.renewability == false)
                        inventory.Remove(ourartifact);
                    return true;
                }
            return false;
        }
        public bool ActivateArtifact(int expectedPower, Artifacts ourartifact, CharacterInfo target)
        {
            if (inventory.Contains(ourartifact))
                if (ourartifact.power != 0 && expectedPower > 0)
                {
                    int activatePower;
                    if (expectedPower <= ourartifact.power)
                    {
                        activatePower = expectedPower;
                    }
                    else
                        activatePower = ourartifact.power;

                    ourartifact.DoMAgicThing(activatePower, target);
                    if (ourartifact.power == 0 && ourartifact.renewability == false)
                        inventory.Remove(ourartifact);
                    return true;
                }
            return false;
        }

        /* Вывод информации о персонаже в строку (через метод ToString).*/
        public override string ToString()
        {
            string gend;
            if (gender == Gender.male)
                gend = "мужской";
            else
                gend = "женский";

            string race = "";
            switch (this.race)
            {
                case Race.human:
                    race = "человек";
                    break;
                case Race.ork:
                    race = "орк";
                    break;
                case Race.elf:
                    race = "эльф";
                    break;
                case Race.spirit:
                    race = "дух";
                    break;
            }

            string state = "";
            switch (this.state)
            {
                case State.dead:
                    state = "мертв";
                    break;
                case State.normal:
                    state = "нормальное";
                    break;
                case State.paralyzed:
                    state = "парализован";
                    break;
                case State.poisoned:
                    state = "отравлен";
                    break;
                case State.sick:
                    state = "болен";
                    break;
                case State.weakend:
                    state = "ослаблен";
                    break;
            }

            return string.Format($"ID: {ID}\nИмя персонажа: {Name}\n" +
                $"Раса: {race}\nПол: {gend}\n" +
                $"Возраст: {Age}\nКоличество здоровья: {curHealth} hp\n" +
                $"Состояние здоровья: {state}\nКоличество опыта: {Experiance} xp\n");
        }
    }
}