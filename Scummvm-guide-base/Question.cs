using Scummvm.Guide.HintChain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scummvm.Guide.Base {
	public class Question<TState> : IEquatable<Question<TState>> {
		private string _title;

		public BaseHintChainNode<TState>? HintChain;

		private readonly Func<TState, bool> discoveredCheck;
		private readonly Func<TState, bool> solvableCheck;
		private readonly Func<TState, bool> solvedCheck;

		public string Title { get => _title; set => _title = value; }

		public Question(string title, Func<TState, bool> discoveredCheck, Func<TState, bool> solvableCheck, Func<TState, bool> solvedCheck) {
			_title = title ?? throw new ArgumentNullException(nameof(title));
			this.discoveredCheck = discoveredCheck ?? throw new ArgumentNullException(nameof(discoveredCheck));
			this.solvableCheck = solvableCheck ?? throw new ArgumentNullException(nameof(solvableCheck));
			this.solvedCheck = solvedCheck ?? throw new ArgumentNullException(nameof(solvedCheck));
		}

		public bool IsDiscovered(TState state) => discoveredCheck(state);
		public bool IsSolvable(TState state) => solvableCheck(state);
		public bool IsSolved(TState state) => solvedCheck(state);

		public override string ToString() => Title;

		public IEnumerable<HintNode<TState>> GetHintNodes(TState state) {
			var currentNode = HintChain;
			while(currentNode!=null) {
				if(currentNode is HintNode<TState> hint) {
					yield return hint;
				}
				currentNode = currentNode.GetNextNode(state);
			}
			yield break;
		}

		public bool Equals(Question<TState> other) {
			if(other is null) return false;
			return Title == other.Title;
		}
	}
}
