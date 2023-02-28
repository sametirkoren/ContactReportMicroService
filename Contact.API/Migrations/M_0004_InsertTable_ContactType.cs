namespace Contact.API.Migrations;
using FluentMigrator;

[Migration(4)]
public class M_0004_InsertTable_ContactType : Migration
{
    public override void Up()
    {
        
        Insert.IntoTable("contactTypes").Row(new
        {
            contact_type_id = Guid.NewGuid(),
            name = "PhoneNumber",
        });
        
        Insert.IntoTable("contactTypes").Row(new
        {
            contact_type_id = Guid.NewGuid(),
            name = "Email",
        });
        
        Insert.IntoTable("contactTypes").Row(new
        {
            contact_type_id = Guid.NewGuid(),
            name = "Location",
        });
    }

    public override void Down()
    {
        Delete.Table("contactTypes");
    }
}