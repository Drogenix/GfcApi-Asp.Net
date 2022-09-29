using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GfcWebApi.Models
{
    public class Fighter
    {
        public int Id { get; set; }
        public string Sex { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Nickname { get; set; }
        public string Weight { get; set; }
        public int PfpRating { get; set; }
        public int Rating { get; set; }
        public int Win { get; set; }
        public int Lose { get; set; }
        public int Draw { get; set; }
        public int Winstreak { get; set; }
        public int Byknockout { get; set; }
        public int FirstRoundWins { get; set; }
        public int TotalHits { get; set; }
        public int AccurateHits { get; set; }
        public int TotalTakedowns { get; set; }
        public int AccurateTakedowns { get; set; }
        public int WinByKoTko { get; set; }
        public int WInByDecision { get; set; }
        public int WinBySubmission { get; set; }
        public string PictureUrl { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
