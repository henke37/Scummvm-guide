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

		public bool IsDiscovered(TState state) => discoveredCheck(state);
		public bool IsSolvable(TState state) => solvableCheck(state);
		public bool IsSolved(TState state) => solvedCheck(state);
	}
}
