using System.Collections.Generic;
using VosakOrgDataAccessLayer;

namespace VosakOrgServiceLayer
{
    public interface IPostService
    {
        IEnumerable<Post> GetAllPost();

        Post GetPost(int Id);
    }
}
