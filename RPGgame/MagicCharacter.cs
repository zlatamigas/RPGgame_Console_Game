using System.Collections;

namespace RPGgame
{
    /*Создать класс-потомок «персонаж, владеющий магией»*/
    public class MagicCharacter : CharacterInfo
    {
        /* Максимальное значение маны.*/
        static readonly int MaxMagicPower = 1000;

        /* Текущее значение магической энергии (маны) (неотрицательная величина);*/		
        private int curMP;
        
        /*Мана расходуется на произнесение заклинаний. Если текущее значение маны
		меньше того количества, которое требуется для произнесения какого-либо
		заклинания, заклинание не может быть произнесено, а количество маны остается
		неизменным.*/
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

        /* Конструктор для персонажа, владеющего магией; */
        public MagicCharacter(string aname, Gender agender, Race arace) : base(aname, agender, arace)
        {
            CurrentMagicPower = MaxMagicPower;
            learnedSpells = new ArrayList();
        }

        /*Персонаж, владеющий магией, может изучить различные заклинания. После
        изучения заклинания могут быть реализованы. Можно реализовывать только
        изученные заклинания.*/
        public ArrayList learnedSpells;

        /*«Выучить заклинание»*/
        public bool LearnSpell(Spell spell)
        {
            if (learnedSpells.Count >= 5)
                return false;

            foreach (Spell x in learnedSpells)
                if (spell.GetType() == x.GetType())
                    return false;

            learnedSpells.Add(spell);
            return true;
        }

        /*«Забыть заклинание»*/
        public bool ForgetSpell(Spell spell)
        {
            if (learnedSpells.Contains(spell))
            {
                learnedSpells.Remove(spell);
                return true;
            }
            return false;
        }

        /*«Произнести заклинание»*/
        public bool ActivateSpell(int expectedPower, Spell ourspell, CharacterInfo target)
        {
            if (learnedSpells.Contains(ourspell))
                if (ourspell.MinMan <= CurrentMagicPower)
                    if (expectedPower >= ourspell.MinMan)
                    {
                        int activatePower;
                        if (expectedPower <= CurrentMagicPower)
                            activatePower = expectedPower;
                        else
                            activatePower = CurrentMagicPower;
                        
                        CurrentMagicPower -= activatePower;
                        ourspell.DoMAgicThing(activatePower, target);
                        return true;
                    }

            return false;
        }
        public bool ActivateSpell(Spell ourspell, CharacterInfo target)
        {
            if (learnedSpells.Contains(ourspell))
                if (ourspell.MinMan <= CurrentMagicPower)
                {
                    CurrentMagicPower -= ourspell.MinMan;
                    ourspell.DoMAgicThing(target);
                    return true;
                }
            return false;
        }

        /* Вывод информации о персонаже в строку (через метод ToString).*/
        public override string ToString()
        {
            return base.ToString() + $"MP: {CurrentMagicPower}\n";
        }
    }
}