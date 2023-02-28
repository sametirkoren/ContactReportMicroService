using System.Data;
using Contact.Core.DataAccess.Dapper;
using Contact.Domain.Entities;
using Contact.Persistence.Abstract;

namespace Contact.Persistence.Concrete.Dapper;

public class UserRepository : DpEntityRepositoryBase<User>, IUserRepository
{
    public UserRepository(IDbConnection dbConnection) : base(dbConnection)
    {
    }
}