using DLG.Data;
using DLG.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace DLG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideController : ControllerBase
    {
        private readonly IMongoCollection<Guide>? _guides;
        public GuideController(MongoDbService mongoDbService)
        {
            _guides = mongoDbService.Database?.GetCollection<Guide>("guide");
        }

        [HttpGet]
        public async Task<IEnumerable<Guide>> Get()
        {
            return await _guides.Find(FilterDefinition<Guide>.Empty).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Guide?>> GetById(string id)
        {
            var filter = Builders<Guide>.Filter.Eq(x => x.Id, id);
            var guide = _guides.Find(filter).FirstOrDefault();
            return guide is not null ? Ok(guide) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Guide guide)
        {
            await _guides.InsertOneAsync(guide);
            return CreatedAtAction(nameof(GetById), new { id = guide.Id, guide });
        }

        [HttpPut]
        public async Task<ActionResult> Update(Guide guide)
        {
            var filter = Builders<Guide>.Filter.Eq(x => x.Id, guide.Id);
            // var update = Builders<Guide>.Update
            // .Set(x => x.GuideName, guide.Name)
            // .Set(x => x.GuideName, guide.DateOfBirth)
            // .Set(x => x.GuideName, guide.GuideName);
            // await _guides.UpdateOneAsync(filter, update);

            await _guides.ReplaceOneAsync(filter, guide);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var filter = Builders<Guide>.Filter.Eq(x => x.Id, id);
            await _guides.DeleteOneAsync(filter);
            return Ok();
        }
    }
}
