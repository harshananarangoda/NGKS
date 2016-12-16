namespace NGKS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tablemodification12142016 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Post", "Name", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Post", "Header", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Post", "Header", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Post", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
