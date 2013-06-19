﻿using System.Collections.Generic;

namespace NumberConverter.Models.Printers
{
    public class SingleDigitPrinter : IPrintNumbers
    {
        private IDictionary<int, string> numberToTextMap = new Dictionary<int, string>
                                                               {
                                                                   {1, "one"},
                                                                   {2, "two"},
                                                                   {3, "three"},
                                                                   {4, "four"},
                                                                   {5, "five"},
                                                                   {6, "six"},
                                                                   {7, "seven"},
                                                                   {8, "eight"},
                                                                   {9, "nine"},
                                                               };
        public string Print(Number value)
        {
            return this.numberToTextMap[value.UnderlyingValue];
        }
    }
}