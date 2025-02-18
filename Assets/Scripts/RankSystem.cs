using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RankSystem : MonoBehaviour
{
    public GameObject rankPanel;
    public Text bestScoreList;

    public GameObject gameoverPanal;
    private bool isGameover = false;

    private void Awake()
    {
        gameoverPanal.SetActive(false);
    }

    private void Start()
    {
        BestScoreCheck();
        StartCoroutine(GameOver());
    }

    private void Update()
    {
        if(!isGameover) return;
        
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(1);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void BestScoreCheck()
    {
        if (GameManager.Instance != null && GameManager.Instance.rankList.Count > 0)
        {
            //bestScoreText.text = "Best Score : " + GameManager.Instance.data.name + " : " + GameManager.Instance.data.score;
            //SaveData saveData = GameManager.Instance.rankList[0];
            //bestScore.text = "Best Score : " + saveData.name + " : " + saveData.score;

            int rank = 1;
            foreach (SaveData saveData in GameManager.Instance.rankList)
            {
                bestScoreList.text += $"{rank}. {saveData.name} : {saveData.score}\n";
                rank++;
            }
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3f);
        gameoverPanal.SetActive(true);
        isGameover = true;
    }
}
