using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scummvm.Guide.HintChain {
	public class HintNode<TState> : BaseHintChainNode<TState> {

		private BaseHintChainNode<TState> next;

		public string Text;

		public override BaseHintChainNode<TState> GetNextNode(TState state) {
			return next;
		}
	}
}
