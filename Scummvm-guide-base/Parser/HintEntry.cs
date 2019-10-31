using System.IO;
using Scummvm.Guide.HintChain;

namespace Scummvm.Guide.Parser {
	internal class HintEntry<TState> : BaseHintEntry<TState> {
		internal readonly string Hint;

		internal HintEntry(string hint) {
			Hint = hint;
		}

		internal override void HandleMetaLine(string metaType, string value) {
			switch(metaType) {
				case "Id":
					Id = value;
					break;
				default:
					throw new InvalidDataException("Unknown metaline!");
			}
		}

		internal override BaseHintChainNode<TState> MakeHintChain(GuideParser<TState> guideParser) {
			var h = new HintNode<TState>(Hint,Id);
			return h;
		}
	}
}