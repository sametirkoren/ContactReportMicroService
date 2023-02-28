using Contact.Application.Constants;
using Contact.Application.Handlers.UserHandler.Command;
using Contact.Core.Utilities.Results;
using Contact.Persistence.Abstract;
using MediatR;

namespace Contact.Application.Handlers.ContactHandler.Command;


public class DeleteContactCommand : IRequest<IResult>
{
    public Guid UserId { get; set; }
    
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, IResult>
    {
        private readonly IContactRepository _contactRepository;

        public DeleteContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<IResult> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _contactRepository.DeleteByUserId(request.UserId);
                return new SuccessResult(Messages.Deleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.DeletedError);
            }
        }
    }
}
