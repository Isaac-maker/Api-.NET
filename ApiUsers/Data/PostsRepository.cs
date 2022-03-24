using Microsoft.EntityFrameworkCore;

namespace ApiUsers.Data
{
    internal static class PostsRepository
    {
        internal async static Task<List<Post>> GetPostsAsync()
        {
            using (var db = new AppDBContext())
            {
                return await db.Posts.ToListAsync();
            }
        }

        internal async static Task<Post> GetPostByIdAsync(int id)
        {
           using(var db = new AppDBContext())
            {
                return await db.Posts
                    .FirstOrDefaultAsync(post=>post.id == id);
            }
        }

        internal async static Task<bool> CreatePostAsync(Post posToCreate)
        {
            using (var db=new AppDBContext())
            {
                try { 
                
                    await db.Posts.AddAsync(posToCreate);
                    return await db.SaveChangesAsync()>=1;

                }
                catch(Exception) { 
                    
                    return false; }
            }
        }

        internal async static Task<bool> UpdatePostAsync(Post posToUpdate)
        {
            using (var db = new AppDBContext())
            {
                try
                {

                     db.Posts.Update(posToUpdate);
                    return await db.SaveChangesAsync() >= 1;

                }
                catch (Exception)
                {

                    return false;
                }
            }
        }


        internal async static Task<bool> DeletePostAsync(int id)
        {
            using (var db = new AppDBContext())
            {
                try
                {

                    Post pastToDelete = await GetPostByIdAsync(id);

                    db.Remove(pastToDelete);
                    return await db.SaveChangesAsync() >= 1;

                }
                catch (Exception)
                {

                    return false;
                }
            }
        }

    }
}
