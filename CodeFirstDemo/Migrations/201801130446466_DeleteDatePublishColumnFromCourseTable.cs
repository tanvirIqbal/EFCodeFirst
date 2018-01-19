namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDatePublishColumnFromCourseTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "DatePublish");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "DatePublish", c => c.DateTime());
        }
    }
}
