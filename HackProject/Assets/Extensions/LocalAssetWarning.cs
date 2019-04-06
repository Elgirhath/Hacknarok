using UnityEngine;
using UnityEditor;
using System.Linq;

public class LocalAssetWarning : MonoBehaviour {
	
	[MenuItem("Assets/Find Local References", false, 10000)]
	static void FindLocalReferences() {
		Object[] allObjects = Object.FindObjectsOfType<GameObject>();
		foreach (Object obj in allObjects) {
			Object[] objArr = new Object[1];
			objArr[0] = obj;
			FindReference(objArr);
		}
	}

	static void FindReference(Object[] objects) {
		Object[] dependencies = EditorUtility.CollectDependencies(objects);
		foreach (var var in dependencies) {
			string path = AssetDatabase.GetAssetPath(var);
			string[] splited = path.Split('/');
			if (splited.Contains("_local")) {
				Debug.LogWarning("Reference to a _local asset: " + path + "\n" + objects[0].name, objects[0]);
			}
		}
	}
}