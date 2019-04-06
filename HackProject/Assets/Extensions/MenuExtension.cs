using System;
using UnityEditor;
using UnityEngine;

public class MenuExtension : MonoBehaviour {
	// GAMEOBJECT

	[MenuItem("GameObject/Toggle Hide _h")] // toggle hide
	private static void ToggleHideSelection() {
		if (!isInEditMode())
			return;
		GameObject[] selectedObjects = Selection.gameObjects;
		foreach (GameObject obj in selectedObjects) {
			Undo.RecordObject(obj, "Toggle Hide");
			obj.SetActive(!obj.activeSelf);
		}
	}

	[MenuItem("GameObject/Unhide all &h")] // unhide all
	private static void UnhideAll() {
		if (!isInEditMode())
			return;
		GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
		foreach (GameObject obj in allObjects) {
			Undo.RecordObject(obj, "Unhide all");
			obj.SetActive(true);
		}
	}

	[MenuItem("GameObject/Reset transform &r")] // reset transform
	private static void ResetTransform() {
		if (!isInEditMode())
			return;
		GameObject[] selectedObjects = Selection.gameObjects;
		foreach (GameObject obj in selectedObjects) {
			Undo.RecordObject(obj.transform, "Reset transform");
			obj.transform.position = Vector3.zero;
		}
	}


	[MenuItem("GameObject/Snap/To pivot #s")] // snap to pivot
	private static void SnapToPivot() {
		if (!isInEditMode())
			return;
		GameObject[] selectedObjects = Selection.gameObjects;
		foreach (GameObject obj in selectedObjects) {
			Undo.RecordObject(obj.transform, "Snap to pivot");
			obj.transform.position = SceneView.lastActiveSceneView.pivot;
		}
	}

	[MenuItem("GameObject/Snap/To grid &#s")] // snap to grid
	private static void SnapToGrid() {
		if (!isInEditMode())
			return;
		GameObject[] selectedObjects = Selection.gameObjects;
		foreach (GameObject obj in selectedObjects) {
			Undo.RecordObject(obj.transform, "Snap to grid");
			Vector3Int rounded = Vector3Int.RoundToInt(obj.transform.position);
			obj.transform.position = rounded;
		}
	}
	
	//TODO: snap object pivot to scene pivot

	// SCENE VIEW NAVIGATION

	[MenuItem("View/Switch Perspective _5")]
	private static void SwitchPerspective() {
		if (!isInEditMode())
			return;
		SceneView.lastActiveSceneView.orthographic = !SceneView.lastActiveSceneView.orthographic; //toggle

		SceneView.lastActiveSceneView.Repaint();
	}

	private static void rotateView(Quaternion rotation) {
		if (!isInEditMode())
			return;
		SceneView.lastActiveSceneView.LookAt(SceneView.lastActiveSceneView.pivot, rotation);

		SceneView.lastActiveSceneView.Repaint();
	}

	[MenuItem("View/Front _1")] // FRONT
	private static void FrontView() {
		if (!isInEditMode())
			return;
		rotateView(Quaternion.Euler(0, 180, 0));
	}

	[MenuItem("View/Back &1")] // BACK
	private static void BackView() {
		if (!isInEditMode())
			return;
		rotateView(Quaternion.Euler(0, 0, 0));
	}

	[MenuItem("View/Right _2")] // RIGHT
	private static void RightView() {
		if (!isInEditMode())
			return;
		rotateView(Quaternion.Euler(0, -90, 0));
	}

	[MenuItem("View/Left &2")] // LEFT
	private static void LeftView() {
		if (!isInEditMode())
			return;
		rotateView(Quaternion.Euler(0, 90, 0));
	}

	[MenuItem("View/Top _3")] // TOP
	private static void TopView() {
		if (!isInEditMode())
			return;
		rotateView(Quaternion.Euler(90, 0, 0));
	}

	[MenuItem("View/Bottom &3")] // BOTTOM
	private static void BottomView() {
		if (!isInEditMode())
			return;
		rotateView(Quaternion.Euler(-90, 0, 0));
	}

	private static bool isInEditMode() {
		return !Application.isPlaying;
	}
}