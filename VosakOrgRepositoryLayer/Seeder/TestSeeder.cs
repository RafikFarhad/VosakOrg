using Faker;
using System;
using System.Collections.Generic;
using System.Linq;
using VosakOrgDataAccessLayer;

namespace VosakOrgRepositoryLayer.Seeder
{
    public class TestSeeder
    {
        private readonly VosakOrgDBContext _context;

        public TestSeeder(VosakOrgDBContext context)
        {
            _context = context;

            var posts = new List<Post> {
                new Post { Id=1, Name = "President", Order = 0 },
                new Post { Id=2, Name = "Vice-President", Order = 0 },
                new Post { Id=3, Name = "General Secretary", Order = 0 },
                new Post { Id=4, Name = "Director", Order = 0 }
            };
            int postSaved = SeedPostValues(posts);
            if(postSaved == posts.Count)
            {
                SeedMember(posts);
            }
        }

        private void SeedMember(List<Post> posts)
        {
            List<Member> members = new List<Member>();
            RandomDateTime dateOfBirth = new RandomDateTime();
            RandomDateTime joinedAt = new RandomDateTime(new DateTime(2005, 2, 21));
            members.Add(new Member
            {
                Name = Faker.Name.FullName(),
                Address = Faker.Address.StreetAddress(true),
                Order = 0,
                BloodGroup = Faker.Enum.Random<BloodGroup>(),
                JoinedAt = joinedAt.Next(),
                DateOfBirth = dateOfBirth.Next(),
                Post = posts[0],
            });
            for (int i = 0; i < 100; i++)
            {
                members.Add(new Member
                {
                    Name = Faker.Name.FullName(),
                    Address = Faker.Address.StreetAddress(true),
                    Order = 0,
                    BloodGroup = Faker.Enum.Random<BloodGroup>(),
                    JoinedAt = joinedAt.Next(),
                    DateOfBirth = dateOfBirth.Next(),
                    Post = posts[Faker.RandomNumber.Next(1, posts.Count)],
                });
            }
            IRepository<Member> memberRepository = new Repository<Member>(_context);
            memberRepository.AddRange(members);
            _context.SaveChanges();
        }
        private int SeedPostValues(List<Post> posts)
        {
            IRepository<Post> postRepository = new Repository<Post>(_context);
            int[] postIds = posts.Select(p => p.Id).Distinct().ToArray();
            var postInDbIds = postRepository.GetAll().ToList()
                .Where(p => postIds.Contains(p.Id))
                .Select(p => p.Id)
                .ToList();
            var postNotInDb = posts.Where(p => !postInDbIds.Contains(p.Id));
            int saved = 0;
            foreach (Post post in postNotInDb)
            {
                _context.Add(post);
                saved++;
            }
            _context.SaveChanges();
            return saved;
        }
    }

    class RandomDateTime
    {
        readonly DateTime start;
        readonly Random gen;
        readonly int range;

        public RandomDateTime() : this(new DateTime(1970, 1, 1))
        {
        }

        public RandomDateTime(DateTime leastDate)
        {
            start = leastDate;
            gen = new Random();
            range = (DateTime.Today - start).Days;
        }

        public DateTime Next()
        {
            return start.AddDays(gen.Next(range)).AddHours(gen.Next(0, 24)).AddMinutes(gen.Next(0, 60)).AddSeconds(gen.Next(0, 60));
        }
    }
}
