namespace Contact.API.Migrations;
using FluentMigrator;

[Migration(1)]
public class M_0001_CreateTable_User : Migration
{
    public override void Up()
    {
        Create.Table("users")
            .WithColumn("user_id").AsGuid().PrimaryKey()
            .WithColumn("first_name").AsString().NotNullable()
            .WithColumn("surname").AsString().NotNullable()
            .WithColumn("company").AsString().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("users");
    }
}