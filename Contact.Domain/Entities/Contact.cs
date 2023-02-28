using Contact.Core.Entities;

namespace Contact.Domain.Entities;

[Dapper.Contrib.Extensions.Table("contacts")]

public class Contact : IEntity
{
    [Dapper.Contrib.Extensions.ExplicitKey]
    
    public Guid contact_id { get; set; }
    
    public Guid user_id { get; set; }
    
    public Guid contact_type_id { get; set; }
    
    public string value { get; set; }
}