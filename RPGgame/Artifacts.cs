using System;
using System.Collections.Generic;
using System.Text;

namespace RPGgame
{
    public abstract class Artifacts : IMagican
    { //поля:
        public int power;
        public bool renewability;
        public Artifacts() { }
        public void DoMAgicThing(int Damage, MagicCharacter person) { }
        public void DoMAgicThing() { }

        //virtual public void UseArtifact(int Damage, ref MagicCharacter person) { }
        //public void UseArtifact() { }
    }
}
