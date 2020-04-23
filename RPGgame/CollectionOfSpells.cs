using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RPGgame
{
    //1) «Добавить здоровье». Суть этого заклинания – увеличить текущее значение
    //здоровья какого-либо персонажа на заданную величину или до предела,
    //задаваемого текущим значением маны.На единицу добавленного здоровья
    //расходуется две единицы маны.

    class Addhelth : Spell
    {
        public int Added;
        public Addhelth(int Added)
        {
            this.Added = Added;
        }

        //public void HealthUp(object ob)
        //{
        //    if (ob is CharacterInfo)
        //    {
        //        int available = curMP / 2;
        //        //(int)Math.Ceiling((double)curMP / 2);

        //        if (ActivateSpell(available))
        //        {
        //            if ((ob as CharacterInfo).CurrentHealth + available == CharacterInfo.MaxHealth)
        //            {
        //                CurrentMagicPower = 0;
        //                CurrentHealth = CharacterInfo.MaxHealth;
        //            }
        //            if ((ob as CharacterInfo).CurrentHealth + available > CharacterInfo.MaxHealth)
        //            {
        //                CurrentHealth = CharacterInfo.MaxHealth;
        //                CurrentMagicPower -= 2 * (CharacterInfo.MaxHealth - (ob as CharacterInfo).CurrentHealth);
        //            }
        //            if ((ob as CharacterInfo).CurrentHealth + available < CharacterInfo.MaxHealth)
        //            {
        //                CurrentMagicPower = 0;
        //                CurrentHealth += available;
        //            }
        //        }



        //    }
        //}

    }
    //2) «Вылечить». Суть этого заклинания – перевести какого-либо персонажа из
    //состояния «болен» в состояние «здоров или ослаблен». Текущая величина
    //здоровья не изменяется.Заклинание требует 20 единиц маны.

    class ToCure : Spell
    {

    }
    //3) «Противоядие». Суть этого заклинания – перевести какого-либо персонажа
    //из состояния «отравлен» в состояние «здоров или ослаблен». Текущая
    //величина здоровья не изменяется.Заклинание требует 30 единиц маны.

    class Antidot : Spell
    {

    }
    //4) «Оживить». Суть этого заклинания – перевести какого-либо персонажа из
    //состояния «мертв» в состояние «здоров или ослаблен». Текущая величина
    //здоровья становится равной 1. Заклинание требует 150 единиц маны.

    class Revive : Spell
    {

    }
    //5) «Броня». Персонаж, на которого обращено заклинание, становится
    //неуязвимым в течение некоторого промежутка времени, определяемого
    //силой заклинания.Заклинание требует 50 единиц маны на единицу времени.

    class Armor : Spell
    {
        int Time;
        public override void DoMAgicThing(int time, ref MagicCharacter person)
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

    }
}
