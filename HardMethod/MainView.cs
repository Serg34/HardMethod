using System;
using System.Windows.Forms;

namespace HardMethod
{
	public interface IMainView
	{
		event EventHandler<int> DayOfWeekChange;
		event EventHandler<DateTime> TimeChange;
		event EventHandler<int> FreeOperatorsCountChange;
		event EventHandler<int> KeyInput;
		void UpdateData(IMainModel model);
		void Show();
	}

	public partial class MainView : DevExpress.XtraEditors.XtraForm, IMainView
	{
		private bool _updating;
		public MainView()
		{
			InitializeComponent();
		}

		public event EventHandler<int> DayOfWeekChange;
		public event EventHandler<DateTime> TimeChange;
		public event EventHandler<int> FreeOperatorsCountChange;
		public event EventHandler<int> KeyInput;

		public void UpdateData(IMainModel model)
		{
			try
			{
				_updating = true;
				btsDayOfWeek.SelectedIndex = model.DateTime.DayOfWeek == DayOfWeek.Sunday ? 6
					: (int)model.DateTime.DayOfWeek - 1;
				timeEdit.Time = model.DateTime;
				txtFreeOperatorsCount.Text = model.FreeOperatorsCount.ToString();
				txtKey.Text = model.Key.ToString();

				lbAnswer.Text = $"Ответ:\n{model.Answer}";
				lbLog.Text = $"Лог:\n{model.Log}";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Ошибка");
			}
			finally
			{
				_updating = false;
			}
		}

		private void BtsDayOfWeek_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_updating) return;
			DayOfWeekChange?.Invoke(this, btsDayOfWeek.SelectedIndex);
		}

		private void TimeEdit_EditValueChanged(object sender, EventArgs e)
		{
			if (_updating) return;
			TimeChange?.Invoke(this, timeEdit.Time);
		}

		private void TxtFreeOperatorsCount_EditValueChanged(object sender, EventArgs e)
		{
			if (_updating) return;
			FreeOperatorsCountChange?.Invoke(this, int.Parse(txtFreeOperatorsCount.Text));
		}

		private void TxtKey_EditValueChanged(object sender, EventArgs e)
		{
			KeyInput?.Invoke(this, int.Parse(txtKey.Text));
		}
	}
}