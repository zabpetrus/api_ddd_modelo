using Flunt.Notifications;
using Produtos.Infra.Data.Context;
using System;
using System.Data;
using System.Transactions;
using IsolationLevel = System.Transactions.IsolationLevel;

namespace Produtos.Infra.Data.UnitWork
{
    public abstract class BaseUnitWork : Notifiable, IUnitWork
    {
        private IDatabaseContext _context;

        public BaseUnitWork(IDatabaseContext context)
        {
            _context = context;
        }

        public TransactionScope GetTransaction()
        {
            var options = new TransactionOptions();
            options.IsolationLevel = IsolationLevel.ReadCommitted;
            var transaction = new TransactionScope(TransactionScopeOption.Required, options);
            return transaction;
        }

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                AddNotification(null, "Não foi possível salvar as alterações no momento");
            }
        }
    }
}
