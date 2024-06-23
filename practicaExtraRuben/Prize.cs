using System;

namespace practicaExtra
{
    public abstract class Prize
    {
        private int id = 1;
        protected string name;
        protected int symbol1;
        protected int symbol2;
        protected int symbol3;

        public Prize(string Name, int Symbol1, int Symbol2, int Symbol3)
        {
            this.name = Name;
            this.symbol1 = Symbol1;
            this.symbol2 = Symbol2;
            this.symbol3 = Symbol3;
        }

        public abstract bool winningComb(int symbol1, int symbol2, int symbol3);
        public abstract string GetAdvice();

        public int GetId()
        {
            return this.id;
        }

        
        public string GetName()
        {
            return this.name;
        }

        public int GetSymbol1()
        {
            return this.symbol1;
        }

        public int GetSymbol2()
        {
            return this.symbol2;
        }

        public int GetSymbol3()
        {
            return this.symbol3;
        }
    }
}
