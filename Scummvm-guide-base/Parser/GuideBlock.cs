using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scummvm.Guide.Parser {
	internal class GuideBlock : Block {
		internal Type StateType;
		private string GameId;

		internal override void Close(GuideParser guideParser) {
			throw new NotImplementedException();
		}

		internal override void HandleMetaLine(string metaType, string value) {
			switch(metaType) {
				case "StateClass":
					StateType = Type.GetType(value);
					break;
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
