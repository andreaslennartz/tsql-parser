﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSQL.Tokens
{
	public class TSQLCharacter : TSQLToken
	{
		public TSQLCharacter(
			int beginPostion,
			string text) :
			base(
				beginPostion,
				text)
		{
			Character = TSQLCharacters.Parse(text);
		}

		public override TSQLTokenType Type
		{
			get
			{
				return TSQLTokenType.Character;
			}
		}

		public TSQLCharacters Character
		{
			get;
			private set;
		}
	}
}
