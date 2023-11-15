using DomainLayer.Contracts.Infrastructure;
using DomainLayer.Objects.Users;
using DomainLayer.ValueObjects.Users;
using InfrastructureLayer.Documents.UserDocuments;
using InfrastructureLayer.Mappers.Users;
using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.CosmosRepository.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IRepository<UserDocument> _userRepository;
        private readonly IUserMapper _mapper;


        public UsersRepository(IRepository<UserDocument> usersRepository, IUserMapper userMapper)
        {
            _userRepository = usersRepository;
            _mapper = userMapper;
        }
        public async Task AddAsync(IUser user)
        {
            await _userRepository.CreateAsync(_mapper.ToUserDocument(user));
        }

        public async Task<bool> ExistsAsync(string email)
        {
            var exists = await _userRepository.GetAsync(x => x.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase));
            return exists.Any();
        }

        public async Task<IUser?> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(x => x.Email == email).FirstOrDefaultAsync();
            if (user is null)
            {
                return null;
            }
            return _mapper.ToUserModel(user);
        }
    }
}
