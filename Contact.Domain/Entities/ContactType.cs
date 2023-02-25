namespace Contact.Domain.Entities;

[Dapper.Contrib.Extensions.Table("contactTypes")]

public class ContactType
{
    [Dapper.Contrib.Extensions.Key]
    
    public Guid contact_type_id { get; set; }
    
    public string name { get; set; }
    
    public string description { get; set; }
}