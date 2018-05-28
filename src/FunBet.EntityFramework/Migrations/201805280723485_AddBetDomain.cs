namespace FunBet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBetDomain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppBets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MatchId = c.Int(nullable: false),
                        PredictorId = c.Long(nullable: false),
                        PredictScore = c.String(),
                        PredictTime = c.DateTime(nullable: false),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Matches", t => t.MatchId, cascadeDelete: true)
                .ForeignKey("dbo.AbpUsers", t => t.PredictorId, cascadeDelete: true)
                .Index(t => t.MatchId)
                .Index(t => t.PredictorId);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        HomeTeam = c.String(),
                        AwayTeam = c.String(),
                        Avenue = c.String(),
                        Group = c.String(),
                        FinalScore = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppBets", "PredictorId", "dbo.AbpUsers");
            DropForeignKey("dbo.AppBets", "MatchId", "dbo.Matches");
            DropIndex("dbo.AppBets", new[] { "PredictorId" });
            DropIndex("dbo.AppBets", new[] { "MatchId" });
            DropTable("dbo.Matches");
            DropTable("dbo.AppBets");
        }
    }
}
