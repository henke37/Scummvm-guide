using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scummvm.Guide.Parser {
	internal class GuideBlock<TState> : Block<TState> {
		private string GameId;

		internal List<QuestionBlock<TState>> questions;

		public GuideBlock() {
			questions = new List<QuestionBlock<TState>>();
		}

		internal override void Close(GuideParser<TState> guideParser) {
			throw new NotImplementedException();
		}

		internal override void HandleMetaLine(string metaType, string value) {
			switch(metaType) {
				case "GameId":
					GameId = value;
					break;
				case "Id":
					Id = value;
					break;
				default:
					throw new InvalidDataException("Unknown metaline!");
			}
		}
	}
}
