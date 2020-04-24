using System;
using System.Collections.Generic;
using System.Text;

namespace RPGgame
{
    interface ICollector
    { /// <summary>
      /// выполнить магическое воздействие.
      /// </summary>
      /// <param name="Damage">Сила воздействия</param>
      /// <param name="person">Персонаж</param>

        void UseArtifact(int Damage, ref MagicCharacter person);
        void UseArtifact();
    }
}
