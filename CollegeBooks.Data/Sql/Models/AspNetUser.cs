// ---------------------------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by LinqToDB scaffolding tool (https://github.com/linq2db/linq2db).
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
// ---------------------------------------------------------------------------------------------------

using LinqToDB.Mapping;
using System;
using System.Collections.Generic;

#pragma warning disable 1573, 1591
#nullable enable

namespace DataModel
{
	[Table("AspNetUsers")]
	public class AspNetUser
	{
		[Column("Id"                  , CanBeNull = false, IsPrimaryKey = true)] public string          Id                   { get; set; } = null!; // nvarchar(450)
		[Column("UserName"                                                    )] public string?         UserName             { get; set; } // nvarchar(256)
		[Column("NormalizedUserName"                                          )] public string?         NormalizedUserName   { get; set; } // nvarchar(256)
		[Column("Email"                                                       )] public string?         Email                { get; set; } // nvarchar(256)
		[Column("NormalizedEmail"                                             )] public string?         NormalizedEmail      { get; set; } // nvarchar(256)
		[Column("EmailConfirmed"                                              )] public bool            EmailConfirmed       { get; set; } // bit
		[Column("PasswordHash"                                                )] public string?         PasswordHash         { get; set; } // nvarchar(max)
		[Column("SecurityStamp"                                               )] public string?         SecurityStamp        { get; set; } // nvarchar(max)
		[Column("ConcurrencyStamp"                                            )] public string?         ConcurrencyStamp     { get; set; } // nvarchar(max)
		[Column("PhoneNumber"                                                 )] public string?         PhoneNumber          { get; set; } // nvarchar(max)
		[Column("PhoneNumberConfirmed"                                        )] public bool            PhoneNumberConfirmed { get; set; } // bit
		[Column("TwoFactorEnabled"                                            )] public bool            TwoFactorEnabled     { get; set; } // bit
		[Column("LockoutEnd"                                                  )] public DateTimeOffset? LockoutEnd           { get; set; } // datetimeoffset(7)
		[Column("LockoutEnabled"                                              )] public bool            LockoutEnabled       { get; set; } // bit
		[Column("AccessFailedCount"                                           )] public int             AccessFailedCount    { get; set; } // int

		#region Associations
		/// <summary>
		/// FK_AspNetUserClaims_AspNetUsers_UserId backreference
		/// </summary>
		[Association(ThisKey = nameof(Id), OtherKey = nameof(AspNetUserClaim.UserId))]
		public IEnumerable<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;

		/// <summary>
		/// FK_AspNetUserLogins_AspNetUsers_UserId backreference
		/// </summary>
		[Association(ThisKey = nameof(Id), OtherKey = nameof(AspNetUserLogin.UserId))]
		public IEnumerable<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;

		/// <summary>
		/// FK_AspNetUserRoles_AspNetUsers_UserId backreference
		/// </summary>
		[Association(ThisKey = nameof(Id), OtherKey = nameof(AspNetUserRole.UserId))]
		public IEnumerable<AspNetUserRole> AspNetUserRoles { get; set; } = null!;

		/// <summary>
		/// FK_AspNetUserTokens_AspNetUsers_UserId backreference
		/// </summary>
		[Association(ThisKey = nameof(Id), OtherKey = nameof(AspNetUserToken.UserId))]
		public IEnumerable<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
		#endregion
	}
}
