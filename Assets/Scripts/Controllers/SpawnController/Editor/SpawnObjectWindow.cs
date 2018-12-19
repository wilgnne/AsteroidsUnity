using UnityEngine;
using UnityEditor;

public class SpawnObjectWindow : EditorWindow 
{
	[MenuItem("SpawnController/Spawnable Object")]
	public static void ShowWindow ()
	{
		GetWindow<SpawnObjectWindow>("Spawnable Object");
	}

	void OnGUI ()
	{
		if(Selection.gameObjects.Length == 1 && Selection.gameObjects[0].GetComponent<SpawnController>())
		{
			SpawnController spawnController = Selection.gameObjects[0].GetComponent<SpawnController>();

			foreach(SpawnObject sb in spawnController.spawnObjects)
			{
				EditorGUILayout.CurveField(sb.name, sb.spawnWave.decayFunction);
			}
		}
		else
		{
			EditorGUILayout.LabelField("Selecione um SpawnController");
		}
	}
}
