﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RPGgame
{
    public abstract class Artifacts : IMagican
    {
        public int power;
        public bool renewability { get; protected set; }
        public Artifacts() { }
        virtual public void DoMAgicThing(int Damage, CharacterInfo person) {  }
        virtual public void DoMAgicThing(CharacterInfo person) { }
        virtual public void DoMAgicThing() { }

        
    }
}
