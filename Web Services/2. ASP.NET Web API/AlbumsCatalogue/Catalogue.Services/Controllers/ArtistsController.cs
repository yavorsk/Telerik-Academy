using Catalogue.Dataa;
using Catalogue.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Catalogue.Services.Controllers
{
    public class ArtistsController : ApiController
    {
        private ICatalogueData data;

        public ArtistsController()
            : this(new CatalogueData())
        {
        }

        public ArtistsController(ICatalogueData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var artists = this.data.Artists.All();

            return Ok(artists);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var artist = this.data.Artists.All()
                .Where(a => a.Id == id)
                .FirstOrDefault();

            if (artist == null)
            {
                return BadRequest("Artist with such id doesn not exist.");
            }

            return Ok(artist);
        }

        [HttpPost]
        public IHttpActionResult Create(Artist artist)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.data.Artists.Add(artist);
            this.data.SaveChanges();

            return Ok(artist);
        }

        [HttpPut]
        public IHttpActionResult UpdateCountry(int id, Artist artist)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingArtist = this.data.Artists.All()
                .Where(a => a.Id == id)
                .FirstOrDefault();
            if (existingArtist == null)
            {
                return BadRequest("Artist with such id does not exist.");
            }

            existingArtist.Country = artist.Country;
            this.data.SaveChanges();

            artist.Id = id;
            return Ok(artist);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingArtist = this.data.Artists.All()
                .Where(a => a.Id == id)
                .FirstOrDefault();
            if (existingArtist == null)
            {
                return BadRequest("Artist with such id does not exist.");
            }

            this.data.Artists.Delete(existingArtist);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddAlbumById(int artistId, int albumId)
        {
            var existingArtist = this.data.Artists.All()
                .Where(a => a.Id == artistId)
                .FirstOrDefault();
            if (existingArtist == null)
            {
                return BadRequest("Artist with such id does not exist.");
            }

            var existingAlbum = this.data.Albums.All()
                .Where(a => a.Id == albumId)
                .FirstOrDefault();
            if (existingAlbum == null)
            {
                return BadRequest("Album with such id does not exist.");
            }

            existingArtist.Albums.Add(existingAlbum);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
