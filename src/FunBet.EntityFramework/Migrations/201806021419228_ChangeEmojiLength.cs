namespace FunBet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEmojiLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AppTeams", "EmojiString", c => c.String(maxLength: 5));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppTeams", "EmojiString", c => c.String(maxLength: 2));
        }
    }
}
