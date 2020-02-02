using System;

namespace Scummvm.Guide.HintChain {
	public abstract class BaseHintChainNode<TState> {

		private string? _id;

		protected BaseHintChainNode(string? id) {
			_id = id;
		}

		public string? Id { get => _id; set => _id = value; }

		public abstract BaseHintChainNode<TState>? GetNextNode(TState state);
		internal abstract void SetNextNode(BaseHintChainNode<TState>? nextNode);
	}
}
