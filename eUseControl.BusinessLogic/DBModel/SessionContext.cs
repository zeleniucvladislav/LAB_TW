using System.Data.Entity;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.DBModel.Seed
{
    internal class SessionContext : DbContext
    {
        public SessionContext() : base("name=ParawaDB")
        {
        }

        public virtual DbSet<Session> Sessions { get; set; }
    }
}