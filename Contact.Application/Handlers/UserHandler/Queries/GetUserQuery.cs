using Contact.Core.Utilities.Results;
using Contact.Domain.Entities;
using Contact.Persistence.Abstract;
using MediatR;

namespace Contact.Application.Handlers.UserHandler.Queries;


public class GetUserQuery : IRequest<IDataResult<User>>
{ 
    public Guid UserId { get; set; }
    
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, IDataResult<User>>
    {
        private readonly IUserRepository _userRepository;
        
        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IDataResult<User>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetById(request.UserId);
            return new SuccessDataResult<User>(user);

        }
    }
}