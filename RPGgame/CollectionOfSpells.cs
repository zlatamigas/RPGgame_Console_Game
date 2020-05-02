using System.Threading;

namespace RPGgame
{
    /*1) «Добавить здоровье». Суть этого заклинания – увеличить текущее значение
    здоровья какого-либо персонажа на заданную величину или до предела,
    задаваемого текущим значением маны.На единицу добавленного здоровья
    расходуется две единицы маны.*/
    class Addhelth : Spell
    {
        public Addhelth()
        {
            Name = "Добавить здоровье";
            MinMan = 2;
            Movement = false;
            Verbal = true;
        }
        override public void DoMAgicThing(int Damage, CharacterInfo person)
        {
            if (Damage % 2 == 0)
                person.CurrentHealth += Damage / 2;
            else
                person.CurrentHealth += (Damage - 1) / 2;
        }
    }
    /*2) «Вылечить». Суть этого заклинания – перевести какого-либо персонажа из
    состояния «болен» в состояние «здоров или ослаблен». Текущая величина
    здоровья не изменяется.Заклинание требует 20 единиц маны.*/
    class ToCure : Spell
    {
        public ToCure()
        {
            Name = "Вылечить";
            MinMan = 20;
            Movement = false;
            Verbal = true;
        }
        override public void DoMAgicThing(CharacterInfo person)
        {
            if (person.state == CharacterInfo.State.sick)
            {
                if (person.CurrentHealth < 100)
                    person.state = CharacterInfo.State.weakend;
                if (person.CurrentHealth >= 100)
                    person.state = CharacterInfo.State.normal;
            }
        }
    }
    /*3) «Противоядие». Суть этого заклинания – перевести какого-либо персонажа
    из состояния «отравлен» в состояние «здоров или ослаблен». Текущая
    величина здоровья не изменяется.Заклинание требует 30 единиц маны.*/
    class Antidot : Spell
    {
        public Antidot()
        {
            Name = "Противоядие";
            MinMan = 30;
            Movement = false;
            Verbal = true;
        }
        override public void DoMAgicThing(CharacterInfo person)
        {
            if (person.state == CharacterInfo.State.poisoned)
            {
                if (person.CurrentHealth < 100)
                    person.state = CharacterInfo.State.weakend;
                if (person.CurrentHealth >= 100)
                    person.state = CharacterInfo.State.normal;
            }
        }
    }
    /*4) «Оживить». Суть этого заклинания – перевести какого-либо персонажа из
    состояния «мертв» в состояние «здоров или ослаблен». Текущая величина
    здоровья становится равной 1. Заклинание требует 150 единиц маны.*/
    class Revive : Spell
    {
        public Revive()
        {
            Name = "Оживить";
            MinMan = 150;
            Movement = true;
            Verbal = true;
        }
        override public void DoMAgicThing(CharacterInfo person)
        {
            if (person.state == CharacterInfo.State.dead)
                person.CurrentHealth = 1;
        }
    }
    /*5) «Броня». Персонаж, на которого обращено заклинание, становится
    неуязвимым в течение некоторого промежутка времени, определяемого
    силой заклинания.Заклинание требует 50 единиц маны на единицу времени.*/
    class Armor : Spell
    {
        public Armor()
        {
            Name = "Броня";
            MinMan = 50;
            Movement = true;
            Verbal = false;
        }
        int Time;
        public override void DoMAgicThing(int usedMana, CharacterInfo person)
        {
            person.Invincible = true;
            Time = (usedMana / MinMan) * 3000;
            Thread t = new Thread(new ParameterizedThreadStart(SleepNow));
            t.Start(person);
        }
        private void SleepNow(object person)
        {
            Thread.Sleep(Time);
            (person as CharacterInfo).Invincible = false;
        }
    }
    /*6) «Отомри!» Суть этого заклинания – перевести какого-либо персонажа из
    состояния «парализован» в состояние «здоров или ослаблен». Текущая
    величина здоровья становится равной 1. Заклинание требует 85 единиц маны.*/
    class NOtDie : Spell
    {
        public NOtDie()
        {
            Name = "Отомри!";
            MinMan = 85;
            Movement = false;
            Verbal = true;
        }
        override public void DoMAgicThing(CharacterInfo person)
        {
            if (person.state == CharacterInfo.State.paralyzed)
            {
                if (person.CurrentHealth < 100)
                    person.state = CharacterInfo.State.weakend;
                if (person.CurrentHealth >= 100)
                    person.state = CharacterInfo.State.normal;
                person.CurrentHealth = 1;
            }
        }
    }
}