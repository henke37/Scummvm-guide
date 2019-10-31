using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scummvm.Guide.HintChain {
	public abstract class BaseHintChainNode<TState> {

		public string Id;

		protected BaseHintChainNode(string id) {
			Id = id;
		}

		public abstract BaseHintChainNode<TState> GetNextNode(TState state);
		internal abstract void SetNextNode(BaseHintChainNode<TState> nextNode);
	}
}
