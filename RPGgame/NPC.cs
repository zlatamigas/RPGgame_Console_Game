using System;
using System.Collections.Generic;
using System.Text;

namespace RPGgame
{
    class NPC: IComparable
	{
		public string Name { get; private set; }

		public enum State { normal, weakend, sick, poisoned, paralyzed, dead };
		public State state { get; set; }


		public static int MaxHealth = 100;
		private int curHealth;
		public int CurrentHealth
		{
			get
			{
				return curHealth;
			}
			set
			{
				if (value < 0)
					value = 0;
				if (value > MaxHealth)
					value = MaxHealth;
				curHealth = value;
				CheckState(this);
			}
		}
		public void CheckState(NPC character)
		{
			if (CurrentHealth < 10)
				state = State.weakend;
			if (CurrentHealth >= 10 && state == State.weakend)
				state = State.normal;
			if (CurrentHealth == 0)
				state = State.dead;
		}

		public int Experiance { get; set; }
		public bool CanTalkNow { get; set; }
		public bool MoveNow { get; set; }
		public int Protection { get; set; }
		public bool Agressive { get; private set; }

		public NPC(string aname, bool agr)
		{
			Name = aname;

			curHealth = MaxHealth;
			state = State.normal;

			CanTalkNow = false;
			MoveNow = true;

			Experiance = 0;

			CurrentMagicPower = MaxMagicPower;

			Agressive = agr;
		}
		
		public int CompareTo(object obj)
		{
			if (!(obj is IComparable))
				throw new ArgumentException("Cannot compare!");

			CharacterInfo someCharacter = (CharacterInfo)obj;

			if (this.Experiance < someCharacter.Experiance)
				return -1;
			if (this.Experiance > someCharacter.Experiance)
				return 1;

			return 0;
		}


		private int curMP;
		public int CurrentMagicPower
		{
			get
			{
				return curMP;
			}
			set
			{
				if (value < 0)
					value = 0;
				if (value > MaxMagicPower)
					value = MaxMagicPower;
				curMP = value;
			}
		}
		static int MaxMagicPower = 100;

		public bool ActivateSpell(int expectedPower, Spell ourspell, object target)
		{
			if (ourspell.MinMan <= CurrentMagicPower)
			{
				ourspell.DoMAgicThing(expectedPower, target as MagicCharacter);//поменять потом на объект
				return true;
			}
			return false;
		}
	}
}
