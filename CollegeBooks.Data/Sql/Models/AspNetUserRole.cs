// ---------------------------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by LinqToDB scaffolding tool (https://github.com/linq2db/linq2db).
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
// ---------------------------------------------------------------------------------------------------

using LinqToDB.Mapping;

#pragma warning disable 1573, 1591
#nullable enable

namespace DataModel
{
	[Table("AspNetUserRoles")]
	public class AspNetUserRole
	{
		[Column("UserId", CanBeNull = false, IsPrimaryKey = true, PrimaryKeyOrder = 0)] public string UserId { get; set; } = null!; // nvarchar(450)
		[Column("RoleId", CanBeNull = false, IsPrimaryKey = true, PrimaryKeyOrder = 1)] public string RoleId { get; set; } = null!; // nvarchar(450)

		#region Associations
		/// <summary>
		/// FK_AspNetUserRoles_AspNetRoles_RoleId
		/// </summary>
		[Association(CanBeNull = false, ThisKey = nameof(RoleId), OtherKey = nameof(AspNetRole.Id))]
		public AspNetRole AspNetRolesRoleId { get; set; } = null!;

		/// <summary>
		/// FK_AspNetUserRoles_AspNetUsers_UserId
		/// </summary>
		[Association(CanBeNull = false, ThisKey = nameof(UserId), OtherKey = nameof(AspNetUser.Id))]
		public AspNetUser AspNetUsersUserId { get; set; } = null!;
		#endregion
	}
}