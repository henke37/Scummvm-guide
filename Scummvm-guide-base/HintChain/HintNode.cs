using System;

namespace Scummvm.Guide.HintChain {
	public class HintNode<TState> : BaseHintChainNode<TState> {

		private BaseHintChainNode<TState>? next;

		private string _text;

		public string Text { get => _text; set => _text = value; }

		public HintNode(string hint, string? id=null) : base(id) {
			_text = hint;
		}

		public override BaseHintChainNode<TState>? GetNextNode(TState state) {
			return next;
		}

		internal override void SetNextNode(BaseHintChainNode<TState>? nextNode) => next = nextNode;

		public override string ToString() => Text;
	}
}
