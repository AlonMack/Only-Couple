using UnityEngine;
using System.Collections;
using SQLite;

public class Level
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string Config { get; set; }
	public int Score { get; set; }
}
