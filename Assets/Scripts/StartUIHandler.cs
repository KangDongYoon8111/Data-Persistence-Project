#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[DefaultExecutionOrder((1000))]
public class StartUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScore;
    public TextMeshProUGUI inputText;

    private void Start()
    {
        // if (GameManager.Instance.data.score != 0)
        // {
        //     bestScore.text = "Best Score : " + GameManager.Instance.data.name + " : " + GameManager.Instance.data.score;
        // }
        if (GameManager.Instance.rankList.Count > 0)
        {
            SaveData saveData = GameManager.Instance.rankList[0];
            bestScore.text = "Best Score : " + saveData.name + " : " + saveData.score;
        }
    }

    public void StartNew()
    {
        //GameManager.Instance.data.name = inputText.text;
        GameManager.Instance.inputText = inputText.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        //GameManager.Instance.Save(inputText.text, 0);
        
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
