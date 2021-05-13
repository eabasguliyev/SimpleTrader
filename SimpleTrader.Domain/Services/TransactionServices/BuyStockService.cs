﻿using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services.TransactionServices
{
    public class BuyStockService:IBuyStockService
    {
        private readonly IStockPriceService _stockPriceService;
        private readonly IDataService<Account> _accountService;

        public BuyStockService(IStockPriceService stockPriceService, IDataService<Account> accountService)
        {
            _stockPriceService = stockPriceService;
            _accountService = accountService;
        }

        public async Task<Account> BuyStock(Account buyer, string symbol, int shares)
        {
            double stockPrice = await _stockPriceService.GetPrice(symbol);

            double transactionPrice = stockPrice * shares;

            if (transactionPrice > buyer.Balance)
                throw new InsufficientFundsException(buyer.Balance, transactionPrice);

            AssetTransaction newTransaction = new AssetTransaction()
            {
                Account =  buyer,
                Asset = new Asset()
                {
                    Symbol = symbol,
                    PricePerShare = stockPrice,
                },
                Shares = shares,
                DateProcessed = DateTime.Now,
                IsPurchase = true,
            };

            buyer.AssetTransactions.Add(newTransaction);
            buyer.Balance -= transactionPrice;

            await _accountService.Update(buyer.Id, buyer);

            return buyer;
        }
    }
}