namespace RPGgame
{
    public interface IMagican
    {
        /// <summary>
        /// выполнить магическое воздействие.
        /// </summary>
        /// <param name="Damage">Сила воздействия</param>
        /// <param name="person">Персонаж</param>
        void DoMAgicThing(int Damage, CharacterInfo person);//поменять потом на объект
        void DoMAgicThing(CharacterInfo person) { }
        void DoMAgicThing();
    }
}
