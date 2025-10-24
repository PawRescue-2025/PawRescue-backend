using System;
using System.Collections.Generic;

namespace PawRescue.Domain.Entities;

public partial class AspNetUser
{
    public string Id { get; set; } = null!;

    public string? UserName { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? Email { get; set; }

    public string? NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public bool LockoutEnabled { get; set; }

    public int AccessFailedCount { get; set; }

    public string FullName { get; set; } = null!;

    public string? Description { get; set; }

    public string Status { get; set; } = null!;

    public string? RefreshToken { get; set; }

    public DateTime RefreshTokenExpiryTime { get; set; }

    public DateTime RegistrationDate { get; set; }

    public DateTime? DeletionDate { get; set; }

    public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; } = new List<AspNetUserClaim>();

    public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; } = new List<AspNetUserLogin>();

    public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; } = new List<AspNetUserToken>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Complaint> ComplaintComplainants { get; set; } = new List<Complaint>();

    public virtual ICollection<Complaint> ComplaintUsers { get; set; } = new List<Complaint>();

    public virtual ICollection<Point> PointRecipients { get; set; } = new List<Point>();

    public virtual ICollection<Point> PointReviewers { get; set; } = new List<Point>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Shelter> Shelters { get; set; } = new List<Shelter>();

    public virtual ICollection<Verification> Verifications { get; set; } = new List<Verification>();

    public virtual ICollection<AspNetRole> Roles { get; set; } = new List<AspNetRole>();
}
