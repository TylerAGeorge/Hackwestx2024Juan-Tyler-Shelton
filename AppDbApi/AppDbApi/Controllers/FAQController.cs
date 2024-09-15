using AppDbApi.Models;
using AppDbApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppDbApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FAQController : ControllerBase
{
    private readonly FAQService _FAQService;

    public FAQController(FAQService fAQService) =>
        _FAQService = fAQService;

    [HttpGet]
    public async Task<List<FAQ>> Get() =>
        await _FAQService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<FAQ>> Get(string id)
    {
        var faq = await _FAQService.GetAsync(id);

        if (faq is null)
        {
            return NotFound();
        }

        return faq;
    }

    [HttpPost]
    public async Task<IActionResult> Post(FAQ newFAQ)
    {
        await _FAQService.CreateAsync(newFAQ);

        return CreatedAtAction(nameof(Get), new { id = newFAQ._id }, newFAQ);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, FAQ updatedFAQ)
    {
        var faq = await _FAQService.GetAsync(id);

        if (faq is null)
        {
            return NotFound();
        }

        updatedFAQ._id = faq._id;

        await _FAQService.UpdateAsync(id, updatedFAQ);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var faq = await _FAQService.GetAsync(id);

        if (faq is null)
        {
            return NotFound();
        }

        await _FAQService.RemoveAsync(id);

        return NoContent();
    }
}