namespace FunBet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEmojiStringMaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AppTeams", "Emoji", c => c.String(maxLength: 20));
            AlterColumn("dbo.AppTeams", "EmojiString", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppTeams", "EmojiString", c => c.String(maxLength: 5));
            AlterColumn("dbo.AppTeams", "Emoji", c => c.String(maxLength: 12));
        }
    }
}
