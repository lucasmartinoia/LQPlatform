using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    public class UIChannel
    {
     [Key]
      public string localvalue { get; set; }
      public string externalvalue { get; set; }
    }
}
