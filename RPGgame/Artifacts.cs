using System;
using System.Collections.Generic;
using System.Text;

namespace RPGgame
{
    class Artifacts : ICollector
    { //поля:
        public int power;
        public bool renewability;
        public Artifacts() { }
        virtual public void UseArtifact(int Damage, ref MagicCharacter person)
        {
            
        }

        public void UseArtifact() { }
    }
}
