using Microsoft.AspNetCore.Mvc;
using OVS.Database;
using System.Threading.Tasks;

public class VoteController : Controller
{
    private readonly SQLiteDBContext _context;

    public VoteController(SQLiteDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Vote()
    {
        return View(new Vote());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SubmitVotes(Vote vote)
    {
        if (ModelState.IsValid)
        {
            _context.Votes.Add(vote);
            await _context.SaveChangesAsync();
            return RedirectToAction("VoteConfirmation");
        }
        return View("Vote", vote);
    }

    public IActionResult VoteConfirmation()
    {
        return View();
    }
}
