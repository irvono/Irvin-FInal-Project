namespace OnoWeb.Migrations
{
    using OnoWeb.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnoWeb.DAL.OnoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "OnoWeb.DAL.OnoContext";
        }

        protected override void Seed(OnoWeb.DAL.OnoContext context)
        {
            var oners = new List<Oner>
            {
                new Oner{LastName="Carson",FirstName="Alexander",Email="carsAlex@live.com", Skill="Photographer", 
                         Password="driveHonda240", Address="137 Olive st", Phone= "541-222-2222"},

                new Oner{LastName="Hess",FirstName="Nate",Email="curlymustache@gmail.com", Skill="Graphic Design", 
                         Password="100klife", Address="9875 Ice Lake Dr", Phone= "606-852-5555"},

                new Oner{LastName="Vargas",FirstName="Irvin",Email="vargasirvin@live.com", Skill="Videographer", 
                         Password="12iv0507zmz", Address="499 49th st", Phone= "541-555-5555"}
            };
            oners.ForEach(s => context.Oners.AddOrUpdate(s));
            context.SaveChanges();

            var albums = new List<Album>
            {
                new Album{Title="Project"},
                new Album{Title="Euro Style"},
                new Album{Title="Fortunes"}
               
            };
            albums.ForEach(s => context.Albums.AddOrUpdate(s));
            context.SaveChanges();

            var photos = new List<Photo>
            {
                new Photo{Name="Convertible Cruising", PhotoFile="~/Images/bmwE30.jpg", AlbumID=1, 
                          OnerID=oners.Single(u => u.LastName == "Carson").OnerID},
                new Photo{Name="Guitar Free Lens", PhotoFile="~/Images/guitarAnamorphic.jpg", AlbumID=2, 
                          OnerID=oners.Single(u => u.LastName == "Hess").OnerID},
                new Photo{Name="VW Scirocco Mk2", PhotoFile="~/Images/sciroccomk2.jpg", AlbumID=3, 
                          OnerID=oners.Single(u => u.LastName == "Vargas").OnerID}
               
            };
            photos.ForEach(s => context.Photos.AddOrUpdate(s));
            context.SaveChanges();

            var genres = new List<Genre>
            {
                new Genre{GenreName="Action", Description="Fast pace with a lot of movement and keeps the audience eyes moving" },
                new Genre{GenreName="Comedy", Description="Humorous, funny, and easy to watch" },
                new Genre{GenreName="Horror", Description="Violence and brutality" }
               
            };
            genres.ForEach(s => context.Genres.AddOrUpdate(s));
            context.SaveChanges();

            var videos = new List<Video>
            {
                new Video{Title="Scorched in Fire", GenreID=genres.Single(g => g.GenreName == "Action").GenreID, 
                          OnerID=oners.Single(u => u.LastName == "Carson").OnerID},
                new Video{Title="Homework",  GenreID=genres.Single(g => g.GenreName == "Comedy").GenreID, 
                         OnerID=oners.Single(u => u.LastName == "Hess").OnerID},
                new Video{Title="Metal", GenreID=genres.Single(g => g.GenreName == "Horror").GenreID, 
                         OnerID=oners.Single(u => u.LastName == "Vargas").OnerID},

               
            };
            videos.ForEach(s => context.Videos.AddOrUpdate(s));
            context.SaveChanges();


            var events = new List<Event>
            {
                new Event{Title="Video Premiere", Description="Premiere of my first short film",
                         OnerID=oners.Single(u => u.LastName == "Carson").OnerID},
                new Event{Title="Photo Gallery", Description="My friend is having a gallery show!", 
                         OnerID=oners.Single(u => u.LastName == "Hess").OnerID},
                new Event{Title="Music Video Help", Description="Need help filming and producing a music video", 
                          OnerID=oners.Single(u => u.LastName == "Vargas").OnerID},
               
            };
            events.ForEach(s => context.Events.AddOrUpdate(s));
            context.SaveChanges();
        }
    }
}
