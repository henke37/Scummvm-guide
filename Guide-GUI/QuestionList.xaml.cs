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
using Page = System.Windows.Controls.Page;

namespace Guide_GUI {
	/// <summary>
	/// Interaction logic for QuestionList.xaml
	/// </summary>
	/// 
	public partial class QuestionList : Page {
		private readonly MainWindow Main;

		private ScummState GameState => Main.GameState;
		private IEnumerable<Question<ScummState>> Questions => Main.guide.questions;

		public QuestionList(MainWindow main) {
			InitializeComponent();

			Main = main;

			QuestionListBox.ItemsSource = GetApplicableQuestions();
		}

		private IEnumerable GetApplicableQuestions() {
			foreach(var question in Questions) {

				if(!question.IsDiscovered(GameState)) continue;
				if(question.IsSolved(GameState)) continue;

				yield return question;
			}
			yield break;
		}
	}
}
