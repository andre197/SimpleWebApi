namespace FitnessWebApi.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertiesFromDoubleToDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Foods", "ProteinContent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Foods", "SugarContent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Foods", "FatsContent", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Foods", "FatsContent", c => c.Double(nullable: false));
            AlterColumn("dbo.Foods", "SugarContent", c => c.Double(nullable: false));
            AlterColumn("dbo.Foods", "ProteinContent", c => c.Double(nullable: false));
        }
    }
}
