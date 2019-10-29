﻿using System.IO;

namespace Scummvm.Guide.Parser {
	internal class QuestionBlock : BaseHintContainerBlock {
		internal string Title;
		internal string Discovered;
		internal string Solved;
		internal string Solveable;
		internal int Priority;

		public QuestionBlock(string title) {
			this.Title = title;
		}

		internal override void Close(GuideParser guideParser) {
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
	}
}