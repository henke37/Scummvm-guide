namespace Scummvm.Guide.Parser {
	internal class HintEntry<TState> : BaseHintEntry<TState> {
		internal readonly string Hint;

		internal HintEntry(string hint) {
			Hint = hint;
		}

		internal override void Close(GuideParser<TState> guideParser) {
			throw new System.NotImplementedException();
		}

		internal override void HandleMetaLine(string metaType, string value) {
			throw new System.NotImplementedException();
		}
	}
}