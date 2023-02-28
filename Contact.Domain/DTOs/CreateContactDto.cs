namespace Contact.Domain.DTOs;

public class CreateContactDto
{
    public Guid UserId { get; set; }
    
    public Guid ContactTypeId { get; set; }
    
    public string Value { get; set; }
}
