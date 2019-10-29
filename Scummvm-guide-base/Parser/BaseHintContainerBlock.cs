using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scummvm.Guide.Parser {
	abstract class BaseHintContainerBlock<TState> : Block<TState> {

		internal List<HintEntry> hints;

		protected BaseHintContainerBlock() {
			hints = new List<HintEntry>();
		}
	}
}
