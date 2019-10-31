using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scummvm.Guide.HintChain {
	public class ConditionNode<TState> : BaseHintChainNode<TState> {

		internal BaseHintChainNode<TState> trueNext;
		internal BaseHintChainNode<TState> falseNext;

		internal Func<TState, bool> condition;

		public override BaseHintChainNode<TState> GetNextNode(TState state) {
			if(condition(state)) {
				return trueNext;
			} else {
				return falseNext;
			}
		}
	}
}
