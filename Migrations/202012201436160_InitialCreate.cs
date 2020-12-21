namespace lab4_films.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        film_id = c.Int(nullable: false, identity: true),
                        film = c.String(nullable: false, maxLength: 50),
                        main_director = c.String(nullable: false),
                        budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.film_id);
            
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        actor_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        age = c.Int(nullable: false),
                        nationality = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.actor_id);
            
            CreateTable(
                "dbo.ActorFilms",
                c => new
                    {
                        Actor_actor_id = c.Int(nullable: false),
                        Film_film_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Actor_actor_id, t.Film_film_id })
                .ForeignKey("dbo.Actors", t => t.Actor_actor_id, cascadeDelete: true)
                .ForeignKey("dbo.Films", t => t.Film_film_id, cascadeDelete: true)
                .Index(t => t.Actor_actor_id)
                .Index(t => t.Film_film_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActorFilms", "Film_film_id", "dbo.Films");
            DropForeignKey("dbo.ActorFilms", "Actor_actor_id", "dbo.Actors");
            DropIndex("dbo.ActorFilms", new[] { "Film_film_id" });
            DropIndex("dbo.ActorFilms", new[] { "Actor_actor_id" });
            DropTable("dbo.ActorFilms");
            DropTable("dbo.Actors");
            DropTable("dbo.Films");
        }
    }
}
