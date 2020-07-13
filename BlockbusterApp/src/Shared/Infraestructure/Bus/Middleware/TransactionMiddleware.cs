using BlockbusterApp.src.Shared.Application.Bus.UseCase;
using BlockbusterApp.src.Shared.Infraestructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Shared.Infraestructure.Bus.Middleware
{
    public class TransactionMiddleware : MiddlewareHandler
    {
        private BlockbusterContext _blockbusterContext;

        public TransactionMiddleware(BlockbusterContext blockbusterContext)
        {
            _blockbusterContext = blockbusterContext;
        }

        public override IResponse Handle(IRequest request)
        {
            var transaction = _blockbusterContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            try
            {
                IResponse response = base.Handle(request);
                _blockbusterContext.SaveChanges();
                transaction.Commit();
                return response;
            }
            catch (System.Exception e)
            {
                transaction.Rollback();
                _blockbusterContext.ChangeTracker.Entries().ToList().ForEach(x => x.State = EntityState.Detached);
                throw e;
            }
        }
    }
}
