﻿namespace guitarapi.Models
{
    public class GuitarType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Guitar> Guitars { get; set; }
    }
}
