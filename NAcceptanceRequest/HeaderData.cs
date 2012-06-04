using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NAcceptanceRequest
{
    public class HeaderData
    {
        public HeaderData(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; private set; }
        public string Value { get; private set; }
    }
}
