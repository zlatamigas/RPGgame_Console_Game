using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace RPGgame
{
	public class CharacterInfo : IComparable
	{
		public bool Invincible=false;

		/*- уникальный числовой идентификатор (*);*/
		static int next_ID = 0;

		public int ID { get; private set; }

		/*- имя персонажа (*);*/
		public string Name { get; private set; }

		/*- пол (*);*/
		public enum Gender { male, female };
		public Gender gender { get; private set; }

		/*- состояние (нормальное, ослаблен, болен, отравлен, парализован, мёртв);*/
		public enum State { normal, weakend, sick, poisoned, paralyzed, dead };
		public State state { get; set; }//сделал паблик сет потомучто нужно для заклиания

		/*- раса (человек, гном, эльф, орк, гоблин) (*);*/
		public enum Race { human, elf, ork, spirit };
		public Race race { get; private set; }

		/*- возраст;*/
		public int age { get; private set; }

		/*- текущее значение здоровья персонажа (неотрицательная величина);*/
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

		/*- максимальное значение для здоровья персонажа;*/
		public static int MaxHealth = 1000;

		/*- если процент здоровья персонажа (отношение текущего здоровья персонажа к максимальному количеству здоровья) 
		становится менее 10, персонаж автоматически переходит из состояния «здоров» в состояние «ослаблен». Если процент 
		здоровья персонажа становится большим или равным 10, персонаж автоматически переходит из состояния «ослаблен» в  состояние
        «здоров». Если текущее значение здоровья равно 0, персонаж автоматически переходит из любого состояния в состояние 
		«мертв».*/

		public void CheckState(CharacterInfo character)
		{
			if (state == State.normal || state == State.weakend || state == State.dead)
			{
				if (curHealth < 10)
					state = State.weakend;
				if (curHealth >= 10)
					state = State.normal;
			}
			if (curHealth == 0)
				state = State.dead;
		}

		/*- количество опыта, набранное персонажем.*/
		public int Experiance { get; set; }

		/*- возможность разговаривать в текущий момент времени;*/
		public bool CanTalkNow { get; set; }//?

		/*- возможность двигаться в текущий момент времени;*/
		public bool MoveNow { get; set; }

		//////////////////////////////////////////////////////////////////////////////////////////////

		/*- конструктор, задающий значения неизменяемых полей и обеспечивающий уникальность идентификатора для нового объекта; */
		public CharacterInfo(string aname, Gender agender, Race arace)
		{
			ID = next_ID++;
			Name = aname;

			gender = agender;
			curHealth = MaxHealth;
			state = State.normal;
			CanTalkNow = false;
			MoveNow = true;

			race = arace;
			switch (arace)
			{
				case Race.human:
					age = 47;
					break;
				case Race.ork:
					age = 231;
					break;
				case Race.elf:
					age = 1500;
					break;
				case Race.spirit:
					age = 478;
					break;
				default:
					throw new ArgumentException("Unknown race!");
			}
			Experiance = 0;
			inventory = new ArrayList();
		}
		/*- свойства для всех полей (доступ к полям может быть реализован только при помощи свойств);*/
		//(?)

		/*- сравнение персонажей по опыту через реализацию интерфейса IComparable;*/
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

		

		/*- вывод информации о персонаже в строку (через метод ToString).*/

		public override string ToString()
		{
			string gend;
			if (gender == Gender.male)
				gend = "мужской";
			else
				gend = "женский";

			string race = "";

			switch (this.race)
			{
				case Race.human:
					race = "человек";
					break;
				case Race.ork:
					race = "орк";
					break;
				case Race.elf:
					race = "эльф";
					break;
				case Race.spirit:
					race = "дух";
					break;
			}

			string state = "";

			switch (this.state)
			{
				case State.dead:
					state = "мертв";
					break;
				case State.normal:
					state = "нормальное";
					break;
				case State.paralyzed:
					state = "парализован";
					break;
				case State.poisoned:
					state = "отравлен";
					break;
				case State.sick:
					state = "болен";
					break;
				case State.weakend:
					state = "ослаблен";
					break;
			}

			return string.Format($"ID: {ID}\nИмя персонажа: {Name}\n" +
				$"Раса: {race}\nПол: {gend}\n" +
				$"Возраст: {age}\nКоличество здоровья: {curHealth} hp\n" +
				$"Состояние здоровья: {state}\nКоличество опыта: {Experiance} xp\n");
		}

		public bool ActivateArtifact(Artifacts ourartifact, CharacterInfo target)
		{
			if (inventory.Contains(ourartifact))
				if (ourartifact.power != 0)
				{
					ourartifact.DoMAgicThing(target);
					if (ourartifact.power == 0 && ourartifact.renewability == false)
						inventory.Remove(ourartifact);
					return true;
				}
			return false;
		}

		public bool ActivateArtifact(int expectedPower, Artifacts ourartifact, CharacterInfo target)
		{
			if (inventory.Contains(ourartifact))
				if (ourartifact.power != 0)
					if (expectedPower <= ourartifact.power)
					{
						ourartifact.DoMAgicThing(expectedPower, target);
						if (ourartifact.power == 0 && ourartifact.renewability == false)
							inventory.Remove(ourartifact);
						return true;
					}
			return false;
		}

		public ArrayList inventory;//warning
		public bool AddArtifact(Artifacts art) {
			if (inventory.Count < 20) {
				inventory.Add(art);
				return true;
			}
			return false;
		}

		public bool ThrowArtifact(Artifacts art) {
			if (inventory.Contains(art)) {
				inventory.Remove(art);
				return true;
			}
			return false;
		}

		public bool GiveAwayArtifact(Artifacts art, CharacterInfo target) {

			if (inventory.Contains(art))
				if (target.AddArtifact(art))
				{
					inventory.Remove(art);
					return true;
				}
			
			return false;
		}
	}
}

