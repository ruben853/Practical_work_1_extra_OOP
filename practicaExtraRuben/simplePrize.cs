using System;

namespace practicaExtra
{
    public class simplePrize : Prize
    {
        private string advice;

        public simplePrize(string name, int symbol1, int symbol2, int symbol3, string advice) : base(name, symbol1, symbol2, symbol3)
        {
            this.advice = advice;
        }

        public override bool winningComb(int symbol1, int symbol2, int symbol3)
        {
            return this.symbol1 == symbol1 && this.symbol2 == symbol2 && this.symbol3 == symbol3;
        }

        public override string GetAdvice()
        {
            return advice;
        }
    }
}
