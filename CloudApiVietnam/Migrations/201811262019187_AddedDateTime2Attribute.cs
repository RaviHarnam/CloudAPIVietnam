namespace CloudApiVietnam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDateTime2Attribute : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Formulierens", "Created", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Formulierens", "Updated", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Formulierens", "Updated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Formulierens", "Created", c => c.DateTime(nullable: false));
        }
    }
}
