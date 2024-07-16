using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager
{
    public BaseScene CurrentScene { get { return GameObject.FindObjectOfType<BaseScene>(); } }

    public void LoadScene(SceneType type)
    {
        Managers.Clear();

        // 로딩 씬으로 이동
        LoadingManager.TargetScene = GetSceneName(type);
        SceneManager.LoadScene("LoadingScene");
    }

    string GetSceneName(SceneType type)
    {
        string name = System.Enum.GetName(typeof(SceneType), type);
        return name;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void Clear()
    {
        CurrentScene.Clear();
    }
}
