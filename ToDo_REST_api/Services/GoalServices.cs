using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using ToDo_REST_api.AppDb;
using ToDo_REST_api.Models;

namespace ToDo_REST_api.Services {
    public class GoalServices {

        private AppDbContext _context;
        public GoalServices(AppDbContext context) {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<Goal>>> ListGoals() {
            List<Goal> goals = new List<Goal>();
            var result = await _context.Goals.Include(g => g.Category).ToListAsync();
            foreach (var g in result) {
                var temp = g.ExecuteDate;
                string jsonDate = JsonSerializer.Serialize(temp);
            }
            return result;
        }
    }
}
