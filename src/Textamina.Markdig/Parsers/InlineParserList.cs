﻿// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using System.Collections.Generic;

namespace Textamina.Markdig.Parsers
{
    /// <summary>
    /// A list of <see cref="InlineParser"/>.
    /// </summary>
    /// <seealso cref="Textamina.Markdig.Parsers.ParserList{Textamina.Markdig.Parsers.InlineParser, Textamina.Markdig.Parsers.InlineParserState}" />
    public class InlineParserList : ParserList<InlineParser, InlineProcessor>
    {
        /// <summary>
        /// Gets the registered delimiter processors.
        /// </summary>
        public IDelimiterProcessor[] DelimiterProcessors { get; private set; }

        public override void Initialize(InlineProcessor initState)
        {
            // Prepare the list of delimiter processors
            var delimiterProcessors = new List<IDelimiterProcessor>();
            foreach (var parser in this)
            {
                var delimProcessor = parser as IDelimiterProcessor;
                if (delimProcessor != null)
                {
                    delimiterProcessors.Add(delimProcessor);
                }
            }
            DelimiterProcessors = delimiterProcessors.ToArray();

            base.Initialize(initState);
        }
    }
}