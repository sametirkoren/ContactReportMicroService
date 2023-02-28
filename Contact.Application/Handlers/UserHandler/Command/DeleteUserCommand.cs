using Contact.Application.Constants;
using Contact.Core.Utilities.Results;
using Contact.Persistence.Abstract;
using MediatR;

namespace Contact.Application.Handlers.UserHandler.Command;

public class DeleteUserCommand : IRequest<IResult>
{
    public Guid UserId { get; set; }
    
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, IResult>
    {

        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _userRepository.GetById(request.UserId);
                _userRepository.Delete(user);
                return new SuccessResult(Messages.Deleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.DeletedError);
            }
        }
    }
}