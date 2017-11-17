namespace FitnessWebApi.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoodsMicronutrientsTableAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MicronutrientFoods", "Micronutrient_Id", "dbo.Micronutrients");
            DropForeignKey("dbo.MicronutrientFoods", "Food_Id", "dbo.Foods");
            DropIndex("dbo.MicronutrientFoods", new[] { "Micronutrient_Id" });
            DropIndex("dbo.MicronutrientFoods", new[] { "Food_Id" });
            CreateTable(
                "dbo.FoodsMicronutrients",
                c => new
                    {
                        FoodId = c.Int(nullable: false),
                        MicronutrientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FoodId, t.MicronutrientId })
                .ForeignKey("dbo.Foods", t => t.FoodId)
                .ForeignKey("dbo.Micronutrients", t => t.MicronutrientId)
                .Index(t => t.FoodId)
                .Index(t => t.MicronutrientId);
            
            AlterColumn("dbo.Foods", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Micronutrients", "Name", c => c.String(nullable: false));
            DropTable("dbo.MicronutrientFoods");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MicronutrientFoods",
                c => new
                    {
                        Micronutrient_Id = c.Int(nullable: false),
                        Food_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Micronutrient_Id, t.Food_Id });
            
            DropForeignKey("dbo.FoodsMicronutrients", "MicronutrientId", "dbo.Micronutrients");
            DropForeignKey("dbo.FoodsMicronutrients", "FoodId", "dbo.Foods");
            DropIndex("dbo.FoodsMicronutrients", new[] { "MicronutrientId" });
            DropIndex("dbo.FoodsMicronutrients", new[] { "FoodId" });
            AlterColumn("dbo.Micronutrients", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Foods", "Name", c => c.String());
            DropTable("dbo.FoodsMicronutrients");
            CreateIndex("dbo.MicronutrientFoods", "Food_Id");
            CreateIndex("dbo.MicronutrientFoods", "Micronutrient_Id");
            AddForeignKey("dbo.MicronutrientFoods", "Food_Id", "dbo.Foods", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MicronutrientFoods", "Micronutrient_Id", "dbo.Micronutrients", "Id", cascadeDelete: true);
        }
    }
}
