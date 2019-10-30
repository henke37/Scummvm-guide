using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scummvm.Guide.Parser {
	internal class GuideParser<TState> {

		private int currentTabLevel;

		private Stack<Block<TState>> blockStack;

		internal Block<TState> CurrentBlock => blockStack.Peek();

		internal readonly GuideBlock<TState> guideBlock;

		internal GuideParser() {
			blockStack = new Stack<Block<TState>>();
			guideBlock = new GuideBlock<TState>();
			blockStack.Push(guideBlock);
		}

		internal dynamic Parse(TextReader r) {
			string sig = r.ReadLine();
			if(sig != "DynaGuide") throw new InvalidDataException();

			currentTabLevel = 0;

			for(; ; ) {
				var l = r.ReadLine();
				if(l == null) break;

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

			return MakeGuide();
		}

		private dynamic MakeGuide() {
			var guide = new Guide.Base.Guide<TState>();

			return guide;
		}

		private void HandleElseBlock(string l) {
			throw new NotImplementedException();
		}

		private void HandleConditionBlock(string l) {
			var b = new ConditionBlock<TState>(l);
			blockStack.Push(b);
		}

		private void HandleHintLine(string l) {
			var h = new HintEntry(l);
			((BaseHintContainerBlock<TState>)CurrentBlock).hints.Add(h);
		}

		private void HandleQuestionBlock(string l) {
			var b = new QuestionBlock<TState>(l);
			blockStack.Push(b);
		}

		private void HandleMetaLine(string l) {
			var eqPos = l.IndexOf('=');
			if(eqPos == -1) throw new InvalidDataException("Missing equals sign in metaline");

			var metaType = l.Substring(0,eqPos).TrimEnd();
			var value = l.Substring(eqPos+1).Trim();

			CurrentBlock.HandleMetaLine(metaType, value);
		}

		private void CloseCurrentBlock() {
			var b = blockStack.Pop();
			b.Close(this);
		}
	}
}
