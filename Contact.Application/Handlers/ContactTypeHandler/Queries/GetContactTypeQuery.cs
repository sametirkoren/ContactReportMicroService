using Contact.Application.Handlers.UserHandler.Queries;
using Contact.Core.Utilities.Results;
using Contact.Domain.Entities;
using Contact.Persistence.Abstract;
using MediatR;

namespace Contact.Application.Handlers.ContactTypeHandler.Queries;



public class GetContactTypeQuery : IRequest<IDataResult<ContactType>>
{ 
    public Guid ContactTypeId { get; set; }
    
    public class GetContactTypeQueryHandler : IRequestHandler<GetContactTypeQuery, IDataResult<ContactType>>
    {
        private readonly IContactTypeRepository _contactTypeRepository;
        
        public GetContactTypeQueryHandler(IContactTypeRepository contactTypeRepository)
        {
            _contactTypeRepository = contactTypeRepository;
        }
        public async Task<IDataResult<ContactType>> Handle(GetContactTypeQuery request, CancellationToken cancellationToken)
        {
            var contactType = _contactTypeRepository.GetById(request.ContactTypeId);
            return new SuccessDataResult<ContactType>(contactType);

        }
    }
}
