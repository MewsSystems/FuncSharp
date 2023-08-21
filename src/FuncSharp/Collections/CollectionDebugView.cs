﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FuncSharp;

/// <summary>
/// Copied from http://www.codeproject.com/Articles/28405/Make-the-debugger-show-the-contents-of-your-custom
/// </summary>
/// <typeparam name="T"></typeparam>
internal class CollectionDebugView<T>
{
    private readonly IEnumerable<T> collection;

    public CollectionDebugView(IEnumerable<T> collection)
    {
        this.collection = collection ?? throw new ArgumentNullException("collection");
    }

    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    public T[] Items => collection.ToArray();
}