using System;

namespace SimpleTrader.Domain.Exceptions
{
    public class InvalidSymbolException:ApplicationException
    {
        public string Symbol { get; set; }

        public InvalidSymbolException(string symbol)
        {
            Symbol = symbol;
        }

        public InvalidSymbolException(string symbol, string message):base(message)
        {
            Symbol = symbol;
        }

        public InvalidSymbolException(string symbol, string message, Exception innerException): base(message, innerException)
        {
            Symbol = symbol;
        }
    }
}