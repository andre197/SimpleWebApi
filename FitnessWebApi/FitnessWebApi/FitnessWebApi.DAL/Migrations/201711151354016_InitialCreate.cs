namespace FitnessWebApi.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ProteinContent = c.Double(nullable: false),
                        SugarContent = c.Double(nullable: false),
                        Fats = c.Int(nullable: false),
                        FatsContent = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Foods");
        }
    }
}
