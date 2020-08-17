﻿using System.Diagnostics.CodeAnalysis;

namespace BlockbusterApp.src.Shared.Domain.Exception
{
    
    public class WarningException : Exception
    {
        public WarningException(string message) : base(message) { }
    }
}
