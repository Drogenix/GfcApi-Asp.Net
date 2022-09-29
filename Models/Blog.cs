using System.ComponentModel.DataAnnotations;

namespace Gfc.Models
{
    public class Blog
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortInfo { get; set; }

        public string TextDocUrl { get; set; }

        public string PictureUrl { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Published { get; set; }

    }
}
