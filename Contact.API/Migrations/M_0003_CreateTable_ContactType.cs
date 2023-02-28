namespace Contact.API.Migrations;
using FluentMigrator;

[Migration(3)]
public class M_0003_CreateTable_ContactType : Migration
{
    public override void Up()
    {
        Create.Table("contactTypes")
            .WithColumn("contact_type_id").AsGuid().PrimaryKey()
            .WithColumn("name").AsString().NotNullable()
            .WithColumn("description").AsString().Nullable();
        
    }

    public override void Down()
    {
        Delete.Table("contactTypes");
    }
}