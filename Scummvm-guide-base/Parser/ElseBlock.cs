using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scummvm.Guide.Parser {
	internal class ElseBlock<TState> : BaseHintContainerBlock<TState> {
		internal readonly ConditionBlock<TState> ConditionBlock;

		internal ElseBlock(ConditionBlock<TState> conditionBlock) {
			this.ConditionBlock = conditionBlock;
		}

		internal override void Close(GuideParser<TState> guideParser) {
			throw new NotImplementedException();
		}

		internal override void HandleMetaLine(string metaType, string value) {
			throw new NotImplementedException();
		}
	}
}
