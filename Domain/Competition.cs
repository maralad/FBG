using System;

namespace Domain
{
    public class Competition
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Game { get; set; }
        public string Charity { get; set; }
        public string Owner { get; set; }

    }
}