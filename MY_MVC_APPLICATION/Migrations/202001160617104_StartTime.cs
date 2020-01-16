namespace MY_MVC_APPLICATION.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StartTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Traffic", "StartTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Traffic", "EndTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Traffic", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Traffic", "StartTime", c => c.DateTime(nullable: false));
        }
    }
}
