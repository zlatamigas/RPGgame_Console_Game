using System;
using System.Collections.Generic;
using System.Text;

namespace RPGgame
{
	/*Создать класс «персонаж ролевой игры». Включить в описание класса следующие поля:*/
	public class CharacterInfo : IComparable
	{
		public int Protection { get; set; }

		/*- уникальный числовой идентификатор (*);*/
		static int next_ID = 0;//?

		public int ID { get; private set; }

		/*- имя персонажа (*);*/
		public string Name { get; private set; }


		/*- пол (*);*/
		public enum Gender { male, female };
		public Gender gender { get; private set; }


		/*- состояние (нормальное, ослаблен, болен, отравлен, парализован, мёртв);*/
		public enum State { normal, weakend, sick, poisoned, paralyzed, dead };
		public State state { get; private set; }

		/*- раса (человек, гном, эльф, орк, гоблин) (*);*/
		public enum Race { human, elf, ork, wizard };
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
		public static int MaxHealth = 100;

		/*- количество опыта, набранное персонажем.*/
		public int Experiance { get; set; }


		/*- возможность разговаривать в текущий момент времени;*/
		public bool CanTalkNow { get; set; }//?

		/*- возможность двигаться в текущий момент времени;*/
		public bool MoveNow { get; set; }


		//////////Звездочкой помечены поля, не изменяющиеся после создания персонажа.////////////////////////////////////////////////////////////////////////////////////

		/*- конструктор, задающий значения неизменяемых полей и обеспечивающий уникальность идентификатора для нового объекта; */
		public CharacterInfo(string aname, string agender, string arace)
		{
			ID = next_ID++;
			Name = aname;//отдельно пользовательское и имя перса(?)
			if (agender == "м")
				gender = Gender.male;
			if (agender == "ж")
				gender = Gender.female;
			curHealth = MaxHealth;
			state = State.normal;
			CanTalkNow = false;
			MoveNow = true;
			switch (arace)
			{
				case "ч":
					race = Race.human;
					age = 47;
					break;
				case "o":
					race = Race.ork;
					age = 231;
					break;
				case "э":
					race = Race.elf;
					age = 1500;
					break;
				case "м":
					race = Race.wizard;
					age = 478;
					break;
				default:
					throw new ArgumentException("Unknown race!");
			}
			Experiance = 0;

		}
		/*- свойства для всех полей (доступ к полям может быть реализован только при помощи свойств);*/
		//(?)

		/*- сравнение персонажей по опыту через реализацию интерфейса IComparable;*/
		public int CompareTo(object obj)
		{
			if (!(obj is IComparable))//??
				throw new ArgumentException("Cannot compare!");

			CharacterInfo someCharacter = (CharacterInfo)obj;

			if (this.Experiance < someCharacter.Experiance)
				return -1;
			if (this.Experiance > someCharacter.Experiance)
				return 1;

			return 0;
		}

		/*- если процент здоровья персонажа (отношение текущего здоровья персонажа к максимальному количеству здоровья) 
		становится менее 10, персонаж автоматически переходит из состояния «здоров» в состояние «ослаблен». Если процент 
		здоровья персонажа становится большим или равным 10, персонаж автоматически переходит из состояния «ослаблен» в  состояние
        «здоров». Если текущее значение здоровья равно 0, персонаж автоматически переходит из любого состояния в состояние 
		«мертв».*/

		public void CheckState(CharacterInfo character)
		{
			if (CurrentHealth < 10)
				state = State.weakend;
			if (CurrentHealth >= 10 && state == State.weakend)
				state = State.normal;
			if (CurrentHealth == 0)
				state = State.dead;
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
				case Race.wizard:
					race = "маг";
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

			return String.Format($"ID: {this.ID}\nИмя персонажа: {this.Name}\n" +
				$"Раса: {race}\nПол: {gend}\n" +
				$"Возраст: {this.age}\nКоличество здоровья: {this.curHealth} hp\n" +
				$"Состояние здоровья: {state}\nКоличество опытв: {this.Experiance} xp");

		}
	}
}

