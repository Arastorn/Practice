using FluentMigrator;

namespace Practice.DbMigration.Migrations
{
    [Migration(202102061737)]
    public class InitDb : Migration
    {
        public override void Up()
        {
            Execute.Script("InstallExtension.sql");

            Create.Table("digimons")
                .WithColumn("id").AsGuid().PrimaryKey().WithDefaultValue(SystemMethods.NewGuid)
                .WithColumn("nom").AsString(15).NotNullable().Indexed()
                .WithColumn("niveau").AsInt32().NotNullable()
                .WithColumn("created_at").AsDateTimeOffset().NotNullable().Indexed()
                .WithColumn("updated_at").AsDateTimeOffset().NotNullable().Indexed();
        }

        public override void Down()
        {
            Delete.Table("messages");
        }
    }
}