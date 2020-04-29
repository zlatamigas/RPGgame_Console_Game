﻿using System;
using System.Threading;

namespace RPGgame
{
    //1) «Добавить здоровье». Суть этого заклинания – увеличить текущее значение
    //здоровья какого-либо персонажа на заданную величину или до предела,
    //задаваемого текущим значением маны.На единицу добавленного здоровья
    //расходуется две единицы маны.

    class Addhelth : Spell//все проверки происходят в классе магии вроде
    {
        Addhelth() 
        {
            MinMan = 2;
            movement = false;
            verbal = true;
        }
        override public void DoMAgicThing(int Damage, CharacterInfo person)//Damage - потраченные мп
        {
            if (Damage % 2 == 0) {
                person.CurrentHealth += Damage / 2;
            }
            else {
                person.CurrentHealth += (Damage-1)/2;
            }
        }
    }
    //2) «Вылечить». Суть этого заклинания – перевести какого-либо персонажа из
    //состояния «болен» в состояние «здоров или ослаблен». Текущая величина
    //здоровья не изменяется.Заклинание требует 20 единиц маны.

    class ToCure : Spell
    {
        ToCure() 
        {
            MinMan = 20;
            movement = false;
            verbal = true;
        }
        override public void DoMAgicThing(CharacterInfo person)
        {
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
            }
        }
    }
    //3) «Противоядие». Суть этого заклинания – перевести какого-либо персонажа
    //из состояния «отравлен» в состояние «здоров или ослаблен». Текущая
    //величина здоровья не изменяется.Заклинание требует 30 единиц маны.

    class Antidot : Spell
    {
        Antidot()
        {
            MinMan = 30;
            movement = false;
            verbal = true;
        }
        override public void DoMAgicThing(CharacterInfo person)
        {

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
            }
        }
    }
    //4) «Оживить». Суть этого заклинания – перевести какого-либо персонажа из
    //состояния «мертв» в состояние «здоров или ослаблен». Текущая величина
    //здоровья становится равной 1. Заклинание требует 150 единиц маны.

    class Revive : Spell
    {
        Revive()
        {
            MinMan = 150;
            movement = true;
            verbal = true;
        }
        override public void DoMAgicThing(CharacterInfo person)
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
                person.CurrentHealth = 1;
            }
        }
    }
    //5) «Броня». Персонаж, на которого обращено заклинание, становится
    //неуязвимым в течение некоторого промежутка времени, определяемого
    //силой заклинания.Заклинание требует 50 единиц маны на единицу времени.

    class Armor : Spell
    {
        Armor()
        {
            MinMan = 50;
            movement = true;
            verbal = false;
        }
        int Time;
        public override void DoMAgicThing(int usedMana, CharacterInfo person)
        {
            int firstprotection = person.Protection;
            person.Protection = 100;
            Time = (usedMana/MinMan)*1000;
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
        NotExpeliarmus()
        {
            MinMan = 85;
            movement = false;
            verbal = true;
        }
        override public void DoMAgicThing(CharacterInfo person)
        {
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
                person.CurrentHealth = 1;
            }
        }
    }
}
