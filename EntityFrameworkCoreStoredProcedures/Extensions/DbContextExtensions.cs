using System.Data.Common;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace StoredProcedureEntityFrameworkCore1.Extensions
{
    public static class DbContextExtensions
    {
        public static async Task<T[]> SqlQuery<T>(this DbContext db, string sql, params object[] parameters) where T : class
        {
            await using var db2 = new ContextForQueryType<T>(db.Database.GetDbConnection(), db.Database.CurrentTransaction);
            return await db2.Set<T>().FromSqlRaw(sql, parameters).ToArrayAsync();
        }

        private class ContextForQueryType<T> : DbContext where T : class
        {
            private readonly DbConnection _connection;
            private readonly IDbContextTransaction _transaction;

            public ContextForQueryType(DbConnection connection, IDbContextTransaction tran)
            {
                _connection = connection;
                _transaction = tran;

                if (tran != null)
                {
                    Database.UseTransaction((tran as IInfrastructure<DbTransaction>).Instance);
                }
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (_transaction != null)
                {
                    optionsBuilder.UseSqlServer(_connection);
                }
                else
                {
                    optionsBuilder.UseSqlServer(_connection, options => options.EnableRetryOnFailure());
                }
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<T>().HasNoKey().ToView(null);
            }
        }
    }
}