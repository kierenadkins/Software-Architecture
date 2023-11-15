using DomainLayer.Objects.Users;
using InfrastructureLayer.Documents.UserDocuments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Mappers.Users
{
    public interface IUserMapper
    {
        UserDocument ToUserDocument(IUser userDocument);
        IUser ToUserModel(UserDocument userModel);
    }
}
