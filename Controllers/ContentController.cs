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
}