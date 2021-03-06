using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Przepisy_kulinarne_projekt.Data;
using Przepisy_kulinarne_projekt.Models;

namespace Przepisy_kulinarne_projekt.Pages.AddAFav
{
    public class DeleteModel : PageModel
    {
        private readonly Przepisy_kulinarne_projekt.Data.ApplicationDbContext _context;

        public DeleteModel(Przepisy_kulinarne_projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FavRecipePerson FavRecipePerson { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FavRecipePerson = await _context.FavRecipes
                .Include(f => f.Person)
                .Include(f => f.Recipe).FirstOrDefaultAsync(m => m.Id == id);

            if (FavRecipePerson == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FavRecipePerson = await _context.FavRecipes.FindAsync(id);

            if (FavRecipePerson != null)
            {
                _context.FavRecipes.Remove(FavRecipePerson);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/AddARecipe/Index");
        }
    }
}
