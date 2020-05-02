
namespace RPGgame
{
    public abstract class Artifacts : IMagican
    {
        public string Name { get; protected set; }
        public int power;
        public bool renewability { get; protected set; }
        public Artifacts() { }
        virtual public void DoMAgicThing(int Damage, CharacterInfo person) { }
        virtual public void DoMAgicThing(CharacterInfo person) { }
        virtual public void DoMAgicThing() { }
    }
}
