namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);
            Sql("Insert into Categories (Name) values ('Web Development')");
            Sql("Insert into Categories (Name) values ('Mobile Development')");
        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}
