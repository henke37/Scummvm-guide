using System;

namespace Scummvm.Guide.HintChain {
	public class ConditionNode<TState> : BaseHintChainNode<TState> {

		internal BaseHintChainNode<TState>? TrueNext;
		internal BaseHintChainNode<TState>? FalseNext;

		internal Func<TState, bool> Condition;

		public ConditionNode(Func<TState, bool> condition, BaseHintChainNode<TState>? baseHintChainNode, string? id=null) : base(id) {
			Condition = condition;
			TrueNext = baseHintChainNode;
		}

		public override BaseHintChainNode<TState>? GetNextNode(TState state) {
			if(Condition(state)) {
				return TrueNext;
			} else {
				return FalseNext;
			}
		}

		internal override void SetNextNode(BaseHintChainNode<TState>? nextNode) => FalseNext = nextNode;
	}
}
