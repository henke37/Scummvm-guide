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

		public List<Question<TState>> questions;

		public readonly string GameId;

		public Guide() {
			GameId = "";
			questions = new List<Question<TState>>();

			var q = new Question<TState>(
				"Test Question",
				MakeEvaluator("true"),
				MakeEvaluator("CurrentRoom==42"),
				MakeEvaluator("false")
			);
			questions.Add(q);
		}

		private Func<TState,bool> MakeEvaluator(string expressionStr) {
			var expression=System.Linq.Dynamic.DynamicExpression.ParseLambda<TState,bool>(expressionStr);
			return expression.Compile();
		}
	}
}
