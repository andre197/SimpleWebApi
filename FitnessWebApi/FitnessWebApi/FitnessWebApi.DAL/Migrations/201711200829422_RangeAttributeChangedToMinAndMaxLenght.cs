namespace FitnessWebApi.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RangeAttributeChangedToMinAndMaxLenght : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Foods", "Name", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Foods", "Name", c => c.String(nullable: false));
        }
    }
}
