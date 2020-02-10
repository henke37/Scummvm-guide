using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using DrainLib.Engines;
using Henke37.Collections.Filtered;
using Scummvm.Guide.Base;
using Scummvm.Guide.HintChain;

namespace Guide_GUI {
	/// <summary>
	/// Interaction logic for HintList.xaml
	/// </summary>
	public partial class QuestionDetailsPage : System.Windows.Controls.Page {
		private readonly Question<ScummState> question;
		private readonly MainWindow main;
		private DiffingCollection<HintNode<ScummState>> hintDiffer;

		public QuestionDetailsPage(Question<ScummState> question, MainWindow main) {
			InitializeComponent();
			this.question = question;
			this.main = main;
			this.Title = question.Title;

			hintDiffer = new DiffingCollection<HintNode<ScummState>>(new List<HintNode<ScummState>>());
			hintList.ItemsSource = hintDiffer;
		}

		private void UpdateHintsList(ScummState state) {
			hintDiffer.RealCollection = question.GetHintNodes(state).ToList();
		}

		private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e) {
			main.GameStateChanged += GameStateChanged;
		}

		private void GameStateChanged() {
			UpdateHintsList(main.GameState);
		}

		private void Page_Unloaded(object sender, System.Windows.RoutedEventArgs e) {
			main.GameStateChanged -= GameStateChanged;
		}
	}
}
