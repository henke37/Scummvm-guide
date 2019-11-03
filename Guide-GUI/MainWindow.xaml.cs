using DrainLib;
using DrainLib.Engines;
using Henke37.DebugHelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Page = System.Windows.Controls.Page;

namespace Guide_GUI {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {

		private ScummVMConnector connector;

		private BaseEngineAccessor engine;
		private DispatcherTimer updateTimer;

		public MainWindow() {
			InitializeComponent();

			connector = new ScummVMConnector();

			UpdateState();

			updateTimer = new DispatcherTimer();
			updateTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
			updateTimer.Tick += UpdateTimer_Tick;
			updateTimer.Start();
		}

		private void UpdateTimer_Tick(object sender, EventArgs e) {
			UpdateState();
		}

		private void UpdateState() {
			if(!connector.Connected) {
				try {
					connector.Connect();
				} catch(IncompleteReadException) {
				} catch(ProcessNotFoundException) {
					ForcePage(typeof(WaitConnect));
					return;
				}
			}

			if(engine!=null && engine.IsActiveEngine) {
				return;
			}
			try { 
				engine = connector.GetEngine();
			} catch(IncompleteReadException) {
			}

			if(engine==null) {
				ForcePage(typeof(WaitSelectGame));
				return;
			}

			SetupForGame();
		}

		private void SetupForGame() {
			if(engine.GameId!="comi") {
				ForcePage(typeof(WaitUnsupported));
				return;
			}
		}

		private void ForcePage(Type type) {
			if(Content != null && Content.GetType() == type) return;
			var p = (Page)type.InvokeMember("", System.Reflection.BindingFlags.CreateInstance, null, null, null, null);

			Content = p;
		}

		private void NavigationWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			updateTimer.Stop();
		}
	}
}
