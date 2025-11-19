using Cinema_Info_Viewer.Models.DbMiracle;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinema_Info_Viewer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContentController : ControllerBase
{
    private readonly MiracleDbContext _context;

    public ContentController(MiracleDbContext context)
    {
        _context = context;
    }

    // GET: api/content
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Content>>> GetAll()
    {
        return await _context.Contents.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Content>> GetById(Guid id)
    {
        var content = await _context.Contents.FindAsync(id);

        if (content == null)
        {
            return NotFound();
        }

        return content;
    }

    // DELETE: api/content/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(string id)
    {
        var content = await _context.Contents.FindAsync(id);

        if(content == null)
        {
            return NotFound(); // 404
        }

        _context.Contents.Remove(content);
        await _context.SaveChangesAsync();

        return NoContent(); // 204
    }

    public async Task<Content> CreateContentAsync(Content model)
    {
        model.Id = Guid.NewGuid();
        model.CreatedAt = DateTime.UtcNow;

        _context.Contents.Add(model);
        await _context.SaveChangesAsync();

        return model;
    }

    public async Task<Content?> UpdateContentAsync(Guid id,Content updated)
    {
        var existing = await _context.Contents.FirstOrDefaultAsync(c => c.Id == id);
        if (existing == null)
            return null;

        existing.Title = updated.Title;
        existing.DistributorId = updated.DistributorId;
        existing.ReleaseDate = updated.ReleaseDate;
        existing.ContentFormat = updated.ContentFormat;
        existing.Duration = updated.Duration;
        existing.IsAdvanceReport = updated.IsAdvanceReport;
        existing.AudioLangs = updated.AudioLangs;
        existing.SubtitleLangs = updated.SubtitleLangs;
        existing.RatingId = updated.RatingId;

        await _context.SaveChangesAsync();

        return existing;
    }
}