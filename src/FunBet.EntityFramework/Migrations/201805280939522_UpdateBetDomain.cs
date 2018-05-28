namespace FunBet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBetDomain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppStandings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PredictorUserName = c.String(),
                        PredictorName = c.String(),
                        Points = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AppBets", "IsProcessed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Matches", "Finished", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matches", "Finished");
            DropColumn("dbo.AppBets", "IsProcessed");
            DropTable("dbo.AppStandings");
        }
    }
}
