namespace lab4_films.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ActorFilms", newName: "FilmActors");
            DropPrimaryKey("dbo.FilmActors");
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        genre_id = c.Int(nullable: false, identity: true),
                        genre = c.String(),
                    })
                .PrimaryKey(t => t.genre_id);
            
            AddPrimaryKey("dbo.FilmActors", new[] { "Film_film_id", "Actor_actor_id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.FilmActors");
            DropTable("dbo.Genres");
            AddPrimaryKey("dbo.FilmActors", new[] { "Actor_actor_id", "Film_film_id" });
            RenameTable(name: "dbo.FilmActors", newName: "ActorFilms");
        }
    }
}
