using System;
using System.Collections.Generic;
using System.Text;

namespace RPGgame
{
    public abstract class Artifacts : IMagican
    { //поля:
        public int power { get; protected set; }
        public bool renewability { get; protected set; }
        public Artifacts() { }
        virtual public void DoMAgicThing(int Damage, MagicCharacter person) {  }
        virtual public void DoMAgicThing(MagicCharacter person) { }
        virtual public void DoMAgicThing() { }

        
    }
}
