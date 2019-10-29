using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scummvm.Guide.Parser {
	internal class GuideParser {

		private int currentTabLevel;

		private Stack<Block> blockStack;

		internal Block CurrentBlock => blockStack.Peek();

		internal readonly GuideBlock guideBlock;

		internal GuideParser() {
			blockStack = new Stack<Block>();
			guideBlock = new GuideBlock();
			blockStack.Push(guideBlock);
		}

		internal void Parse(TextReader r) {
			string sig = r.ReadLine();
			if(sig != "DynaGuide") throw new InvalidDataException();

			currentTabLevel = 0;

			for(; ; ) {
				var l = r.ReadLine();

				int tabLevel = l.LastIndexOf('\t') + 1;
				int semiPos = l.IndexOf(';');
				if(semiPos>=0) {
					l = l.Substring(0, semiPos);
				}

				l = l.TrimStart('\t');
				if(l == "") continue;
				char first = l[0];

				if(currentTabLevel < tabLevel - 1) throw new InvalidDataException("Too big indentation increase!");

				for(; currentTabLevel > tabLevel; --currentTabLevel) {
					CloseCurrentBlock();
				}

				l = l.Substring(1);
				
				switch(first) {
					case '%':
						HandleMetaLine(l);
						break;
					case '?':
						HandleQuestionBlock(l);
						break;
					case '!':
						HandleHintLine(l);
						break;
					case '$':
						if(l == "else") {
							HandleElseBlock(l);
						} else {
							HandleConditionBlock(l);
						}
						break;
				}
			}
		}

		private void HandleElseBlock(string l) {
			throw new NotImplementedException();
		}

		private void HandleConditionBlock(string l) {
			var b = new ConditionBlock(l);
			blockStack.Push(b);
		}

		private void HandleHintLine(string l) {
			throw new NotImplementedException();
		}

		private void HandleQuestionBlock(string l) {
			var b = new QuestionBlock(l);
			blockStack.Push(b);
		}

		private void HandleMetaLine(string l) {
			var parts=l.Split('=');

			var metaType = parts[0].TrimEnd();
			var value = parts[1].Trim();

			CurrentBlock.HandleMetaLine(metaType, value);
		}

		private void CloseCurrentBlock() {
			var b = blockStack.Pop();
			b.Close(this);
		}

		internal dynamic InstantiateType(string typeName, params object[] vs) {
			var t = Type.GetType(typeName);
			t = t.MakeGenericType(guideBlock.StateType);


			throw new NotImplementedException();
		}
	}
}
