using Contact.Core.DataAccess;
using Contact.Domain.Entities;

namespace Contact.Persistence.Abstract;

public interface IContactTypeRepository  : IEntityRepository<ContactType>
{
    public List<ContactType> GetContactTypes();

}