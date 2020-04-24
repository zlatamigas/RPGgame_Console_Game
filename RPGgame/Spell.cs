using System;
using System.Collections.Generic;
using System.Text;

namespace RPGgame
{
    public abstract class Spell : IMagican
    {
        public Spell() { }
        virtual public void DoMAgicThing(int Damage,MagicCharacter person)//поменять потом на объект
        {}
       
        public void DoMAgicThing() { }

        public int MinMan { get; protected set; }
        public bool verbal { get; protected set; }
        public bool moovment { get; protected set; }//components
}
}
