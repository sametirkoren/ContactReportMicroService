using Contact.Core.DataAccess;
using Contact.Domain.DTOs;
using Contact.Domain.Entities;

namespace Contact.Persistence.Abstract;

public interface IContactRepository : IEntityRepository<Domain.Entities.Contact>
{ 
    public void DeleteByUserId(Guid userId);

    public List<GetUserContactDetail> GetUserContactDetail(Guid userId);

}
