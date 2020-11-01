using System.Collections.Generic;
using VosakOrgDataAccessLayer;
using VosakOrgRepositoryLayer;

namespace VosakOrgServiceLayer
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> _postRepository;

        public PostService(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public IEnumerable<Post> GetAllPost()
        {
            return _postRepository.GetAll();
        }

        public Post GetPost(int Id)
        {
            return _postRepository.Get(Id);
        }
    }
}
