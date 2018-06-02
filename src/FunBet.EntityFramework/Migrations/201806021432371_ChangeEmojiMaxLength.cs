namespace FunBet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEmojiMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AppTeams", "Emoji", c => c.String(maxLength: 12));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppTeams", "Emoji", c => c.String(maxLength: 7));
        }
    }
}
