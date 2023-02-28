using Contact.Core.Entities;

namespace Contact.Domain.Entities;

[Dapper.Contrib.Extensions.Table("contactTypes")]

public class ContactType : IEntity
{
    [Dapper.Contrib.Extensions.ExplicitKey]
    
    public Guid contact_type_id { get; set; }
    
    public string name { get; set; }
    
    public string description { get; set; }
}