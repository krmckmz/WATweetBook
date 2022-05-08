﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WATweetBook.Domain;

namespace WATweetBook.Services
{
    public interface IPostService
    {
        Task<bool> CreatePostAsync(Post post);
        Task<bool> DeletePostAsync(Guid postId);
        Task<Post> GetPostByIdAsync(Guid postId);
        Task<List<Post>> GetPostsAsync();
        Task<bool> UpdatePostAsync(Post postToUpdate);
    }
}