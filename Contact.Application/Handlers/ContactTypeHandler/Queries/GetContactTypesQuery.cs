using Contact.Application.Handlers.UserHandler.Queries;
using Contact.Core.Utilities.Results;
using Contact.Domain.Entities;
using Contact.Persistence.Abstract;
using MediatR;

namespace Contact.Application.Handlers.ContactTypeHandler.Queries;


public class GetContactTypesQuery : IRequest<IDataResult<List<ContactType>>>
{
    public class GetContactTypesQueryHandler : IRequestHandler<GetContactTypesQuery, IDataResult<List<ContactType>>>
    {
        private readonly IContactTypeRepository _contactTypeRepository;


        public GetContactTypesQueryHandler(IContactTypeRepository contactTypeRepository)
        {
            _contactTypeRepository = contactTypeRepository;
        }
        public async Task<IDataResult<List<ContactType>>> Handle(GetContactTypesQuery request, CancellationToken cancellationToken)
        {
            var list = _contactTypeRepository.GetContactTypes();
            return new SuccessDataResult<List<ContactType>>(list);

        }
    }
}
