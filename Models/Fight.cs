using System.ComponentModel.DataAnnotations;

namespace GfcWebApi.Models
{
    public class Fight
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int TournamentId { get; set; }

        public string Card { get; set; }

        public bool IsTitleFight { get; set; }

        public int FirstFighterId { get; set; }

        public virtual Fighter FirstFighter { get; set; }

        public int SecondFighterId { get; set; }

        public virtual Fighter SecondFighter { get; set; }

        public int WinnerNum { get; set; }

        public string WinReason { get; set; }

        public int Round { get; set; }

        public int FirstEndRating { get; set; }

        public int SecondEndRating { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
