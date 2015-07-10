using System;

namespace DNG_V2
{
    public class RNGHelper
    {
        private Random _generator;

        public RNGHelper()
        {
            _generator = new Random(1);
        }


    }
}
