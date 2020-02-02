using DrainLib.Engines;
using Scummvm.Guide.Base;
using System;
using System.Collections;
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
using Henke37.Collections.Filtered;
using Page = System.Windows.Controls.Page;

namespace Guide_GUI {
	/// <summary>
	/// Interaction logic for QuestionList.xaml
	/// </summary>
	/// 
	public partial class QuestionList : Page {
		private readonly MainWindow Main;

		private ScummState GameState => Main.GameState;
		private List<Question<ScummState>> Questions => Main.guide.questions;

		private FilterCollection<Question<ScummState>, ScummState> filterCollection;

		public QuestionList(MainWindow main) {
			InitializeComponent();

			Main = main;
			Main.GameStateChanged += Main_GameStateChanged;

			QuestionListBox.ItemsSource = filterCollection = new FilterCollection<Question<ScummState>, ScummState>(
				Questions,
				Filter,
				null
			);
		}

		private void Main_GameStateChanged() {
			filterCollection.FilterArg = Main.GameState;
		}

		private static bool Filter(Question<ScummState> question,ScummState state) {
			if(state == null) return false;

			if(!question.IsDiscovered(state)) return false;
			if(question.IsSolved(state)) return false;

			return true;
		}

		private void SwitchToQuestion(Question<ScummState> question) {
			var hintList = new QuestionDetailsPage(question);
			Main.NavigateToPage(hintList);
		}

		private void Question_Click(object sender, RoutedEventArgs e) {
			var button=(Button)sender;
			var question = (Question<ScummState>)button.DataContext;
			SwitchToQuestion(question);
		}
	}
}
