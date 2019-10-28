using Microsoft.CSharp;
using System;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scummvm.Guide.Base {

	public class Guide<TState> {

		public IReadOnlyList<Question<TState>> SolvedQuestions;
		public IReadOnlyList<Question<TState>> SolvableQuestions;
		public IReadOnlyList<Question<TState>> DiscoveredQuestions;

		private List<Question<TState>> questions;

		private Func<TState,bool> MakeEvaluator(string expressionStr) {
			var expression=System.Linq.Dynamic.DynamicExpression.ParseLambda<TState,bool>(expressionStr);

			//TODO:fix up the expression
			return expression.Compile();
		}
	}
}
