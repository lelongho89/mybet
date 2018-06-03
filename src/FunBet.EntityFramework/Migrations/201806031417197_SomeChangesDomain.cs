namespace FunBet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeChangesDomain : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AppStandings", "PredictorId");
            AddForeignKey("dbo.AppStandings", "PredictorId", "dbo.AbpUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppStandings", "PredictorId", "dbo.AbpUsers");
            DropIndex("dbo.AppStandings", new[] { "PredictorId" });
        }
    }
}
