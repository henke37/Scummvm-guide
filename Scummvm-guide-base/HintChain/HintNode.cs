using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scummvm.Guide.HintChain {
	public class HintNode<TState> : BaseHintChainNode<TState> {

		private BaseHintChainNode<TState> next;

		public string Text;

		public HintNode(string hint, string id=null) : base(id) {
			Text = hint;
		}

		public override BaseHintChainNode<TState> GetNextNode(TState state) {
			return next;
		}

		internal override void SetNextNode(BaseHintChainNode<TState> nextNode) => next = nextNode;

		public override string ToString() => Text;
	}
}
