using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HardMethod
{
	#region IMainModel
	public interface IMainModel
	{
		string Answer { get; }
		string Log { get; }
		DateTime Now { get; }
		int FreeOperatorsCount { get; set; }
		int Key { get; set; }

		event EventHandler Updated;
		void ChangeDayOfWeekChange(int i);
		void ChangeTime(DateTime time);
		void Update();
	}
	#endregion

	public class MainModel : IMainModel
	{
		#region Fields
		private readonly Random _random = new Random();
		private readonly decimal _balance;
		private int _freeOperatorsCount;
		private int _key;
		private DateTime _now;
		private StringBuilder _log = new StringBuilder();
		#endregion

		public MainModel()
		{
			_key = -1;
			_now = DateTime.Now.AddDays(_random.Next(30)).AddHours(_random.Next(24));
			_freeOperatorsCount = _random.Next(100);
			_balance = (decimal)_random.Next(9999) / 10;
		}

		#region Properties
		public string Answer { get; private set; }
		public string Log => _log.ToString();

		public DateTime Now
		{
			get => _now;
			private set
			{
				_now = value;
				_key = -1;
				Update();
			}
		}

		public int FreeOperatorsCount
		{
			get => _freeOperatorsCount;
			set
			{
				_freeOperatorsCount = value;
				Update();
			}
		}

		public int Key
		{
			get => _key;
			set
			{
				_key = value;
				Update();
			}
		}
		#endregion

		public event EventHandler Updated;
		public void ChangeDayOfWeekChange(int i)
		{
			var nowDayOfWeek = (int)Now.DayOfWeek;
			Now = Now.AddDays(i + 1 - nowDayOfWeek);
		}
		public void ChangeTime(DateTime time)
		{
			Now = new DateTime(
				Now.Year,
				Now.Month,
				Now.Day).AddHours(time.Hour).AddMinutes(time.Minute);
		}
		public void Update()
		{
			var map = new Dictionary<DayOfWeek, AnswerBuilder>
			{
				[DayOfWeek.Monday] =
					If(() => PressKeys(
						new PressKey(1, "заблокировать карту", "Карта заблокирована"),
						new PressKey(2, "узнать баланс", $"Ваш баланс: {_balance:N}руб."),
						new PressKey(3, "узнать новости", "Текст новостей..."),
						new PressKey(0, "соединить со оператором", null)))
					.ThenIf(() => IsWorkTime(8, 20))
					.ThenIf(() => FreeOperatorsCountMore(15))
					.Then(ConnectWithOperator)
					.IfCancel(InvateCard),

				[DayOfWeek.Tuesday] =
					If(() => PressKeys(
						new PressKey(1, "заблокировать карту", "Карта заблокирована"),
						new PressKey(2, "узнать баланс", $"Ваш баланс: {_balance:N}руб."),
						new PressKey(3, "оформить кредит", "Кредит оформлен"),
						new PressKey(4, "оформить вклад", "Вклад оформлен"),
						new PressKey(0, "соединить со оператором", null)))
					.ThenIf(() => IsWorkTime(8, 20))
					.ThenIf(() => FreeOperatorsCountMore(25))
					.Then(ConnectWithOperator)
					.IfCancel(InvateCard)
					.IfCancel(InvateMortgage),

				[DayOfWeek.Wednesday] =
					If(() => PressKeys(
						new PressKey(1, "заблокировать карту", "Карта заблокирована"),
						new PressKey(2, "узнать баланс", $"Ваш баланс: {_balance:N}руб."),
						new PressKey(3, "узнать новости", "Текст новостей..."),
						new PressKey(4, "оформить вклад", "Вклад оформлен"),
						new PressKey(0, "соединить со оператором", null)))
					.ThenIf(() => IsWorkTime(8, 20))
					.ThenIf(() => FreeOperatorsCountMore(50))
					.Then(ConnectWithOperator)
					.IfCancel(InvateCard)
					.IfCancel(InvateMortgage),

				[DayOfWeek.Thursday] =
					If(() => PressKeys(
						new PressKey(1, "заблокировать карту", "Карта заблокирована"),
						new PressKey(2, "узнать баланс", $"Ваш баланс: {_balance:N}руб."),
						new PressKey(3, "узнать новости", "Текст новостей..."),
						new PressKey(4, "оформить кредит", "Кредит оформлен"),
						new PressKey(5, "оформить вклад", "Вклад оформлен"),
						new PressKey(0, "соединить со оператором", null)))
					.ThenIf(() => IsWorkTime(8, 20))
					.ThenIf(() => FreeOperatorsCountMore(50))
					.Then(ConnectWithOperator)
					.IfCancel(InvateCard)
					.IfCancel(InvateMortgage),

				[DayOfWeek.Friday] =
					If(() => PressKeys(
						new PressKey(1, "заблокировать карту", "Карта заблокирована"),
						new PressKey(2, "узнать баланс", $"Ваш баланс: {_balance:N}руб."),
						new PressKey(0, "соединить со оператором", null)))
					.ThenIf(() => IsWorkTime(8, 22))
					.ThenIf(() => FreeOperatorsCountMore(75))
					.Then(ConnectWithOperator)
					.IfCancel(InvateCard),

				[DayOfWeek.Saturday] =
					If(() => PressKeys(
						new PressKey(1, "заблокировать карту", "Карта заблокирована"),
						new PressKey(2, "узнать баланс", $"Ваш баланс: {_balance:N}руб."),
						new PressKey(3, "оформить кредит", "Кредит оформлен"),
						new PressKey(4, "оформить вклад", "Вклад оформлен"),
						new PressKey(0, "соединить со оператором", null)))
					.ThenIf(IsWorkDay)
					.ThenIf(() => IsWorkTime(8, 15))
					.ThenIf(() => FreeOperatorsCountMore(20))
					.Then(ConnectWithOperator)
					.IfCancel(InvateCard),

				[DayOfWeek.Sunday] =
					If(() => PressKeys(
						new PressKey(1, "заблокировать карту", "Карта заблокирована"),
						new PressKey(2, "узнать баланс", $"Ваш баланс: {_balance:N}руб."),
						new PressKey(3, "узнать новости", "Текст новостей..."),
						new PressKey(0, "соединить со оператором", null)))
					.ThenIf(IsWorkDay)
					.ThenIf(() => IsWorkTime(8, 14))
					.ThenIf(() => FreeOperatorsCountMore(20))
					.Then(ConnectWithOperator),
			};

			_log.Clear();
			foreach (var check in map[Now.DayOfWeek].Checks)
			{
				if (!check.Invoke())
				{
					map[Now.DayOfWeek].Else.ForEach(a => a?.Invoke());
					break;
				}
			}

			Updated?.Invoke(this, EventArgs.Empty);
		}

		private bool PressKeys(params PressKey[] keys)
		{
			var map = keys.ToDictionary(n => n.Key, n => n.Answer);
			Answer = string.Join("\n",
				keys.Select(n => $"Чтобы {n.Description} нажмите клавишу {n.Key}."));

			_log.AppendLine($"PressKey:\n\t{string.Join("\n\t", keys.Select(k => k.Description))}");
			if (!map.ContainsKey(Key))
			{
				Answer += "\n\nВведённая клавиша не распознана.\nПовторите попытку";
				_log.AppendLine("UnknownKey");
				return false;
			}

			Answer = map[Key];
			_log.AppendLine($"Key: {Key}");

			return string.IsNullOrEmpty(Answer);
		}
		private bool IsWorkDay()
		{
			bool res;
			if (Now.DayOfWeek == DayOfWeek.Saturday)
			{
				res = Now.Day > 7 && Now.Day <= 14;
			}
			else if (Now.DayOfWeek == DayOfWeek.Sunday)
			{
				res = Now.Day > 14 && Now.Day <= 21;
			}
			else
			{
				res = true;
			}

			_log.AppendLine($"IsWorkDay?: {res}");
			if (!res) Answer = "Перезвоните в рабочий день";
			return res;
		}
		private bool IsWorkTime(int min, int max)
		{
			var res = Now.Hour >= min &&
					  Now.Hour < max;

			_log.AppendLine($"IsWorkTime?: {res}");
			if (!res) Answer = $"Перезвоните в рабочее время с {min}.00 до {max}.00";
			return res;
		}

		private void InvateCard()
		{
			_log.AppendLine("IsNewCard");
			Answer += "\n\nХотите завести карту с кэшбеком до 20%?\nПодробности у наших менеджеров.";
		}
		private void InvateMortgage()
		{
			_log.AppendLine("InvateMortgage");
			Answer += "\n\nИпотека со ставкой от 5%?\nПодробности у наших менеджеров.";
		}
		private bool FreeOperatorsCountMore(int count)
		{
			var res = FreeOperatorsCount > count;

			_log.AppendLine($"FreeOperatorsCountMore {count}?: {res}");
			if (!res) Answer = "К сожалению, сейчас все операторы заняты.\nПерезвоните позже";
			return res;
		}
		private bool ConnectWithOperator()
		{
			Answer = "Сейчас вы будете соединины со специалистом";
			return true;
		}

		private AnswerBuilder If(Func<bool> check) => new AnswerBuilder(check);

		#region Helpers
		private class PressKey
		{
			public PressKey(int key, string description, string answer)
			{
				Key = key;
				Description = description;
				Answer = answer;
			}

			public int Key { get; }
			public string Description { get; }
			public string Answer { get; }
		}
		private class AnswerBuilder
		{
			public List<Func<bool>> Checks { get; } = new List<Func<bool>>();
			public List<Action> Else { get; } = new List<Action>();

			public AnswerBuilder(Func<bool> check)
			{
				Checks.Add(check);
			}

			public AnswerBuilder ThenIf(Func<bool> check)
			{
				Checks.Add(check);
				return this;
			}
			public AnswerBuilder Then(Func<bool> check)
			{
				Checks.Add(check);
				return this;
			}

			public AnswerBuilder IfCancel(Action action)
			{
				Else.Add(action);
				return this;
			}
		}
		#endregion
	}
}
