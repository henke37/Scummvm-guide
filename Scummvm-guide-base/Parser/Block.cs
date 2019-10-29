namespace Scummvm.Guide.Parser {
	internal abstract class Block<TState> {

		internal string Id;

		internal abstract void Close(GuideParser<TState> guideParser);

		internal abstract void HandleMetaLine(string metaType, string value);
	}
}