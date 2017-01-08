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
    public class PicturesController : ODataController
    {

        AcroyogaContext _ctx = new AcroyogaContext();

        [EnableQuery]
        public IHttpActionResult GetPictures()
        {
            return Ok(_ctx.Pictures);
        }

        [EnableQuery]
        public IHttpActionResult GetPicture([FromODataUri]int key)
        {
            var model = _ctx.Pictures.FirstOrDefault(p => p.PictureId == key);

            if (model != null)
                return Ok(model);
            else
                return NotFound();
        }       

        //public IHttpActionResult Post(Picture model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _ctx.Pictures.Add(model);
        //    _ctx.SaveChanges();

        //    return Created(model);
        //}

        //public IHttpActionResult Put([FromODataUri] int key, Picture model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var current = _ctx.Pictures.FirstOrDefault(p => p.PictureId == key);
        //    if (current == null)
        //    {
        //        return NotFound();
        //    }

        //    model.PictureId = current.PictureId;

        //    _ctx.Entry(current).CurrentValues.SetValues(model);
        //    _ctx.SaveChanges();

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //public IHttpActionResult Patch([FromODataUri] int key, Delta<Picture> patch)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var current = _ctx.Pictures.FirstOrDefault(p => p.PictureId == key);
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
        //    var current = _ctx.Pictures.FirstOrDefault(p => p.PictureId == key);
        //    if (current == null)
        //    {
        //        return NotFound();
        //    }

        //    _ctx.Pictures.Remove(current);
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