using System.IO;

namespace Scummvm.Guide.Parser {
	internal class QuestionBlock : BaseHintContainerBlock {
		internal string Title;
		internal string Discovered;
		internal string Solved;
		internal string Solveable;

		public QuestionBlock(string title) {
			this.Title = title;
		}

		internal override void Close(GuideParser guideParser) {
			throw new System.NotImplementedException();
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
				default:
					throw new InvalidDataException("Unknown metaline!");
			}
		}
	}
}