using api.Data;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class testQController : ControllerBase
    {
        private readonly MongoDBContext _context;

        public testQController(MongoDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<testQ>> Get()
        {
            return await _context.testQ.Find(_ => true).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<testQ>> Get(string id)
        {
            var testQ = await _context.testQ.Find(t => t.Id == id).FirstOrDefaultAsync();

            if(testQ == null)
            {
                return NotFound();
            }

            return testQ;
        }

        [HttpPost]
        public async Task<ActionResult<testQ>> Create(testQ t)
        {
            await _context.testQ.InsertOneAsync(t);
            return CreatedAtRoute(new { id = t.Id }, t);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, testQ t)
        {
            var testQ = await _context.testQ.Find(t => t.Id == id).FirstOrDefaultAsync();
            if(testQ == null)
            {
                return NotFound();
            }

            await _context.testQ.ReplaceOneAsync(t => t.Id == id, t);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var testQ = await _context.testQ.Find(t => t.Id==id).FirstOrDefaultAsync();
            if (testQ == null)
            {
                return NotFound();
            }

            await _context.testQ.DeleteOneAsync(t => t.Id == id);

            return NoContent();
        }
    }
}
