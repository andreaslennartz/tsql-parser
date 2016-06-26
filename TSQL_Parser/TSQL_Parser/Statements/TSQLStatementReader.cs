﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TSQL.Statements.Builders;
using TSQL.Tokens;

namespace TSQL.Statements
{
	public partial class TSQLStatementReader
	{
		private TSQLTokenizer _tokenizer = null;
		private bool _hasMore = true;
		private TSQLStatement _current = null;

		public TSQLStatementReader(TSQLTokenizer tokenizer)
		{
			_tokenizer = tokenizer;
		}

		public bool Read()
		{
			CheckDisposed();

			if (_hasMore)
			{
				while (
					_tokenizer.Read() &&
					(
						_tokenizer.Current.Type == TSQLTokenType.SingleLineComment ||
						_tokenizer.Current.Type == TSQLTokenType.MultilineComment ||
						_tokenizer.Current.Type == TSQLTokenType.Whitespace
					))

				{

				}

				if (_tokenizer.Current == null)
				{
					_hasMore = false;

					return _hasMore;
				}

				if (_tokenizer.Current.Type != TSQLTokenType.Keyword)
				{
					// don't know what I want to do here yet

					_hasMore = false;

					return _hasMore;
				}

				TSQLKeywords keyword = (_tokenizer.Current as TSQLKeyword).Keyword;
				_tokenizer.Putback();

				_current = new TSQLStatementBuilderFactory().Create(keyword).Build(_tokenizer);
			}

			return _hasMore;
		}

		public TSQLStatement Current
		{
			get
			{
				CheckDisposed();

				return _current;
			}
		}

		public TSQLStatement Next()
		{
			if (Read())
			{
				return Current;
			}
			else
			{
				return null;
			}
		}
	}
}
