using UnityEditor;
using UnityEngine;

public class ExportAssetBundles {
	[MenuItem("Assets/Build AssetBundle From Selection - Track dependencies")]
	static void ExportResource() {
		string path = EditorUtility.SaveFilePanel ("Save Resource", "", "New Resource", "unity3d");
		if (path.Length != 0) {
			Object[] selection = Selection.GetFiltered (typeof(Object), SelectionMode.DeepAssets);

			BuildPipeline.BuildAssetBundle(Selection.activeObject, selection, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.Android | BuildTarget.iOS);
			Selection.objects = selection;
		}
	}

	[MenuItem("Assets/Build AssetBundle From Selection - No dependencies tracking")]
	static void ExportResourceNoTrack() {
		string path = EditorUtility.SaveFilePanel ("Save Resource", "", "New Resource", "unity3d");
		if (path.Length != 0) {
			BuildPipeline.BuildAssetBundle (Selection.activeObject, Selection.objects, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CompleteAssets, BuildTarget.Android | BuildTarget.iOS);
		}
	}

}