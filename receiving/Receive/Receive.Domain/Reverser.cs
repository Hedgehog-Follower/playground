﻿using System.Collections.Generic;
using System.Linq;

namespace Receive.Domain
{
    public class Reverser : IReverser
    {
        public IEnumerable<string> Reverse(IEnumerable<string> phrases)
        {
            return phrases.Reverse();
        }
    }

    public interface IReverser
    {
        IEnumerable<string> Reverse(IEnumerable<string> phrases);
    }
}
