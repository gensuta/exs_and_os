using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(StateHandler))]
public class StateEditor : Editor
{
	StateHandler sh;
	public override void OnInspectorGUI()
	{
		sh = (StateHandler)target;
		DrawDefaultInspector();

		if (GUILayout.Button("GameStart"))
		{
			sh.InitiateBattle();
			sh.StartTicTacToe();
		}

		if (GUILayout.Button("StartFour"))
		{
			sh.StartConnectFour();
		}
	}
}
