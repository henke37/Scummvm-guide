using Scummvm.Guide.HintChain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scummvm.Guide.Parser {
	abstract class BaseHintContainerBlock<TState> : BaseHintEntry<TState> {

		internal List<BaseHintEntry<TState>> hints;

		protected BaseHintContainerBlock() {
			hints = new List<BaseHintEntry<TState>>();
		}

		internal override BaseHintChainNode<TState> MakeHintChain(GuideParser<TState> guideParser) {
			if(hints.Count == 0) return null;
			BaseHintChainNode<TState> root = hints[0].MakeHintChain(guideParser);
			BaseHintChainNode<TState> currentNode = root;
			for(int i=1;i<hints.Count;++i) {
				var hint = hints[i];
				var nextNode = hint.MakeHintChain(guideParser);
				currentNode.SetNextNode(nextNode);
				currentNode = nextNode;
			}

			return root;
		}
	}
}
