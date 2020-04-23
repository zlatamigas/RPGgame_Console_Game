using System;
using System.Collections.Generic;
using System.Text;

namespace RPGgame
{
    /*Создать класс-потомок «персонаж, владеющий магией»*/
    public class MagicCharacter : CharacterInfo
    {

        /*
		 - текущее значение магической энергии (маны) (неотрицательная величина);
		- максимальное значение маны.
		 */
        private int curMP;
        public int CurrentMagicPower
        {
            get
            {
                return curMP;
            }
            set
            {
                if (value < 0)
                    value = 0;
                if (value > MaxMagicPower)
                    value = MaxMagicPower;
                curMP = value;
            }
        }
        static int MaxMagicPower = 100;

        /*Мана расходуется на произнесение заклинаний. Если текущее значение маны
		меньше того количества, которое требуется для произнесения какого-либо
		заклинания, заклинание не может быть произнесено, а количество маны остается
		неизменным.*/

        public MagicCharacter(string aname, string agender, string arace) : base(aname, agender, arace)
        {
            CurrentMagicPower = MaxMagicPower;
        }
        public bool ActivateSpell(int expectedPower, Spell ourspell, object target)
        {
            //if (neededMana > CurrentMagicPower)
            //    return false;
            return true;
        }

        /*Некоторые заклинания обладают силой, причем сила заклинания задается
		волшебником в момент его произнесения. Расход маны в этом случае
		пропорционален силе заклинания. Сила заклинания ограничивается текущим
		значением маны.*/

        public void ConvertIntoPower(int power)
        {
            int koef = 2;
            int mpnow = (int)Math.Ceiling((double)power / koef);//?
            ActivateSpell(mpnow, null, null);//?
        }

        /*Реализовать заклинание «добавление здоровья». Суть этого заклинания – увеличить
		текущее значение здоровья какого-либо персонажа (в том числе и себя) до
		максимального или до предела, задаваемого текущим значением маны. На единицу
		добавленного здоровья расходуется две единицы маны*/

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


        //        //if (ActivateSpell(neededmp))
        //        //{
        //        //	if (neededmp > 100 - (ob as CharacterInfo).CurrentHealth)
        //        //	{
        //        //		(ob as CharacterInfo).CurrentHealth = 100;
        //        //		CuttentMagicPower -= neededmp;
        //        //	}
        //        //	else
        //        //	{
        //        //		CuttentMagicPower = 0;
        //        //		(ob as CharacterInfo).CurrentHealth += neededmp * 2;
        //        //	}
        //        //}
        //    }
        //}
    }
}
