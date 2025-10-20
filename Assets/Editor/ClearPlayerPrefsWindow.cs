using UnityEditor;
using UnityEngine;

public static class ClearPlayerPrefsMenu
{
	[MenuItem("Window/Delete all PlayerPrefs")] 
	public static void Clear()
	{
		PlayerPrefs.DeleteAll();
		PlayerPrefs.Save();
		Debug.Log("PlayerPrefs Deleted");
	}
}


