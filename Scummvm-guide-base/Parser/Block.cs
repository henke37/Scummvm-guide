namespace Scummvm.Guide.Parser {
	internal abstract class Block {

		internal string Id;

		internal abstract void Close(GuideParser guideParser);

		internal abstract void HandleMetaLine(string metaType, string value);
	}
}