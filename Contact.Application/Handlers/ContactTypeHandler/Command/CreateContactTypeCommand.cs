using Contact.Application.Constants;
using Contact.Application.Handlers.ContactHandler.Command;
using Contact.Core.Utilities.Results;
using Contact.Persistence.Abstract;
using MediatR;

namespace Contact.Application.Handlers.ContactTypeHandler.Command;

public class CreateContactTypeCommand : IRequest<IResult>
{
        
    public string Name { get; set; }
    
    public class CreateContactTypeCommandHandler : IRequestHandler<CreateContactTypeCommand, IResult>
    {
        private readonly IContactTypeRepository _contactTypeRepository;

        public CreateContactTypeCommandHandler(IContactTypeRepository contactTypeRepository)
        {
            _contactTypeRepository = contactTypeRepository;
          
        }
        public Task<IResult> Handle(CreateContactTypeCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var createContactType = new Domain.Entities.ContactType()
                {
                    contact_type_id = Guid.NewGuid(),
                    name =  request.Name
                };
                
                _contactTypeRepository.Insert(createContactType);
                
                return Task.FromResult<IResult>(new SuccessResult(Messages.Added));
            }
            catch (Exception e)
            {
                return Task.FromResult<IResult>(new ErrorResult(Messages.AddedError));
            }
        }
    }
}
