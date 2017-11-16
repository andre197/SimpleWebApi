namespace FitnessWebApi.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MicronutrientsTableAddedCategoryColumnInFoodsAddedManyToManyAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Micronutrients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MicronutrientFoods",
                c => new
                    {
                        Micronutrient_Id = c.Int(nullable: false),
                        Food_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Micronutrient_Id, t.Food_Id })
                .ForeignKey("dbo.Micronutrients", t => t.Micronutrient_Id, cascadeDelete: true)
                .ForeignKey("dbo.Foods", t => t.Food_Id, cascadeDelete: true)
                .Index(t => t.Micronutrient_Id)
                .Index(t => t.Food_Id);
            
            AddColumn("dbo.Foods", "Category", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MicronutrientFoods", "Food_Id", "dbo.Foods");
            DropForeignKey("dbo.MicronutrientFoods", "Micronutrient_Id", "dbo.Micronutrients");
            DropIndex("dbo.MicronutrientFoods", new[] { "Food_Id" });
            DropIndex("dbo.MicronutrientFoods", new[] { "Micronutrient_Id" });
            DropColumn("dbo.Foods", "Category");
            DropTable("dbo.MicronutrientFoods");
            DropTable("dbo.Micronutrients");
        }
    }
}
