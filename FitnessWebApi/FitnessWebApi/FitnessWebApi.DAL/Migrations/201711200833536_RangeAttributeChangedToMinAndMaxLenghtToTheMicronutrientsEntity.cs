namespace FitnessWebApi.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RangeAttributeChangedToMinAndMaxLenghtToTheMicronutrientsEntity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Micronutrients", "Name", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Micronutrients", "Name", c => c.String(nullable: false));
        }
    }
}
