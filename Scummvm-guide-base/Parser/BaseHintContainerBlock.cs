using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scummvm.Guide.Parser {
	abstract class BaseHintContainerBlock<TState> : BaseHintEntry<TState> {

		internal List<BaseHintEntry<TState>> hints;

		protected BaseHintContainerBlock() {
			hints = new List<BaseHintEntry<TState>>();
		}
	}
}
