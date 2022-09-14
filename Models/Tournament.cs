using System.ComponentModel.DataAnnotations;

namespace GfcWebApi.Models
{
    public class Tournament
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Place { get; set; }

        public virtual List<Fight> Fights { get; set; }

        public int IsComplete { get; set; }

        public string PictureUrl { get; set; }

    }
}
