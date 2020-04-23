namespace RPGgame
{
    public interface IMagican
    {
        /// <summary>
        /// выполнить магическое воздействие.
        /// </summary>
        /// <param name="Damage">Сила воздействия</param>
        /// <param name="person">Персонаж</param>

        void DoMAgicThing(int Damage, ref MagicCharacter person);
        void DoMAgicThing();//хз зачем это ? скажите мне 
    }
}
