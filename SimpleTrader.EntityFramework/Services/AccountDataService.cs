using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.EntityFramework.Services.Common;

namespace SimpleTrader.EntityFramework.Services
{
    public class AccountDataService:IDataService<Account>
    {
        private readonly SimpleTraderDbContextFactory _contextFactory;
        private readonly NonQueryDataService<Account> _nonQueryDataService;
        public AccountDataService(SimpleTraderDbContextFactory contextFactory, NonQueryDataService<Account> nonQueryDataService)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = nonQueryDataService;
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Account> entities = await context.Accounts.Include(a => a.AssetTransactions).ToListAsync();

                return entities;
            }
        }

        public async Task<Account> Get(int id)
        {
            using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
            {
                Account entity = await context.Accounts.Include(a => a.AssetTransactions).FirstOrDefaultAsync(e => e.Id == id);

                return entity;
            }
        }

        public async Task<Account> Create(Account entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<Account> Update(int id, Account entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }
    }
}