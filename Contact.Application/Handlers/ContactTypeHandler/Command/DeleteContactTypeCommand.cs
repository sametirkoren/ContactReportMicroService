using Contact.Application.Constants;
using Contact.Application.Handlers.ContactHandler.Command;
using Contact.Core.Utilities.Results;
using Contact.Persistence.Abstract;
using MediatR;

namespace Contact.Application.Handlers.ContactTypeHandler.Command;


public class DeleteContactTypeCommand : IRequest<IResult>
{
    public Guid ContactTypeId { get; set; }
    
    public class DeleteContactTypeCommandHandler : IRequestHandler<DeleteContactTypeCommand, IResult>
    {
        private readonly IContactTypeRepository _contactTypeRepository;

        public DeleteContactTypeCommandHandler(IContactTypeRepository contactTypeRepository)
        {
            _contactTypeRepository = contactTypeRepository;
        }
        public async Task<IResult> Handle(DeleteContactTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var contactType = _contactTypeRepository.GetById(request.ContactTypeId);
                _contactTypeRepository.Delete(contactType);
                return new SuccessResult(Messages.Deleted);
            }
            catch (Exception e)
            {
                return new ErrorResult(Messages.DeletedError);
            }
        }
    }
}
