namespace Contact.API.Migrations;
using FluentMigrator;

[Migration(2)]
public class M_0002_CreateTable_Contact : Migration
{
    public override void Up()
    {
        Create.Table("contacts")
            .WithColumn("contact_id").AsGuid().PrimaryKey().Identity()
            .WithColumn("user_id").AsGuid().NotNullable()
            .WithColumn("contact_type_id").AsGuid().NotNullable()
            .WithColumn("value").AsGuid().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("contacts");
    }
}