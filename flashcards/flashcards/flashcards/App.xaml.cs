using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace flashcards
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private Service ServiceCards { get; set; }

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			this.ServiceCards = new Service(new Repo());
		}
	}
}
