using UnityEditor;
using UnityEditor.SceneManagement;

public class EditPlayScene 
{
    [MenuItem("Unitynote/0�� �� ��� %[")]
    public static void StartFromFirstScene()
    {
        var pathOfFirstScene = EditorBuildSettings.scenes[0].path;
        var sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(pathOfFirstScene);

        EditorSceneManager.playModeStartScene = sceneAsset;
        EditorApplication.isPlaying = true;
    }
    [MenuItem("Unitynote/���� �� ��� %]")]
    public static void StartFromCurrentScene()
    {
        EditorSceneManager.playModeStartScene = null;
        EditorApplication.isPlaying = true;

    }
}
