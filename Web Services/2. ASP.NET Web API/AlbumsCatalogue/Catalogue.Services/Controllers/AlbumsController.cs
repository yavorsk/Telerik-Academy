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
    public class AlbumsController : ApiController
    {
        private ICatalogueData data;

        public AlbumsController()
            : this(new CatalogueData())
        {
        }

        public AlbumsController(ICatalogueData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var albums = this.data.Albums.All();

            return Ok(albums);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var album = this.data.Albums.All()
                .Where(a => a.Id == id)
                .FirstOrDefault();

            if (album == null)
            {
                return BadRequest("Artist with such id doesn not exist.");
            }

            return Ok(album);
        }

        [HttpPost]
        public IHttpActionResult Create(Album album)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.data.Albums.Add(album);
            this.data.SaveChanges();

            return Ok(album);
        }

        [HttpPut]
        public IHttpActionResult UpdateProducer(int id, Album album)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAlbum = this.data.Albums.All()
                .Where(a => a.Id == id)
                .FirstOrDefault();
            if (existingAlbum == null)
            {
                return BadRequest("Artist with such id does not exist.");
            }

            existingAlbum.Producer = album.Producer;
            this.data.SaveChanges();

            album.Id = id;
            return Ok(album);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingAlbum = this.data.Albums.All()
                .Where(a => a.Id == id)
                .FirstOrDefault();
            if (existingAlbum == null)
            {
                return BadRequest("Artist with such id does not exist.");
            }

            this.data.Albums.Delete(existingAlbum);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
