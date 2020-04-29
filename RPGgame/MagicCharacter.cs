using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace RPGgame
{
    /*Создать класс-потомок «персонаж, владеющий магией»*/
    public class MagicCharacter : CharacterInfo
    {
        /* - текущее значение магической энергии (маны) (неотрицательная величина);
		- максимальное значение маны.	 */
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
        static int MaxMagicPower = 1000;

        /*Мана расходуется на произнесение заклинаний. Если текущее значение маны
		меньше того количества, которое требуется для произнесения какого-либо
		заклинания, заклинание не может быть произнесено, а количество маны остается
		неизменным.*/
        public MagicCharacter(string aname, Gender agender, Race arace) : base(aname, agender, arace)
        {
            CurrentMagicPower = MaxMagicPower;
            learnedSpells = new ArrayList();
        }
        public bool ActivateSpell(int expectedPower, Spell ourspell, CharacterInfo target)//expectedPower - активирующая мана
        {
            if (learnedSpells.Contains(ourspell))
                if (ourspell.MinMan <= CurrentMagicPower)
                    if (expectedPower >= ourspell.MinMan && expectedPower <= CurrentMagicPower)
                    {
                        this.CurrentMagicPower -= expectedPower;
                        ourspell.DoMAgicThing(expectedPower, target);
                        return true;
                    }
            return false;
        }
        public bool ActivateSpell(Spell ourspell, CharacterInfo target)
        {
            if (learnedSpells.Contains(ourspell))
                if (ourspell.MinMan <= CurrentMagicPower)
                {
                    this.CurrentMagicPower -= ourspell.MinMan;
                    ourspell.DoMAgicThing(target);
                    return true;
                }
            return false;
        }


        /*Некоторые заклинания обладают силой, причем сила заклинания задается
		волшебником в момент его произнесения. Расход маны в этом случае
		пропорционален силе заклинания. Сила заклинания ограничивается текущим
		значением маны.*/


        ArrayList learnedSpells;
        public bool LearnSpell(Spell spell)
        {
            if (!learnedSpells.Contains(spell))
                if (learnedSpells.Count < 5)
                {
                    learnedSpells.Add(spell);
                    return true;
                }
            return false;
        }

        public bool ForgetSpell(Spell spell)
        {
            if (learnedSpells.Contains(spell))
            {
                learnedSpells.Remove(spell);
                return true;
            }
            return false;
        }

    }
}
