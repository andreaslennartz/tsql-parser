﻿using System;

namespace TSQL.Tokens
{
	public class TSQLNumericLiteral : TSQLLiteral
	{
		internal TSQLNumericLiteral(
			int beginPosition,
			string text) :
			base(
				beginPosition,
				text)
		{
			// TODO: add numeric public property with value
		}

#pragma warning disable 1591

		public override TSQLTokenType Type
		{
			get
			{
				return TSQLTokenType.NumericLiteral;
			}
		}

#pragma warning restore 1591
	}
}
