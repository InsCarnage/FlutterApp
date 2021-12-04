using CarnageApi.Core.Models;
using System.Collections.Generic;
using System.Data;
using CarnageApi.Core.Interfaces;

namespace CarnageApi.Core.Interfaces
{
    public interface IFourty5MillionUnitOfWork
	{
      
		IRepository<Permission> Permission { get; }
		IRepository<Site> Site { get; }
		IRepository<User> User { get; }
		IRepository<UserSiteRoll> UserSiteRoll { get; }

        void Save();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();

        List<T> FetchDtoList<T>(
          string spName,
          IEnumerable<IDataParameter> parameters)
          where T : new();

		//T QueryDatabaseStoredProcedure<T>(string query);
		//void ExecuteDatabaseStoredProcedure(string query);
		//List<T> QueryDatabaseStoredProcedureList<T>(string query);
	}
}
