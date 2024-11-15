using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OVS.Database;

public class AccountController : Controller
{
    private readonly SQLiteDBContext _context;
    private readonly PasswordHasher<User> _passwordHasher;

    public AccountController(SQLiteDBContext context)
    {
        _context = context;
        _passwordHasher = new PasswordHasher<User>();
    }

    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(User user)
    {
        if (ModelState.IsValid)
        {
            user.Password = _passwordHasher.HashPassword(user, user.Password);
            user.IsRegistered = true;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        return View(user);
    }

    public IActionResult Login() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(User user)
    {
        if (ModelState.IsValid)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == user.Username);
            if (existingUser != null && _passwordHasher.VerifyHashedPassword(existingUser, existingUser.Password, user.Password) != PasswordVerificationResult.Failed)
            {
                // Ideally, set user session or authentication token here
                // For now, redirect to Vote
                return RedirectToAction("Vote", "Vote");
            }
            ModelState.AddModelError("", "Invalid username or password.");
        }
        return View(user);
    }
}
