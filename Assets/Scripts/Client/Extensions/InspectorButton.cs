using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TileData))]
public class InspectorButton : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		TileData tileData = (TileData)target;

		if (GUILayout.Button("Set Data"))
		{
			tileData.SetData();
		}
	}
}