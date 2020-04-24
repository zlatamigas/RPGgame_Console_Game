using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RPGgame
{
    //Бутылка с живой водой – увеличивает здоровье персонажа. Здоровье
    //персонажа не может превысить максимальную величину, но артефакт
    //используется полностью! Могут быть малые, средние и большие бутылки,
    //увеличивающие здоровье соответственно на 10, 25 и 50 единиц.Не
    //возобновляемый.


    class Aqua : Artifacts
    {

        public enum LiveBottle { small, medium, big };
        public LiveBottle bottle { get; private set; }
        int num;
        public int BottlePower
        {
            get
            {
                return num;
            }
            set
            {
                if (bottle == LiveBottle.small)
                {
                    num = 10;
                }
                if (bottle == LiveBottle.medium)
                {
                    num = 25;
                }
                if (bottle == LiveBottle.big)
                {
                    num = 50;
                }
            }
        }


        public Aqua(LiveBottle size)
        {
            renewability = false;
            bottle = size;
            power = BottlePower;
        }

        public void IncreaseMana(ref MagicCharacter person)
        {

            person.CurrentHealth += power;
        }



    }
    //Бутылка с мертвой водой – увеличивает ману персонажа, владеющего
    //магией.Мана не может превысить максимальную величину, но артефакт
    //используется полностью! Могут быть малые, средние и большие бутылки
    //увеличивающие ману соответственно на 10, 25 и 50 единиц.Не
    //возобновляемый.
    class Deadwater : Artifacts
    {
        public enum DeadBottle { small, medium, big };
        public DeadBottle bottle { get; private set; }
        int num;
        public int BottlePower
        {
            get
            {
                return num;
            }
            set
            {
                if (bottle == DeadBottle.small)
                {
                    num = 10;
                }
                if (bottle == DeadBottle.medium)
                {
                    num = 25;
                }
                if (bottle == DeadBottle.big)
                {
                    num = 50;
                }
            }
        }


        public Deadwater(DeadBottle size)
        {
            renewability = false;
            bottle = size;
            power = BottlePower;
        }

        public void IncreaseMana(ref MagicCharacter person)
        {

            person.CurrentMagicPower += power;
        }

    }
    //Посох «Молния». Уменьшает количество здоровья персонажа, против
    //которого был применен этот артефакт, на величину, заданную мощностью
    //(мощность задаётся персонажем при использовании артефакта). Мощность
    //посоха уменьшается на эту величину.Возобновляемый, но непригоден для
    //использования, если его мощность равна нулю.
    class LightningStaff : Artifacts
    {
        public LightningStaff(int Pover)
        {
            renewability = true;
            power = Pover;
        }


    }
    //Декокт из лягушачьих лапок.Переводит какого-либо персонажа из состояния
    //«отравлен» в состояние «здоров или ослаблен». Текущая величина здоровья
    //не изменяется.Не возобновляемый.

    class FrogsFeet : Artifacts
    {
        public FrogsFeet()
        {
            renewability = false;

        }
        public void DoUselessWork(ref MagicCharacter person)
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

        // Ядовитая слюна(накладка на зубы, через которую надо плевать). Переводит
        //какого-либо персонажа из состояния «здоров или ослаблен» в состояние
        //«отравлен». Текущая величина здоровья уменьшается на величину,
        //задаваемую мощностью артефакта.При применении этого артефакта
        //персонаж, против которого он был применен, может умереть!
        //Возобновляемый.
        class PoisonousSaliva : Artifacts
        {
            public PoisonousSaliva(int Pover)
            {
                renewability = true;
                power = Pover;
            }

            public void Poison(ref MagicCharacter person)
            {
                if (person.state == CharacterInfo.State.normal
                    && person.state == CharacterInfo.State.weakend)
                {
                    person.state = CharacterInfo.State.poisoned;
                }
                if (person.CurrentHealth <= power)
                {
                    person.state = CharacterInfo.State.dead;
                }
                else person.CurrentHealth -= power;
            }

        }
        //Глаз василиска.Переводит любого не мёртвого персонажа в состояние
        //«парализован». Не возобновляемый.
        class BasiliskEye : Artifacts
        {
            public BasiliskEye()
            {
                renewability = false;

            }
            public void Paralyze(ref MagicCharacter person)
            {
                if (person.state != CharacterInfo.State.dead)
                {
                    person.state = CharacterInfo.State.paralyzed;
                }
            }


        }
    }
}
