using System.Data;
using Contact.Core.DataAccess.Dapper;
using Contact.Domain.DTOs;
using Contact.Persistence.Abstract;
using Dapper;

namespace Contact.Persistence.Concrete.Dapper;

public class ContactRepository: DpEntityRepositoryBase<Domain.Entities.Contact>, IContactRepository
{
    public ContactRepository(IDbConnection dbConnection) : base(dbConnection)
    {
    }
    
    public void DeleteByUserId(Guid userId)
    {
        const string sql = @"DELETE FROM contacts WHERE ""user_id"" = @userId";
        _dbConnection.Query(sql, new { userId });

    }
    
    public List<GetUserContactDetail> GetUserContactDetail(Guid userId)
    {
        const string sql =
            @"select u.first_name as FirstName, u.surname as Surname, u.company as Company, c.value Value, ct.name as TypeName " +
            "from contacts c " +
            "left join users u on u.user_id = c.user_id " +
            @"left join public.""contactTypes"" ct on ct.contact_type_id = c.contact_type_id " + 
            @"WHERE c.user_id = @userId ";
        var userContactDetail = _dbConnection.Query<GetUserContactDetail>(sql, new {userId});
        return userContactDetail.ToList();
    }
}