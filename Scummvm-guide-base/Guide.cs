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

		public Guide(string gameId) {
			GameId = gameId;
			questions = new List<Question<TState>>();
		}

		public static Guide<TState> Parse(Stream s,Encoding enc,bool closeAfterRead=true) {
			using(var r=new StreamReader(s, enc, false, 0, closeAfterRead)) {
				return Parse(r);
			}
		}

		public static Guide<TState> Parse(TextReader r) {
			var p = new GuideParser<TState>();
			return p.Parse(r);
		}
	}
}
