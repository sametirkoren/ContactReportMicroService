using Contact.Core.Utilities.Results;
using Contact.Domain.Entities;
using Contact.Persistence.Abstract;
using MediatR;

namespace Contact.Application.Handlers.UserHandler.Queries;

public class GetUsersQuery : IRequest<IDataResult<List<User>>>
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IDataResult<List<User>>>
    {
        private readonly IUserRepository _userRepository;


        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IDataResult<List<User>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var list = _userRepository.GetAll();
            return new SuccessDataResult<List<User>>(list);

        }
    }
}