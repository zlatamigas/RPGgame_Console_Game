using System;
using System.Collections.Generic;
using System.Text;

namespace RPGgame
{
    public abstract class Spell : IMagican
    {
        public Spell() { }
        virtual public void DoMAgicThing(int Damage, ref MagicCharacter person)
        {
            //person.CurrentMagicPower -= Damage;
            //if (person.CurrentMagicPower < 0)
            //    person.CurrentMagicPower = 0;
        }

        public void DoMAgicThing() { }

        readonly int MinMan;
        bool verbal, moovment;//components
    }
}
