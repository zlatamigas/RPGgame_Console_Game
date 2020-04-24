namespace RPGgame
{
    public interface IMagican
    {
        /// <summary>
        /// выполнить магическое воздействие.
        /// </summary>
        /// <param name="Damage">Сила воздействия</param>
        /// <param name="person">Персонаж</param>
        void DoMAgicThing(int Damage, MagicCharacter person);//поменять потом на объект
        void DoMAgicThing();//хз зачем это ? скажите мне //для активации артефактов(возможно)
    }
}
