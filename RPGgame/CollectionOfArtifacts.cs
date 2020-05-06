
namespace RPGgame
{
    /*Бутылка с живой водой – увеличивает здоровье персонажа.Здоровье
    персонажа не может превысить максимальную величину, но артефакт
    используется полностью! Могут быть малые, средние и большие бутылки,
    увеличивающие здоровье соответственно на 10, 25 и 50 единиц.Не
    возобновляемый.*/
    class Aqua : Artifacts
    {
        public enum LiveBottle { small, medium, big };
        public LiveBottle bottle { get; private set; }
        public Aqua(LiveBottle size)
        {
            Name = "Бутылка с живой водой ";
            renewability = false;
            bottle = size;
            if (bottle == LiveBottle.small)
            {
                power = 10;
                Name += "(10)";
            }
            if (bottle == LiveBottle.medium)
            {
                power = 25;
                Name += "(25)";
            }
            if (bottle == LiveBottle.big)
            {
                power = 50;
                Name += "(50)";
            }
        }
        override public void DoMAgicThing(CharacterInfo person)
        {
            person.CurrentHealth += power;
            power = 0;
        }
    }

    /*Бутылка с мертвой водой – увеличивает ману персонажа, владеющего
    магией.Мана не может превысить максимальную величину, но артефакт
    используется полностью! Могут быть малые, средние и большие бутылки
    увеличивающие ману соответственно на 10, 25 и 50 единиц.Не
    возобновляемый.*/
    class Deadwater : Artifacts
    {
        public enum DeadBottle { small, medium, big };
        public DeadBottle bottle { get; private set; }
        public Deadwater(DeadBottle size)
        {
            Name = "Бутылка с мертвой водой ";
            renewability = false;
            bottle = size;
            if (bottle == DeadBottle.small)
            {
                power = 10;
                Name += "(10)";
            }
            if (bottle == DeadBottle.medium)
            {
                power = 25;
                Name += "(25)";
            }
            if (bottle == DeadBottle.big)
            {
                power = 50;
                Name += "(50)";
            }
        }
        override public void DoMAgicThing(CharacterInfo person)
        {
            if (person is MagicCharacter)
                (person as MagicCharacter).CurrentMagicPower += power;
            power = 0;
        }
    }

    /*Посох «Молния». Уменьшает количество здоровья персонажа, против
    которого был применен этот артефакт, на величину, заданную мощностью
    (мощность задаётся персонажем при использовании артефакта). Мощность
    посоха уменьшается на эту величину.Возобновляемый, но непригоден для
    использования, если его мощность равна нулю.*/
    class LightningStaff : Artifacts
    {
        public LightningStaff()
        {
            Name = "Посох «Молния»";
            renewability = true;
            power = 100;
        }
        override public void DoMAgicThing(int Damage, CharacterInfo person)
        {
            if (person.Invincible == false)
                person.CurrentHealth -= Damage;
            power -= Damage;
            Name = "Посох «Молния» силой " + power.ToString();
        }
    }

    /*Декокт из лягушачьих лапок.Переводит какого-либо персонажа из состояния
    «отравлен» в состояние «здоров или ослаблен». Текущая величина здоровья
    не изменяется.Не возобновляемый.*/
    class Decoction : Artifacts
    {
        public Decoction()
        {
            Name = "Декокт из лягушачьих лапок";
            power = 1;
            renewability = false;
        }
        override public void DoMAgicThing(CharacterInfo person)
        {
            if (person.state == CharacterInfo.State.poisoned)
            {
                if (person.CurrentHealth < 100)
                    person.state = CharacterInfo.State.weakend;
                else
                    person.state = CharacterInfo.State.normal;
            }
            power = 0;
        }
    }

    /*Ядовитая слюна(накладка на зубы, через которую надо плевать). Переводит
    какого-либо персонажа из состояния «здоров или ослаблен» в состояние
    «отравлен». Текущая величина здоровья уменьшается на величину,
    задаваемую мощностью артефакта. При применении этого артефакта
    персонаж, против которого он был применен, может умереть!
    Возобновляемый.*/
    class PoisonousSaliva : Artifacts
    {
        public PoisonousSaliva()
        {
            Name = "Ядовитая слюна";
            renewability = true;
            power = 50;
        }
        override public void DoMAgicThing(int Damage, CharacterInfo person)
        {
            if (person.Invincible == false)
            {
                person.CurrentHealth -= Damage;

                if (person.state == CharacterInfo.State.normal || person.state == CharacterInfo.State.weakend)
                    person.state = CharacterInfo.State.poisoned;
            }
            power -= Damage;
            Name = "Ядовитая слюна силой " + power.ToString();
        }
    }

    /*Глаз василиска.Переводит любого не мёртвого персонажа в состояние
    «парализован». Не возобновляемый.*/
    class BasiliskEye : Artifacts
    {
        public BasiliskEye()
        {
            Name = "Глаз василиска";
            power = 1;
            renewability = false;
        }
        override public void DoMAgicThing(CharacterInfo person)
        {
            if (person.state != CharacterInfo.State.dead)
                person.state = CharacterInfo.State.paralyzed;
            power = 0;
        }
    }

    /*Исцеляющий камень. Увеличивает текущее значение
    здоровья какого-либо персонажа на заданную величину или до предела,
    задаваемого мощностью артефакта. На единицу добавленного здоровья
    расходуется две единицы мощности артефакта.*/
    class Curing : Artifacts
    {
        public Curing()
        {
            Name = "Исцеляющий камень";
            renewability = true;
            power = 1000;
        }
        override public void DoMAgicThing(int Damage, CharacterInfo person)
        {
            if (Damage >= 2)
            {
                if (Damage % 2 == 0)
                    person.CurrentHealth += Damage / 2;
                else
                    person.CurrentHealth += (Damage - 1) / 2;
                power -= Damage;
                Name = "Исцеляющий камень силой " + power.ToString();
            }
        }
    }
}