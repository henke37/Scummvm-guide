namespace Scummvm.Guide.Parser {
	internal abstract class BaseHintEntry<TState> : Block<TState> {

		internal override void Close(GuideParser<TState> guideParser) {
			((BaseHintContainerBlock<TState>)guideParser.CurrentBlock).hints.Add(this);
		}
	}
}