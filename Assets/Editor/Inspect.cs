using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;


public class Inspect : EditorWindow
{
    int scene = 0;

    [MenuItem("Window/DarkInspector")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<Inspect>("DarkInspector");
    }
    void OnGUI()
    {
        GUILayout.Space(10);

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Unlock AllLevels"))
        {
            UnlockAll();
        }
        if (GUILayout.Button("Reset Game"))
        {
            ResetAll();
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        GUILayout.Label("Jump To Scene", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        scene = EditorGUILayout.IntSlider(scene, 0, 20);
        if (GUILayout.Button("Jump"))
        {
            if (EditorApplication.isPlaying)
                SceneManager.LoadScene(scene);
            else
            {
                UnityEditor.SceneManagement.EditorSceneManager.SaveScene(UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene());
                UnityEditor.SceneManagement.EditorSceneManager.OpenScene(SceneUtility.GetScenePathByBuildIndex(scene));
            }
        }
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        GUILayout.BeginHorizontal();
        GUILayout.EndHorizontal();

    }

    public void UnlockAll()
    {
        PlayerPrefs.SetInt("levelReached", 19);
        PlayerPrefs.SetInt("TotalCoin", 9999);
    }
    public void ResetAll()
    {
        PlayerPrefs.DeleteAll();
    }
}


