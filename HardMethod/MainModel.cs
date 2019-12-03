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
		DateTime DateTime { get; }
		int FreeOperatorsCount { get; set; }
		int Key { get; set; }

		event EventHandler Updated;
		void ChangeDayOfWeek(int i);
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
		private DateTime _dateTime;
		private readonly StringBuilder _log = new StringBuilder();
		#endregion

		public MainModel()
		{
			_key = -1;
			_dateTime = DateTime.Now.AddDays(_random.Next(30)).AddHours(_random.Next(24));
			_freeOperatorsCount = _random.Next(100);
			_balance = (decimal)_random.Next(9999) / 10;
		}

		#region Properties
		public string Answer { get; private set; }
		public string Log => _log.ToString();

		public DateTime DateTime
		{
			get => _dateTime;
			private set
			{
				_dateTime = value;
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
		public void ChangeDayOfWeek(int i)
		{
			var nowDayOfWeek = (int)DateTime.DayOfWeek;
			DateTime = DateTime.AddDays(i + 1 - nowDayOfWeek);
		}
		public void ChangeTime(DateTime time)
		{
			DateTime = new DateTime(
				DateTime.Year,
				DateTime.Month,
				DateTime.Day).AddHours(time.Hour).AddMinutes(time.Minute);
		}
		public void Update()
		{
			var dialogs = new Dictionary<DayOfWeek, DialogBuilder>
			{
				[DayOfWeek.Monday] =
					If(() => DialogByKeys(
						new DialogKey(1, "заблокировать карту", "Карта заблокирована"),
						new DialogKey(2, "узнать баланс", $"Ваш баланс: {_balance:N}руб."),
						new DialogKey(3, "узнать новости", "Текст новостей..."),
						new DialogKey(0, "соединить со оператором", null)))
					.ThenIf(() => IsWorkTime(8, 20))
					.ThenIf(() => FreeOperatorsCountMore(15))
					.Then(ConnectWithOperator)
					.IfReject(InviteCard),

				[DayOfWeek.Tuesday] =
					If(() => DialogByKeys(
						new DialogKey(1, "заблокировать карту", "Карта заблокирована"),
						new DialogKey(2, "узнать баланс", $"Ваш баланс: {_balance:N}руб."),
						new DialogKey(3, "оформить кредит", "Кредит оформлен"),
						new DialogKey(4, "оформить вклад", "Вклад оформлен"),
						new DialogKey(0, "соединить со оператором", null)))
					.ThenIf(() => IsWorkTime(8, 20))
					.ThenIf(() => FreeOperatorsCountMore(25))
					.Then(ConnectWithOperator)
					.IfReject(InviteCard)
					.IfReject(InviteMortgage),

				[DayOfWeek.Wednesday] =
					If(() => DialogByKeys(
						new DialogKey(1, "заблокировать карту", "Карта заблокирована"),
						new DialogKey(2, "узнать баланс", $"Ваш баланс: {_balance:N}руб."),
						new DialogKey(3, "узнать новости", "Текст новостей..."),
						new DialogKey(4, "оформить вклад", "Вклад оформлен"),
						new DialogKey(0, "соединить со оператором", null)))
					.ThenIf(() => IsWorkTime(8, 20))
					.ThenIf(() => FreeOperatorsCountMore(50))
					.Then(ConnectWithOperator)
					.IfReject(InviteCard)
					.IfReject(InviteMortgage),

				[DayOfWeek.Thursday] =
					If(() => DialogByKeys(
						new DialogKey(1, "заблокировать карту", "Карта заблокирована"),
						new DialogKey(2, "узнать баланс", $"Ваш баланс: {_balance:N}руб."),
						new DialogKey(3, "узнать новости", "Текст новостей..."),
						new DialogKey(4, "оформить кредит", "Кредит оформлен"),
						new DialogKey(5, "оформить вклад", "Вклад оформлен"),
						new DialogKey(0, "соединить со оператором", null)))
					.ThenIf(() => IsWorkTime(8, 20))
					.ThenIf(() => FreeOperatorsCountMore(50))
					.Then(ConnectWithOperator)
					.IfReject(InviteCard)
					.IfReject(InviteMortgage),

				[DayOfWeek.Friday] =
					If(() => DialogByKeys(
						new DialogKey(1, "заблокировать карту", "Карта заблокирована"),
						new DialogKey(2, "узнать баланс", $"Ваш баланс: {_balance:N}руб."),
						new DialogKey(0, "соединить со оператором", null)))
					.ThenIf(() => IsWorkTime(8, 22))
					.ThenIf(() => FreeOperatorsCountMore(75))
					.Then(ConnectWithOperator)
					.IfReject(InviteCard),

				[DayOfWeek.Saturday] =
					If(() => DialogByKeys(
						new DialogKey(1, "заблокировать карту", "Карта заблокирована"),
						new DialogKey(2, "узнать баланс", $"Ваш баланс: {_balance:N}руб."),
						new DialogKey(3, "оформить кредит", "Кредит оформлен"),
						new DialogKey(4, "оформить вклад", "Вклад оформлен"),
						new DialogKey(0, "соединить со оператором", null)))
					.ThenIf(IsWorkDay)
					.ThenIf(() => IsWorkTime(8, 15))
					.ThenIf(() => FreeOperatorsCountMore(20))
					.Then(ConnectWithOperator)
					.IfReject(InviteCard),

				[DayOfWeek.Sunday] =
					If(() => DialogByKeys(
						new DialogKey(1, "заблокировать карту", "Карта заблокирована"),
						new DialogKey(2, "узнать баланс", $"Ваш баланс: {_balance:N}руб."),
						new DialogKey(3, "узнать новости", "Текст новостей..."),
						new DialogKey(0, "соединить со оператором", null)))
					.ThenIf(IsWorkDay)
					.ThenIf(() => IsWorkTime(8, 14))
					.ThenIf(() => FreeOperatorsCountMore(20))
					.Then(ConnectWithOperator),
			};

			_log.Clear();

			foreach (var dialog in dialogs[DateTime.DayOfWeek].Dialogs)
			{
				var isReject = !dialog.Invoke();
				if (isReject) // произошёл отказ (нерабочий день и т.п.)
				{
					dialogs[DateTime.DayOfWeek].AnswersWhenReject.ForEach(a => a?.Invoke());
					break;
				}
			}

			Updated?.Invoke(this, EventArgs.Empty);
		}

		/// <summary>
		/// Строит диалог в зависимости от введённой клавиши
		/// </summary>
		/// <param name="keys">Доступные клавиши</param>
		/// <returns></returns>
		private bool DialogByKeys(params DialogKey[] keys)
		{
			var map = keys.ToDictionary(n => n.Key, n => n.Answer);
			Answer = string.Join("\n",
				keys.Select(n => $"Чтобы {n.Description} нажмите клавишу {n.Key}."));

			_log.AppendLine($"PressKey:\n\t" +
				$"{string.Join("\n\t", keys.Select(k => $"{k.Key}: {k.Description}"))}");

			if (!map.ContainsKey(Key)) //если клавиши нет в списке доступных
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
			if (DateTime.DayOfWeek == DayOfWeek.Saturday) //Вторая суббота месяца рабочая, остальные нет
			{
				res = DateTime.Day > 7 && DateTime.Day <= 14;
			}
			else if (DateTime.DayOfWeek == DayOfWeek.Sunday) //Третье воскресение месяца рабочее, остальные нет
			{
				res = DateTime.Day > 14 && DateTime.Day <= 21;
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
			var res = DateTime.Hour >= min &&
					  DateTime.Hour < max;

			_log.AppendLine($"IsWorkTime?: {res}");
			if (!res) Answer = $"Перезвоните в рабочее время с {min}.00 до {max}.00";
			return res;
		}
		private bool FreeOperatorsCountMore(int count)
		{
			var res = FreeOperatorsCount > count;

			_log.AppendLine($"FreeOperatorsCountMore {count}?: {res}");
			if (!res) Answer = "К сожалению, сейчас все операторы заняты.\nПерезвоните позже";
			return res;
		}
		private void ConnectWithOperator()
		{
			Answer = "Сейчас вы будете соединины со специалистом";
		}
		private void InviteCard()
		{
			_log.AppendLine("InviteCard");
			Answer += "\n\nХотите завести карту с кэшбеком до 20%?\nПодробности на нашем сайте www.bank.ru.";
		}
		private void InviteMortgage()
		{
			_log.AppendLine("InviteMortgage");
			Answer += "\n\nИпотека со ставкой от 5%?\nПодробности на нашем сайте www.bank.ru.";
		}

		/// <summary>
		/// Начинает диалог
		/// </summary>
		private DialogBuilder If(Func<bool> dialog) => new DialogBuilder(dialog);

		#region Helpers
		/// <summary>
		/// Обработчик нажатия клавиши на телефоне
		/// </summary>
		private class DialogKey
		{
			/// <summary>
			/// Обработчик нажатия клавиши на телефоне
			/// </summary>
			/// <param name="key">Цифра на клавише</param>
			/// <param name="description">Описание, выводимое до нажатия клавиши</param>
			/// <param name="answer">Результат в виде текста выводимого после нажатия клавиши</param>
			public DialogKey(int key, string description, string answer)
			{
				Key = key;
				Description = description;
				Answer = answer;
			}
			/// <summary>
			/// Цифра на клавише
			/// </summary>
			public int Key { get; }
			/// <summary>
			/// Описание, выводимое до нажатия клавиши
			/// </summary>
			public string Description { get; }
			/// <summary>
			/// Результат в виде текста выводимого после нажатия клавиши
			/// </summary>
			public string Answer { get; }
		}

		/// <summary>
		/// Беглый строитель диалога
		/// (Fluent Builder Pattern https://metanit.com/sharp/patterns/6.1.php)
		/// </summary>
		private class DialogBuilder
		{
			/// <summary>
			/// Цепочка диалога бота
			/// </summary>
			public List<Func<bool>> Dialogs { get; } = new List<Func<bool>>();

			/// <summary>
			/// Ответы бота в случае отказа (нерабочий день и т.п.)
			/// </summary>
			public List<Action> AnswersWhenReject { get; } = new List<Action>();

			/// <summary>
			/// Беглый строитель диалога
			/// </summary>
			public DialogBuilder(Func<bool> dialog)
			{
				Dialogs.Add(dialog);
			}
			/// <summary>
			/// Продолжает диалог с вопросом или проверяет условие
			/// </summary>
			public DialogBuilder ThenIf(Func<bool> dialog)
			{
				Dialogs.Add(dialog);
				return this;
			}
			/// <summary>
			/// Продолжает диалог без вопроса
			/// </summary>
			public DialogBuilder Then(Action dialog)
			{
				Dialogs.Add(() =>
				{
					dialog?.Invoke();
					return true;
				});
				return this;
			}

			/// <summary>
			/// Продолжает диалог если произошёл отказ (нерабочий день и т.п.)
			/// </summary>
			public DialogBuilder IfReject(Action action)
			{
				AnswersWhenReject.Add(action);
				return this;
			}
		}
		#endregion
	}
}
