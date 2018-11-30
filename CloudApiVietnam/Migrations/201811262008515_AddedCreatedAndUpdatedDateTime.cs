namespace CloudApiVietnam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCreatedAndUpdatedDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Formulierens", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Formulierens", "Updated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Formulierens", "Updated");
            DropColumn("dbo.Formulierens", "Created");
        }
    }
}
