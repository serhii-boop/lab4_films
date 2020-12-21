namespace lab4_films.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class row : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "played_rolles", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actors", "played_rolles");
        }
    }
}
