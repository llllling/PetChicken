using UnityEditor;
using UnityEditor.SceneManagement;

public class EditPlayScene 
{
    [MenuItem("Unitynote/0¹ø ¾À Àç»ý %[")]
    public static void StartFromFirstScene()
    {
        var pathOfFirstScene = EditorBuildSettings.scenes[0].path;
        var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(pathOfFirstScene);

        EditorSceneManager.playModeStartScene = sceneAsset;
        EditorApplication.isPlaying = true;
    }
    [MenuItem("Unitynote/ÇöÀç ¾À Àç»ý %]")]
    public static void StartFromCurrentScene()
    {
        EditorSceneManager.playModeStartScene = null;
        EditorApplication.isPlaying = true;

    }
}
