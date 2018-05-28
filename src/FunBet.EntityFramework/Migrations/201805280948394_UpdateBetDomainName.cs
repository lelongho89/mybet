namespace FunBet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBetDomainName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Matches", newName: "AppMatches");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AppMatches", newName: "Matches");
        }
    }
}
