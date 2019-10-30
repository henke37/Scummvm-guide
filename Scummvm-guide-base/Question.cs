using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scummvm.Guide.Base {
	public class Question<TState> {
		public string Title;

		public dynamic Hints;//TODO: decide on hint structuring

		private readonly Func<TState, bool> discoveredCheck;
		private readonly Func<TState, bool> solvableCheck;
		private readonly Func<TState, bool> solvedCheck;

		public Question(string title, Func<TState, bool> discoveredCheck, Func<TState, bool> solvableCheck, Func<TState, bool> solvedCheck) {
			Title = title ?? throw new ArgumentNullException(nameof(title));
			this.discoveredCheck = discoveredCheck ?? throw new ArgumentNullException(nameof(discoveredCheck));
			this.solvableCheck = solvableCheck ?? throw new ArgumentNullException(nameof(solvableCheck));
			this.solvedCheck = solvedCheck ?? throw new ArgumentNullException(nameof(solvedCheck));
		}

		public bool IsDiscovered(TState state) => discoveredCheck(state);
		public bool IsSolvable(TState state) => solvableCheck(state);
		public bool IsSolved(TState state) => solvedCheck(state);

		public override string ToString() => Title;
	}
}
