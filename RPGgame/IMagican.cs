namespace RPGgame
{
    public interface IMagican
    {
        void DoMAgicThing(int Damage, CharacterInfo person);
        void DoMAgicThing(CharacterInfo person) { }
        void DoMAgicThing();
    }
}
