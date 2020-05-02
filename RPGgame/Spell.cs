
namespace RPGgame
{
    public abstract class Spell : IMagican
    {
        public string Name { get; protected set; }
        public int MinMan { get; protected set; }
        public bool Verbal { get; protected set; }
        public bool Movement { get; protected set; }
        public Spell() { }
        virtual public void DoMAgicThing(int Damage, CharacterInfo person) { }      
        virtual public void DoMAgicThing(CharacterInfo person) { }
        virtual public void DoMAgicThing() { }
    }
}
