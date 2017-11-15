namespace FitnessWebApi.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManuallyValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Foods", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Foods", "Name", c => c.String(nullable: false));
        }
    }
}
