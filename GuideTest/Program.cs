using Scummvm.Guide.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scummvm.Guide;
using DrainLib.Engines;
using System.IO;

namespace GuideTest {
	class Program {
		static void Main(string[] args) {
			using(var r = File.OpenText(args[0])) {
				var g = Guide<ScummState>.Parse(r);
			}
		}
	}
}
