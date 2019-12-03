namespace HardMethod
{
	public class MainPresenter
	{
		private readonly IMainModel _model;
		private readonly IMainView _view;

		public MainPresenter(IMainModel model, IMainView view)
		{
			_model = model;
			_view = view;

			_view.DayOfWeekChange += (sender, i) => _model.ChangeDayOfWeek(i);
			_view.TimeChange += (sender, time) => _model.ChangeTime(time);
			_view.FreeOperatorsCountChange += (sender, count) => _model.FreeOperatorsCount = count;
			_view.KeyInput += (sender, key) => _model.Key = key;

			_model.Updated += (sender, args) => _view.UpdateData(_model);
			_model.Update();

			_view.Show();
		}
	}
}
