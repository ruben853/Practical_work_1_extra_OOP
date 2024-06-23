using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicaExtra
{
    public class randomPrize : Prize
    {
        private string advice1;
        private string advice2;
        private double prob;

        public randomPrize(string name, int symbol1, int symbol2, int symbol3, string Advice1, string Advice2) : base(name, symbol1, symbol2, symbol3)
        {
            this.advice1 = Advice1;
            this.advice2 = Advice2;
        }
        public override bool winningComb(int symbol1, int symbol2, int symbol3)
        {
            return this.symbol1 == symbol1 && this.symbol2 == symbol2 && this.symbol3 == symbol3;
        }

        public override string GetAdvice()
        {
            Random rand = new Random();
            return rand.Next(0, 2) == 0 ? advice1 : advice2;
        }
    }
}
