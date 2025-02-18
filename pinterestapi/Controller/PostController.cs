using Microsoft.AspNetCore.Mvc;
using pinterestapi.Model;
using pinterestapi.Service.PostService;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Components.Web;
using pinterestapi.DataContext;

namespace pinterestapi.Controller;

[Route("api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostInterface _postInterface;
    private readonly ApplicationDbContext _context;
    
    public PostController(IPostInterface postInterface, ApplicationDbContext context)
    {
        _postInterface = postInterface;
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetImagem(Guid id)
    {
        var response = await _postInterface.GetPostAsync(id);
        if (!response.Success || string.IsNullOrEmpty(response.Data?.ImageBase64))
        {
            return NotFound("Post ou imagem não encontrados.");
        }
        byte[] imageBytes = Convert.FromBase64String(response.Data.ImageBase64);
        string extension = response.Data.FileExtension.Replace(".", "").ToLower();
        return File(imageBytes, "image/" + extension);
    }

    [HttpPost]
    public async Task<ActionResult<PostModel>> PostAsync([FromForm] string title, [FromForm] IFormFile? imageFile)
    {
        if (imageFile == null || imageFile.Length == 0)
        {
            return BadRequest("Image File Invalid");
        }

        using var memoryStream = new MemoryStream();
        await imageFile.CopyToAsync(memoryStream);
        string base64Image = Convert.ToBase64String(memoryStream.ToArray());

        var post = new PostModel
        {
            Title = title,
            ImageBase64 = base64Image,
            FileName = Path.GetFileName(imageFile.FileName),
            FileExtension =  Path.GetExtension(imageFile.FileName)
        };

        var response = await _postInterface.PostAsync(post);
        return response.Success ? Ok(response) : BadRequest(response);
    }
}