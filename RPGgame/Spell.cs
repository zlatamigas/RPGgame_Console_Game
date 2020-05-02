using System;
using System.Collections.Generic;
using System.Text;

namespace RPGgame
{
    public abstract class Spell : IMagican
    {
        public string Name { get; protected set; }
        public Spell() { }
        virtual public void DoMAgicThing(int Damage, CharacterInfo person) {}      
        virtual public void DoMAgicThing(CharacterInfo person) { }
        virtual public void DoMAgicThing() {  }

        public int MinMan { get; protected set; }
        public bool verbal { get; protected set; }
        public bool movement { get; protected set; }
    }
}
