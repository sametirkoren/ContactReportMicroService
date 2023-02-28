using Contact.Application.Constants;
using Contact.Core.Utilities.Results;
using Contact.Domain.Entities;
using Contact.Persistence.Abstract;
using MediatR;

namespace Contact.Application.Handlers.UserHandler.Command;

public class CreateUserCommand : IRequest<IResult>
{
    public string FirstName { get; set; }
    
    public string Surname { get; set; }
    
    public string Company { get; set; }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IResult>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IResult> Handle(CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                var createUser = new User()
                {
                    first_name = request.FirstName,
                    surname = request.Surname,
                    company = request.Company,
                    user_id = Guid.NewGuid()
                };
            
                _userRepository.Insert(createUser);
                return Task.FromResult<IResult>(new SuccessResult(Messages.Added));

            }
            catch (Exception e)
            {
                return Task.FromResult<IResult>(new ErrorResult(Messages.AddedError));
            }
        }
    }
}


