using OnoWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnoWeb.DAL
{
    public class OnoInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<OnoContext>
    {
        protected override void Seed(OnoContext context)
        {
            var oners = new List<Oner>
            {
                new Oner{LastName="Carson",FirstName="Alexander",Email="carsAlex@live.com", Skill="Photographer", Password="driveHonda240", Address="137 Olive st", Phone= "541-222-2222"},
                new Oner{LastName="Hess",FirstName="Nate",Email="curlymustache@gmail.com", Skill="Graphic Design", Password="100klife", Address="9875 Ice Lake Dr", Phone= "606-852-5555"},
                new Oner{LastName="Vargas",FirstName="Irvin",Email="vargasirvin@live.com", Skill="Videographer", Password="12iv0507zmz", Address="499 49th st", Phone= "541-555-5555"}
            };
            oners.ForEach(s => context.Oners.Add(s));
            context.SaveChanges();

            var albums = new List<Album>
            {
                new Album{Title="Project"},
                new Album{Title="Euro Style"},
                new Album{Title="Fortunes"}
               
            };
            albums.ForEach(s => context.Albums.Add(s));
            context.SaveChanges();

            var photos = new List<Photo>
            {
                new Photo{Name="Convertible Cruising", PhotoFile="~/Images/bmwE30.jpg", AlbumID=1, OnerID=1},
                new Photo{Name="Guitar Free Lens", PhotoFile="~/Images/guitarAnamorphic.jpg", AlbumID=2, OnerID=2},
                new Photo{Name="VW Scirocco Mk2", PhotoFile="~/Images/sciroccomk2.jpg", AlbumID=3, OnerID=3}

               
            };
            photos.ForEach(s => context.Photos.Add(s));
            context.SaveChanges();

            var genres = new List<Genre>
            {
                new Genre{GenreName="Action", Description="Fast pace with a lot of movement and keeps the audience eyes moving" },
                new Genre{GenreName="Comedy", Description="Humorous, funny, and easy to watch" },
                new Genre{GenreName="Horror", Description="Violence and brutality" }
               
            };
            genres.ForEach(s => context.Genres.Add(s));
            context.SaveChanges();

            var videos = new List<Video>
            {
                new Video{Title="Scorched in Fire", GenreID=1, OnerID=1},
                new Video{Title="Homework", GenreID=2, OnerID=2},
                new Video{Title="Metal", GenreID=3, OnerID=3},

               
            };
            videos.ForEach(s => context.Videos.Add(s));
            context.SaveChanges();


            var events = new List<Event>
            {
                new Event{Title="Video Premiere", Description="Premiere of my first short film", 
                          /*EventDateTime=DateTime.Parse("2015-04-15"), */ OnerID=1 },
                new Event{Title="Photo Gallery", Description="My friend is having a gallery show!", 
                         /* EventDateTime=DateTime.Parse("2015-10-22"),*/ OnerID=2 },
                new Event{Title="Music Video Help", Description="Need help filming and producing a music video", 
                          /*EventDateTime=DateTime.Parse("2015-02-29"),*/ OnerID=3 }
               
            };
            events.ForEach(s => context.Events.Add(s));
            context.SaveChanges();

        }
    }
}
