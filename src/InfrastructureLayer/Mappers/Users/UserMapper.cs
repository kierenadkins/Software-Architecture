using DomainLayer.Factory.UserFactory;
using DomainLayer.Objects.Users;
using DomainLayer.ValueObjects.Users;
using InfrastructureLayer.Documents.UserDocuments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Mappers.Users
{
    public class UserMapper : IUserMapper
    {
        private readonly IUserFactory _userFactory;
        public UserMapper(IUserFactory userFactory)
        {
            _userFactory = userFactory;
        }

        public UserDocument ToUserDocument(IUser user) => new
            (
                user.Id.Value.ToString(),
                user.FirstName.Value,
                user.LastName.Value,
                user.Email.Value,
                user.Password.Value,
                user.Salt,
                user.AccountActive,
                user.UserLevel,
                user.Dob,
                user.BranchId?.Value.ToString()
            );

        public IUser ToUserModel(UserDocument userModel) => _userFactory.RetrieveUserAccount
            (
            userModel.Id,
            userModel.FirstName,
            userModel.LastName,
            userModel.Email,
            userModel.Password,
            userModel.Salt,
            userModel.AccountActive,
            userModel.Dob,
            userModel.Role,
            userModel.BranchId
            );


    }
}
