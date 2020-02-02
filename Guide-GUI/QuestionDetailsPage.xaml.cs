using System;
using System.Windows.Controls;
using DrainLib.Engines;
using Scummvm.Guide.Base;

namespace Guide_GUI {
	/// <summary>
	/// Interaction logic for HintList.xaml
	/// </summary>
	public partial class QuestionDetailsPage : System.Windows.Controls.Page {
		private readonly Question<ScummState> question;

		public QuestionDetailsPage(Question<DrainLib.Engines.ScummState> question) {
			InitializeComponent();
			this.question = question;
		}
	}
}
