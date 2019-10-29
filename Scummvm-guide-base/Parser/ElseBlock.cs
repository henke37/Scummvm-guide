using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scummvm.Guide.Parser {
	internal class ElseBlock : BaseHintContainerBlock {
		internal readonly ConditionBlock ConditionBlock;

		internal ElseBlock(ConditionBlock conditionBlock) {
			this.ConditionBlock = conditionBlock;
		}

		internal override void Close(GuideParser guideParser) {
			throw new NotImplementedException();
		}

		internal override void HandleMetaLine(string metaType, string value) {
			throw new NotImplementedException();
		}
	}
}
