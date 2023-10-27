using System;
using System.Text.Json.Serialization;

namespace ToDo_REST_api.Models {
    public class Goal {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ExecuteDate { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
