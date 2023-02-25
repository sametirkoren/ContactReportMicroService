using Contact.Core.Entities;

namespace Contact.Domain.Entities;

[Dapper.Contrib.Extensions.Table("users")]
public class User : IEntity
{
    [Dapper.Contrib.Extensions.Key]
    
    public Guid user_id { get; set; }
    
    public string first_name { get; set; }
    
    public string surname { get; set; }
    
    public string company { get; set; }
    
    
}