using System.Transactions;

namespace Produtos.Infra.Data.UnitWork
{
	public interface IUnitWork
	{
		TransactionScope GetTransaction();
		void SaveChanges();
	}
}
