using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Models
{
    public class Friendship
    {
        [Key]
        [Required]
        public virtual int Id { get; set; }

        [ForeignKey("RequestedBy")]
        public virtual int? RequestedBy_Id { get; set; }

        public virtual User RequestedBy { get; set; }

        [Required]
        public virtual User RequestedTo { get; set; }

        [Required]
        public DateTime? RequestTime { get; set; }

        [Required]
        public FriendRequestFlag FriendRequestFlag { get; set; }
    }

    public enum FriendRequestFlag
    {
        None,
        Approved,
        Rejected
    };
}