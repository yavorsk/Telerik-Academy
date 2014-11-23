using Catalogue.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Catalogue.Services.Models
{
    public class SongModel
    {
        public static Expression<Func<Song, SongModel>> FromSong
        {
            get
            {
                return s => new SongModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    Year = s.Year,
                    Genre = s.Genre,
                    Artist = s.Artist.Name,
                    Album = s.Album.Title
                };
            }
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public string Artist { get; set; }

        public string Album { get; set; }
    }
}