﻿using System;

namespace Tracer.Print
{
    public class ConsolePrinter : IPrinter
    {
        public void PrintResult(string data)
        {
            Console.WriteLine(data);
        }
    }
}