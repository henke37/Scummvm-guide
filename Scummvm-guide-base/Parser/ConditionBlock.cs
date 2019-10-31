using Scummvm.Guide.HintChain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scummvm.Guide.Parser {
	internal class ConditionBlock<TState> : BaseHintContainerBlock<TState> {

		internal readonly string Condition;

		internal ConditionBlock(string condition) {
			Condition = condition;
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

		internal override BaseHintChainNode<TState> MakeHintChain(GuideParser<TState> guideParser) {
			return new ConditionNode<TState>(
				guideParser.MakeEvaluator(Condition),
				base.MakeHintChain(guideParser),
				Id
			);
		}
	}
}
