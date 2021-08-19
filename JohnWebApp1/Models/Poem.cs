using System;

namespace JohnWebApp1.Models
{
    public class Poem
    {

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string PeomTitle { get; set; }
        public string peom { get; set; }

    }
}
