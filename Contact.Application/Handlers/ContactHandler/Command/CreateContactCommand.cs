using Contact.Application.Constants;
using Contact.Core.Utilities.Results;
using Contact.Persistence.Abstract;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Contact.Application.Handlers.ContactHandler.Command;


public class CreateContactCommand : IRequest<IResult>
    {
        
        public Guid UserId { get; set; }

        public Guid ContactTypeId { get; set; }

        public string Value { get; set; }



        public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, IResult>
        {
            private readonly IContactRepository _contactRepository;

            public CreateContactCommandHandler(IContactRepository contactRepository)
            {
                _contactRepository = contactRepository;
          
            }
            public Task<IResult> Handle(CreateContactCommand request, CancellationToken cancellationToken)
            {

                try
                {
                    var createContact = new Domain.Entities.Contact
                    {
                        user_id = request.UserId,
                        contact_type_id = request.ContactTypeId,
                        value = request.Value,
                        contact_id = Guid.NewGuid()
                    };
                
                    _contactRepository.Insert(createContact);
                
                    return Task.FromResult<IResult>(new SuccessResult(Messages.Added));
                }
                catch (Exception e)
                {
                    return Task.FromResult<IResult>(new ErrorResult(Messages.AddedError));
                }
            }
        }
    }