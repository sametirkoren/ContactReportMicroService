using System.Data;
using Contact.Core.DataAccess.Dapper;
using Contact.Domain.DTOs;
using Contact.Domain.Entities;
using Contact.Persistence.Abstract;
using Dapper;

namespace Contact.Persistence.Concrete.Dapper;

public class ContactTypeRepository : DpEntityRepositoryBase<Domain.Entities.ContactType>, IContactTypeRepository
{
    public ContactTypeRepository(IDbConnection dbConnection) : base(dbConnection)
    {
    }
    
    public List<ContactType> GetContactTypes()
    {
        const string sql =
            @"select ct.contact_type_id as contact_type_id, ct.name as name, ct.description as description " +
            @"from public.""contactTypes"" ct ";
            var contactTypes = _dbConnection.Query<ContactType>(sql);
        return contactTypes.ToList();
    }
}