using System;
using System.Threading;

namespace RPGgame
{
    //1) «Добавить здоровье». Суть этого заклинания – увеличить текущее значение
    //здоровья какого-либо персонажа на заданную величину или до предела,
    //задаваемого текущим значением маны.На единицу добавленного здоровья
    //расходуется две единицы маны.

    class Addhelth : Spell//все проверки происходят в классе магии вроде
    {
        override public void DoMAgicThing(int Damage, MagicCharacter person)//Damage - потраченные мп
        {
            MinMan = 2;
            if (Damage % 2 == 0) {
                person.CurrentHealth += Damage / 2;
                person.CurrentMagicPower -= Damage;
            }
            else {
                person.CurrentHealth += (Damage-1)/2;
                person.CurrentMagicPower -= Damage;
            }
        }
    }
    //2) «Вылечить». Суть этого заклинания – перевести какого-либо персонажа из
    //состояния «болен» в состояние «здоров или ослаблен». Текущая величина
    //здоровья не изменяется.Заклинание требует 20 единиц маны.

    class ToCure : Spell
    {
        override public void DoMAgicThing(MagicCharacter person)
        {
            MinMan = 20;

            if (person.state == CharacterInfo.State.sick)
            {
                if (person.CurrentHealth < 10)
                {
                    person.state = CharacterInfo.State.weakend;
                }
                if (person.CurrentHealth >= 10)
                {
                    person.state = CharacterInfo.State.normal;
                }
                person.CurrentMagicPower -= MinMan;
            }
        }
    }
    //3) «Противоядие». Суть этого заклинания – перевести какого-либо персонажа
    //из состояния «отравлен» в состояние «здоров или ослаблен». Текущая
    //величина здоровья не изменяется.Заклинание требует 30 единиц маны.

    class Antidot : Spell
    {
        override public void DoMAgicThing(MagicCharacter person)
        {
            MinMan = 30;

            if (person.state == CharacterInfo.State.poisoned)
            {
                if (person.CurrentHealth < 10)
                {
                    person.state = CharacterInfo.State.weakend;
                }
                if (person.CurrentHealth >= 10)
                {
                    person.state = CharacterInfo.State.normal;
                }
                person.CurrentMagicPower -= MinMan;
            }
        }
    }
    //4) «Оживить». Суть этого заклинания – перевести какого-либо персонажа из
    //состояния «мертв» в состояние «здоров или ослаблен». Текущая величина
    //здоровья становится равной 1. Заклинание требует 150 единиц маны.

    class Revive : Spell
    {
        override public void DoMAgicThing(MagicCharacter person)
        {
            MinMan = 150;
            if (person.state == CharacterInfo.State.dead)
            {
                if (person.CurrentHealth < 10)
                {
                    person.state = CharacterInfo.State.weakend;
                }
                if (person.CurrentHealth >= 10)
                {
                    person.state = CharacterInfo.State.normal;
                }
                person.CurrentMagicPower -= MinMan;
                person.CurrentHealth = 1;
            }
        }
    }
    //5) «Броня». Персонаж, на которого обращено заклинание, становится
    //неуязвимым в течение некоторого промежутка времени, определяемого
    //силой заклинания.Заклинание требует 50 единиц маны на единицу времени.

    class Armor : Spell
    {
        int Time;
        public override void DoMAgicThing(int time, MagicCharacter person)
        {
            int firstprotection = person.Protection;
            person.Protection = 100;
            Time = time;
            Thread t = new Thread(SleepNow);
            t.Start();
            t.Join();
            person.Protection = firstprotection;
        }
        private void SleepNow()
        {
            Thread.Sleep(Time);
        }
    }
    //6) «Отомри!» Суть этого заклинания – перевести какого-либо персонажа из
    //состояния «парализован» в состояние «здоров или ослаблен». Текущая
    //величина здоровья становится равной 1. Заклинание требует 85 единиц маны.
    class NotExpeliarmus : Spell
    {
        override public void DoMAgicThing(MagicCharacter person)
        {
            MinMan = 85;
            if (person.state == CharacterInfo.State.paralyzed)
            {
                if (person.CurrentHealth < 10)
                {
                    person.state = CharacterInfo.State.weakend;
                }
                if (person.CurrentHealth >= 10)
                {
                    person.state = CharacterInfo.State.normal;
                }
                person.CurrentMagicPower -= MinMan;
                person.CurrentHealth = 1;
            }
        }
    }
}
