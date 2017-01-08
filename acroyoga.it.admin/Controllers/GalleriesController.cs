using acroyoga.it.admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.OData;

namespace acroyoga.it.admin.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GalleriesController : ODataController
    {

        AcroyogaContext _ctx = new AcroyogaContext();

        [EnableQuery]
        public IHttpActionResult GetGalleries()
        {
            return Ok(_ctx.Galleries);
        }

        [EnableQuery]
        public IHttpActionResult GetGallery([FromODataUri]int key)
        {
            var model = _ctx.Galleries.FirstOrDefault(p => p.GalleryId == key);

            if (model != null)
                return Ok(model);
            else
                return NotFound();
        }       

        //public IHttpActionResult Post(Gallery model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _ctx.Galleries.Add(model);
        //    _ctx.SaveChanges();

        //    return Created(model);
        //}

        //public IHttpActionResult Put([FromODataUri] int key, Gallery model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var current = _ctx.Galleries.FirstOrDefault(p => p.GalleryId == key);
        //    if (current == null)
        //    {
        //        return NotFound();
        //    }

        //    model.GalleryId = current.GalleryId;

        //    _ctx.Entry(current).CurrentValues.SetValues(model);
        //    _ctx.SaveChanges();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //public IHttpActionResult Patch([FromODataUri] int key, Delta<Gallery> patch)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var current = _ctx.Galleries.FirstOrDefault(p => p.GalleryId == key);
        //    if (current == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(current);
        //    _ctx.SaveChanges();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //public IHttpActionResult Delete([FromODataUri] int key)
        //{
        //    var current = _ctx.Galleries.FirstOrDefault(p => p.GalleryId == key);
        //    if (current == null)
        //    {
        //        return NotFound();
        //    }

        //    _ctx.Galleries.Remove(current);
        //    _ctx.SaveChanges();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
            base.Dispose(disposing);
        }
    }
}