using UnityEngine;
using System.Collections;
using SQLite;
using System.Collections.Generic;

public class Dao{

	public static List<Level> Loadlevel () {
		List<Level> list;
		using (var db = new SQLiteConnection(Application.dataPath + "/db/level.sqlite"))
		{
			list = db.Query<Level>(
				"SELECT " +
				"  * " +
				"FROM level " +
				"WHERE id = (" +
				"SELECT MIN(Id) FROM level WHERE score is NULL)");
			db.Close();
		}
		return list;
	}
}
