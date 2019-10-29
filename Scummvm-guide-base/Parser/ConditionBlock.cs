using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scummvm.Guide.Parser {
	internal class ConditionBlock : BaseHintContainerBlock {

		internal string Condition;

		internal ConditionBlock(string condition) {

		}

		internal override void Close(GuideParser guideParser) {
			throw new NotImplementedException();
		}

		internal override void HandleMetaLine(string metaType, string value) {
			switch(metaType) {
				case "Id":
					Id = value;
					break;
				default:
					throw new InvalidDataException("Unknown metaline!");
			}
		}
	}
}
