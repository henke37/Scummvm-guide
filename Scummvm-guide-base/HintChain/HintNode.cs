using System;

namespace Scummvm.Guide.HintChain {
	public class HintNode<TState> : BaseHintChainNode<TState>, IEquatable<HintNode<TState>> {

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

		public bool Equals(HintNode<TState> other) {
			if(_text != other._text) return false;
			if(next != other.next) return false;
			return true;
		}
	}
}
