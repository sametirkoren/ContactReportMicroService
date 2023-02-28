using Contact.Application.Handlers.UserHandler.Queries;
using Contact.Core.Utilities.Results;
using Contact.Domain.DTOs;
using Contact.Domain.Entities;
using Contact.Persistence.Abstract;
using MediatR;

namespace Contact.Application.Handlers.ContactHandler.Queries;


public class GetUserContactDetailQuery : IRequest<IDataResult<List<GetUserContactDetail>>>
{ 
    public Guid UserId { get; set; }
    
    public class GetUserContactDetailQueryHandler : IRequestHandler<GetUserContactDetailQuery, IDataResult<List<GetUserContactDetail>>>
    {
        private readonly IContactRepository _contactRepository;
        
        public GetUserContactDetailQueryHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<IDataResult<List<GetUserContactDetail>>> Handle(GetUserContactDetailQuery request, CancellationToken cancellationToken)
        {
            var detail = _contactRepository.GetUserContactDetail(request.UserId);
            return new SuccessDataResult<List<GetUserContactDetail>>(detail);
        }
    }
}
