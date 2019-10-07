using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    public class UserProfile
    {
        /// <summary>
        /// User Profile ID.
        /// </summary>
        [Key]
        public int UserProfileID { get; set; }
        
        /// <summary>
        /// Profile Name.
        /// </summary>
        public string ProfileName { get; set; }

        /// <summary>
        /// Profile Description.
        /// </summary>
        public string ProfileDescription { get; set; }

        /// <summary>
        /// Active Directory Group related.
        /// </summary>
        public string ProfileGroup { get; set; }
    }
}
