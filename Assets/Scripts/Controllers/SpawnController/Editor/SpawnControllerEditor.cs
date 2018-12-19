using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpawnController))]
public class SpawnControllerEditor : Editor
{
	SpawnController db;

	bool edit;
	int _i;

	//Ao abrir o editor
	void OnEnable ()
	{
		edit = false;
		db = (SpawnController)target;
	}

	//No editor
	public override void OnInspectorGUI ()
	{
		//base.OnInspectorGUI ();

		GUILayout.BeginVertical("HelpBox");

		if (edit)
			configMenu ();
		else
			mainMenu ();

		GUILayout.EndVertical ();

		serializedObject.Update();
		serializedObject.ApplyModifiedProperties();
	}

	void configMenu ()
	{
		GUILayout.Label("Configure "+db.spawnObjects[_i].name);

		db.spawnObjects[_i].name = EditorGUILayout.TextField ("Name", db.spawnObjects[_i].name);

		db.spawnObjects [_i].prefab = (GameObject)EditorGUILayout.ObjectField (new GUIContent("Prefab"), 
			db.spawnObjects [_i].prefab, typeof(GameObject), false);
		
		db.spawnObjects [_i].proceduralWaves = EditorGUILayout.Toggle ("Procedural Wave", db.spawnObjects [_i].proceduralWaves);

		if (db.spawnObjects [_i].proceduralWaves) 
		{
			GUILayout.BeginVertical ("GroupBox");

				db.spawnObjects [_i].spawnWave.frequency = EditorGUILayout.Slider ("Frequency", 
					db.spawnObjects [_i].spawnWave.frequency, 0f, 100f);
				
				EditorGUILayout.CurveField ("Procedural Wave", new AnimationCurve(db.spawnObjects [_i].spawnWave.decayFunction.keys));

				db.spawnObjects [_i].spawnWave.waveDuration = EditorGUILayout.Slider ("Wave Duration", 
					db.spawnObjects [_i].spawnWave.waveDuration, 0f, 360f);

			GUILayout.EndVertical ();
		}
		else 
		{
			GUILayout.BeginVertical ("HelpBox");

			GUILayout.Label ("Waves");

				for (int _j = 0; _j < db.spawnObjects [_i].spawnWaves.Count; _j++) 
				{
					GUILayout.BeginHorizontal();
						GUILayout.BeginVertical("GroupBox");

							db.spawnObjects [_i].spawnWaves[_j].frequency = EditorGUILayout.Slider ("Frequency", 
								db.spawnObjects [_i].spawnWaves[_j].frequency, 0f, 100f);

							EditorGUILayout.CurveField ("Curve", db.spawnObjects [_i].spawnWaves [_j].decayFunction);

							db.spawnObjects [_i].spawnWaves [_j].waveDuration = EditorGUILayout.FloatField ("Wave Duration (s)", 
								db.spawnObjects [_i].spawnWaves [_j].waveDuration);

							EditorGUILayout.FloatField ("Delay to next Wave (s)", 3f);

						GUILayout.EndVertical ();
					GUILayout.EndHorizontal ();
				}

				GUILayout.BeginHorizontal ();
					if (GUILayout.Button ("New")) 
					{
						newWave ();
					}
					if (GUILayout.Button ("Remove")) 
					{
						removeWave ();
					}
				GUILayout.EndHorizontal ();

			GUILayout.EndVertical ();

		}

		if (GUILayout.Button ("Return"))
			edit = false;
	}

	void mainMenu ()
	{
		GUILayout.Label("Spawn Objects");

		for (int i = 0; i < db.spawnObjects.Count; i++)
		{
			SpawnObject obj = db.spawnObjects[i];
			GUILayout.BeginHorizontal();
			GUILayout.BeginVertical("GroupBox");

			GUILayout.Label (obj.name);
			EditorGUILayout.ObjectField (obj.prefab, typeof(GameObject), false);

			if (GUILayout.Button("Configure"))
			{
				edit = true;
				_i = i;
			}

			GUILayout.EndVertical ();
			GUILayout.EndHorizontal ();
		}

		GUILayout.BeginHorizontal ();
		if (GUILayout.Button ("New")) 
		{
			newObject ();
		}
		if (GUILayout.Button ("Remove")) 
		{
			removeObject ();
		}
		GUILayout.EndHorizontal ();
	}

	void newObject ()
	{
		db.spawnObjects.Add (new SpawnObject ());
	}

	void removeObject ()
	{
		if(db.spawnObjects.Count != 0)
			db.spawnObjects.RemoveAt (db.spawnObjects.Count -1);
	}

	void newWave ()
	{
		db.spawnObjects[_i].spawnWaves.Add (new SpawnWave());
	}

	void removeWave ()
	{
		if(db.spawnObjects[_i].spawnWaves.Count != 0)
			db.spawnObjects[_i].spawnWaves.RemoveAt (db.spawnObjects[_i].spawnWaves.Count -1);
	}
}
