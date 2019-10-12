using System;
using System.Windows.Forms;

namespace HardMethod
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			var model = new MainModel();
			var view = new MainView();
			var presenter = new MainPresenter(model,view);

			Application.Run(view);
		}
	}
}
