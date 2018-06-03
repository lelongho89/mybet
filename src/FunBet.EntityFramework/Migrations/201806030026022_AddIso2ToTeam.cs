namespace FunBet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIso2ToTeam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppTeams", "Iso2", c => c.String(maxLength: 6));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppTeams", "Iso2");
        }
    }
}
