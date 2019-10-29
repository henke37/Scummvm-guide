using Microsoft.CSharp;
using System;
using System.Linq.Expressions;
using System.Linq.Dynamic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Scummvm.Guide.Parser;

namespace Scummvm.Guide.Base {

	public class Guide<TState> {

		public List<Question<TState>> questions;

		public string GameId;

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

		public static dynamic Parse(Stream s,Encoding enc,bool closeAfterRead=true) {
			using(var r=new StreamReader(s, enc, false, 0, closeAfterRead)) {
				return Parse(r);
			}
		}

		public static dynamic Parse(TextReader r) {
			var p = new GuideParser<TState>();
			return p.Parse(r);
		}

		private Func<TState,bool> MakeEvaluator(string expressionStr) {
			var expression=System.Linq.Dynamic.DynamicExpression.ParseLambda<TState,bool>(expressionStr);
			return expression.Compile();
		}
	}
}
