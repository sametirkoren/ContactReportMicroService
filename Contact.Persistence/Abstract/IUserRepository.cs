using Contact.Core.DataAccess;
using Contact.Domain.Entities;

namespace Contact.Persistence.Abstract;

public interface IUserRepository : IEntityRepository<User>
{
    
}