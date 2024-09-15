using AppDb.Models;
using AppDbApi.Models;
using AppDbApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppDbApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticleController : ControllerBase
{
    private readonly ArticleService _ArticleService;

    public ArticleController(ArticleService articleService) =>
        _ArticleService = articleService;

    [HttpGet]
    public async Task<List<Article>> Get() =>
        await _ArticleService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Article>> Get(string id)
    {
        var article = await _ArticleService.GetAsync(id);

        if (article is null)
        {
            return NotFound();
        }

        return article;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Article newArticle)
    {
        await _ArticleService.CreateAsync(newArticle);

        return CreatedAtAction(nameof(Get), new { id = newArticle._id }, newArticle);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Article updatedArticle)
    {
        var article = await _ArticleService.GetAsync(id);

        if (article is null)
        {
            return NotFound();
        }

        updatedArticle._id = article._id;

        await _ArticleService.UpdateAsync(id, updatedArticle);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var article = await _ArticleService.GetAsync(id);

        if (article is null)
        {
            return NotFound();
        }

        await _ArticleService.RemoveAsync(id);

        return NoContent();
    }
}