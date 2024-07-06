﻿namespace GymManagerApplication.Entities
{
    public class GymManager
    {
        public required int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public GymManagerContact Contact { get; set; } = default!;
        
    }
}
