using System;
using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    public class UserAccess
    {
        /// <summary>
        /// UserAccessID.
        /// </summary>
        [Key]
        public int UserAccessID { get; set; }

        /// <summary>
        /// UserID.
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// User display name.
        /// </summary>
        public string UserDisplayName { get; set; }

        /// <summary>
        /// User IP
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Active Directory Groups related to user.
        /// </summary>
        public string ProfileGroups { get; set; }

        /// <summary>
        /// Last date and time user access.
        /// </summary>
        public DateTime LastAccess { get; set; }
        public static void Save(UserAccess userAccess)
        {
            using (var db = new DBContext())
            {
                db.UserAccesses.Add(userAccess);
                db.SaveChanges();
            }
        }
        public static void Update(UserAccess userAccess)
        {
            using (var db = new DBContext())
            {
                db.UserAccesses.Attach(userAccess);
                db.Entry(userAccess).Property(x => x.LastAccess).IsModified = true;
                db.SaveChanges();
            }
        }
    }
}
