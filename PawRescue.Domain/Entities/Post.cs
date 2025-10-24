using System;
using System.Collections.Generic;

namespace PawRescue.Domain.Entities;

public partial class Post
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string PostType { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public string Status { get; set; } = null!;

    public bool? IsHelpRequestCompleted { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? DeletionDate { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();

    public virtual AspNetUser User { get; set; } = null!;
}
