// ---------------------------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by LinqToDB scaffolding tool (https://github.com/linq2db/linq2db).
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
// ---------------------------------------------------------------------------------------------------

using LinqToDB.Mapping;
using System;

#pragma warning disable 1573, 1591
#nullable enable

namespace DataModel
{
	[Table("Book")]
	public class Book
	{
		[Column("Id"       , IsPrimaryKey = true , IsIdentity = true, SkipOnInsert = true, SkipOnUpdate = true)] public int      Id        { get; set; } // int
		[Column("Title"    , CanBeNull    = false                                                             )] public string   Title     { get; set; } = null!; // varchar(50)
		[Column("CreatedAt"                                                                                   )] public DateTime CreatedAt { get; set; } // datetime2(7)
		[Column("UpdatedAt"                                                                                   )] public DateTime UpdatedAt { get; set; } // datetime2(7)
	}
}
