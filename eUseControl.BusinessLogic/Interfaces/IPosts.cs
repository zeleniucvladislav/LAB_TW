using eUseControl.Domain.Entities.Posts;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface IPosts
    {
        PostsResp SetPostsList(PostsTable post);
        List<string> GetPostsList();
        List<string> GetPostsList1();
        List<string> GetPostsList2();
    }
}
