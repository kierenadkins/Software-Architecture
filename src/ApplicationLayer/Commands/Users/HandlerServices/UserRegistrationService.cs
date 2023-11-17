using DomainLayer.Contracts.Infrastructure;
using DomainLayer.Enums.UserEnum;
using DomainLayer.Factory.UserFactory;
using DomainLayer.Objects.Users;
using Shared.Services.Commands.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Commands.Users.HandlerServices
{
    public class UserRegistrationService : ICommandHandler<UserRegistration>
    {
        private readonly IUserFactory _userFactory;
        private readonly IUsersRepository _userRepository;
        public UserRegistrationService(IUserFactory userFactory,
            IUsersRepository userRepository)
        {
            _userFactory = userFactory;
            _userRepository = userRepository;
        }
        public async Task HandleAsync(UserRegistration command, CancellationToken cancellationToken = default)
        {
            var (firstName, lastName, email, password, dob, userType, branchid) = command;
            
            if(await _userRepository.ExistsAsync(email))
           {
                throw new NotImplementedException("User already exists");
           }

            IUser user;

            switch(userType)
            {
                case Roles.VisaApplicant:
                    user = _userFactory.CreateUserAccount(
                        Guid.NewGuid().ToString(),
                        firstName,
                        lastName,
                        email,
                        password,
                        dob,
                        userType,
                        null);
                    break;

                case Roles.VisaOfficer:
                    user = _userFactory.CreateUserAccount(
                        Guid.NewGuid().ToString(),
                        firstName,
                        lastName,
                        email,
                        password,
                        dob,
                        userType,
                        branchid);
                    break;

                case Roles.SupportSpecialist:
                    user = _userFactory.CreateUserAccount(
                        Guid.NewGuid().ToString(),
                        firstName,
                        lastName,
                        email,
                        password,
                        dob,
                        userType,
                        branchid);
                    break;

                case Roles.BranchManager:
                    user = _userFactory.CreateUserAccount(
                        Guid.NewGuid().ToString(),
                        firstName,
                        lastName,
                        email,
                        password,
                        dob,
                        userType,
                        branchid);
                    break;

                case Roles.Admin:
                    user = _userFactory.CreateUserAccount(
                        Guid.NewGuid().ToString(),
                        firstName,
                        lastName,
                        email,
                        password,
                        dob,
                        userType,
                        null);
                    break;
                default: throw new NotImplementedException("User does not exist");
            }

            user.HashPassword(); 
            await _userRepository.AddAsync(user);
        }
    }
}
