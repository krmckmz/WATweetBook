using System;
using System.Collections.Generic;
using WATweetBook.Domain;

namespace WATweetBook.Services
{
    public interface IPostService
    {
        List<Post> GetPosts();
        Post GetPostById(Guid postId);
    }
}
