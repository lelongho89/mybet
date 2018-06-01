namespace FunBet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGroupMatchDomain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenantId = c.Int(),
                        Name = c.String(),
                        Winner = c.Int(),
                        RunnerUp = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppTeams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TenantId = c.Int(),
                        Name = c.String(maxLength: 50),
                        Flag = c.String(maxLength: 255),
                        FifaCode = c.String(maxLength: 3),
                        Emoji = c.String(maxLength: 7),
                        EmojiString = c.String(maxLength: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AppBets", "HomePredict", c => c.Int());
            AddColumn("dbo.AppBets", "AwayPredict", c => c.Int());
            AddColumn("dbo.AppMatches", "TenantId", c => c.Int());
            AddColumn("dbo.AppMatches", "Name", c => c.Int(nullable: false));
            AddColumn("dbo.AppMatches", "GroupId", c => c.Int(nullable: false));
            AddColumn("dbo.AppMatches", "Type", c => c.String(maxLength: 20));
            AddColumn("dbo.AppMatches", "HomeResult", c => c.Int());
            AddColumn("dbo.AppMatches", "AwayResult", c => c.Int());
            AddColumn("dbo.AppMatches", "HomePenalty", c => c.Int());
            AddColumn("dbo.AppMatches", "AwayPenalty", c => c.Int());
            AddColumn("dbo.AppMatches", "Winner", c => c.Int());
            AddColumn("dbo.AppMatches", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.AppMatches", "Stadium", c => c.String(maxLength: 250));
            AddColumn("dbo.AppMatches", "MatchDay", c => c.Int(nullable: false));
            AddColumn("dbo.AppStandings", "PredictorId", c => c.Long(nullable: false));
            AlterColumn("dbo.AppMatches", "HomeTeam", c => c.Int(nullable: false));
            AlterColumn("dbo.AppMatches", "AwayTeam", c => c.Int(nullable: false));
            CreateIndex("dbo.AppMatches", "GroupId");
            AddForeignKey("dbo.AppMatches", "GroupId", "dbo.AppGroups", "Id", cascadeDelete: true);
            DropColumn("dbo.AppBets", "PredictScore");
            DropColumn("dbo.AppMatches", "StartTime");
            DropColumn("dbo.AppMatches", "Avenue");
            DropColumn("dbo.AppMatches", "Group");
            DropColumn("dbo.AppMatches", "FinalScore");
            DropColumn("dbo.AppStandings", "PredictorUserName");
            DropColumn("dbo.AppStandings", "PredictorName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppStandings", "PredictorName", c => c.String());
            AddColumn("dbo.AppStandings", "PredictorUserName", c => c.String());
            AddColumn("dbo.AppMatches", "FinalScore", c => c.String());
            AddColumn("dbo.AppMatches", "Group", c => c.String());
            AddColumn("dbo.AppMatches", "Avenue", c => c.String());
            AddColumn("dbo.AppMatches", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.AppBets", "PredictScore", c => c.String());
            DropForeignKey("dbo.AppMatches", "GroupId", "dbo.AppGroups");
            DropIndex("dbo.AppMatches", new[] { "GroupId" });
            AlterColumn("dbo.AppMatches", "AwayTeam", c => c.String());
            AlterColumn("dbo.AppMatches", "HomeTeam", c => c.String());
            DropColumn("dbo.AppStandings", "PredictorId");
            DropColumn("dbo.AppMatches", "MatchDay");
            DropColumn("dbo.AppMatches", "Stadium");
            DropColumn("dbo.AppMatches", "Date");
            DropColumn("dbo.AppMatches", "Winner");
            DropColumn("dbo.AppMatches", "AwayPenalty");
            DropColumn("dbo.AppMatches", "HomePenalty");
            DropColumn("dbo.AppMatches", "AwayResult");
            DropColumn("dbo.AppMatches", "HomeResult");
            DropColumn("dbo.AppMatches", "Type");
            DropColumn("dbo.AppMatches", "GroupId");
            DropColumn("dbo.AppMatches", "Name");
            DropColumn("dbo.AppMatches", "TenantId");
            DropColumn("dbo.AppBets", "AwayPredict");
            DropColumn("dbo.AppBets", "HomePredict");
            DropTable("dbo.AppTeams");
            DropTable("dbo.AppGroups");
        }
    }
}
