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
    public class EventsController : ODataController
    {

        AcroyogaContext _ctx = new AcroyogaContext();

        [EnableQuery]
        public IHttpActionResult GetEvents()
        {
            return Ok(_ctx.Events);
        }

        public IHttpActionResult GetYear([FromODataUri]int key)
        {
            var model = _ctx.Events.FirstOrDefault(p => p.Id == key);

            if (model != null)
                return Ok(model);
            else
                return NotFound();
        }       

        public IHttpActionResult Post(Event model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _ctx.Events.Add(model);
            _ctx.SaveChanges();

            return Created(model);
        }

        public IHttpActionResult Put([FromODataUri] int key, Event model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var current = _ctx.Events.FirstOrDefault(p => p.Id == key);
            if (current == null)
            {
                return NotFound();
            }

            model.Id = current.Id;

            _ctx.Entry(current).CurrentValues.SetValues(model);
            _ctx.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Patch([FromODataUri] int key, Delta<Event> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var current = _ctx.Events.FirstOrDefault(p => p.Id == key);
            if (current == null)
            {
                return NotFound();
            }

            patch.Patch(current);
            _ctx.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Delete([FromODataUri] int key)
        {
            var current = _ctx.Events.FirstOrDefault(p => p.Id == key);
            if (current == null)
            {
                return NotFound();
            }

            _ctx.Events.Remove(current);
            _ctx.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
            base.Dispose(disposing);
        }
    }
}