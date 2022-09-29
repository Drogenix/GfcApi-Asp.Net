using System.ComponentModel.DataAnnotations;

namespace GfcWebApi.Models
{
    public class Tournament
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        public string Place { get; set; }

        public virtual List<Fight> Fights { get; set; }

        public bool IsComplete { get; set; }

        public string PictureUrl { get; set; }

    }
}
