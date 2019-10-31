using Scummvm.Guide.Base;
using System;
using System.IO;

namespace Scummvm.Guide.Parser {
	internal class QuestionBlock<TState> : BaseHintContainerBlock<TState> {
		internal string Title;
		internal string Discovered;
		internal string Solved;
		internal string Solveable;
		internal int Priority;

		public QuestionBlock(string title) {
			this.Title = title;
		}

		internal override void Close(GuideParser<TState> guideParser) {
			guideParser.guideBlock.questions.Add(this);
		}

		internal override void HandleMetaLine(string metaType, string value) {
			switch(metaType) {
				case "Id":
					Id = value;
					break;
				case "Discovered":
					Discovered = value;
					break;
				case "Solved":
					Solved = value;
					break;
				case "Solveable":
					Solveable = value;
					break;
				case "Priority":
					Priority = int.Parse(value);
					break;
				default:
					throw new InvalidDataException("Unknown metaline!");
			}
		}

		internal Question<TState> MakeQuestion(GuideParser<TState> guideParser) {
			var q= new Question<TState>(
				Title,
				guideParser.MakeEvaluator(Discovered),
				guideParser.MakeEvaluator(Solveable),
				guideParser.MakeEvaluator(Solved)
			);

			q.HintChain = MakeHintChain(guideParser);

			return q;
		}


		public override string ToString() => Title;
	}
}