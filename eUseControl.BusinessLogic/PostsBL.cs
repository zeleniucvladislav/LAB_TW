using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Posts;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic
{
    public class PostsBL : UserApi, IPosts
    {
        public PostsResp SetPostsList(PostsTable post)
        {
            return AddPosts(post);
        }
        public List<string> GetPostsList()
        {
            return PostsListLogic();
        }

        public List<string> GetPostsList1()
        {
            return PostsListLogic1();
        }

        public List<string> GetPostsList2()
        {
            return PostsListLogic2();
        }

    }
}
