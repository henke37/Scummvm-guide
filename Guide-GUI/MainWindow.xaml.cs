using DrainLib;
using DrainLib.Engines;
using Henke37.DebugHelp;
using Scummvm.Guide.Base;
using System;
using System.Collections.Generic;
using System.IO;
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
		private Frame frame;

		internal Guide<ScummState> guide;
		internal ScummState GameState;

		internal event Action GameStateChanged;

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
					ForcePage(typeof(WaitConnect));
					return;
				} catch(ProcessNotFoundException) {
					ForcePage(typeof(WaitConnect));
					return;
				}
			}

			if(engine!=null && engine.IsActiveEngine) {
				UpdateGameState();
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

			UpdateGameState();

			SetupForGame();
		}

		private void UpdateGameState() {
			try {
				GameState = ((ScummEngineAccessor)engine).GetScummState();
				GameStateChanged?.Invoke();
			} catch(IncompleteReadException) { }
		}

		private void SetupForGame() {
			if(engine.GameId!="comi") {
				ForcePage(typeof(WaitUnsupported));
				return;
			}

			guide=Guide<ScummState>.Parse(File.OpenText("Guides\\comi.txt"));

			frame = new Frame();
			this.Content = frame;
			frame.Navigate(new QuestionList(this));
		}

		private void ForcePage(Type type) {
			if(Content != null && Content.GetType() == type) return;
			var p = (Page)type.InvokeMember("", System.Reflection.BindingFlags.CreateInstance, null, null, null, null);

			Content = p;
		}

		public void NavigateToPage(Page page) {
			frame.Navigate(page);
		}

		public void NavigateToQuestion(string id) {
			var question = guide[id];
		}

		private void NavigationWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			updateTimer.Stop();
		}
	}
}
