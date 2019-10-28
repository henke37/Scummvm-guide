using Scummvm.Guide.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scummvm.Guide;
using DrainLib.Engines;

namespace GuideTest {
	class Program {
		static void Main(string[] args) {
			var g= new Guide<ScummState>();
			var q= g.questions[0];
			var s = new ScummState();
			q.IsDiscovered(s);
		}
	}
}
