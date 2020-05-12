using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.User;

namespace eUseControl.BusinessLogic.DBModel
{
    public class PostsContext : DbContext
    {
        public PostsContext() : base("name=ParawaDB")
        {
        }

        public virtual DbSet<PostsTable> Posts { get; set; }
    }
}
