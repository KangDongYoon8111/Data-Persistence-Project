using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string inputText;

    public SaveData data;
    
    // 10개 점수 저장 수정코드부
    public List<SaveData> rankList = new List<SaveData>();
    private string savePath;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // 10개 점수 저장 수정코드부
        savePath = Application.persistentDataPath + "/savefile.json";
        
        Load();
    }

    public void Save(int score)
    {
        // 10개 점수 저장 수정코드부
        // 현재 플레이어의 정보 추가
        SaveData newEntry = new SaveData { name = inputText, score = score };
        rankList.Add(newEntry);
        
        // 점수 높은 순으로 정렬
        rankList.Sort((a, b) => b.score.CompareTo(a.score));
        
        // 최대 10명만 유지
        if (rankList.Count > 10)
        {
            rankList.RemoveAt(rankList.Count - 1);
        }
        
        //if(this.data.score >= score) return;

        //this.data.name = inputText;
        //this.data.score = score;

        RankData data = new RankData();
        //data.saveData = this.data;
        data.saveDataList = rankList;

        string json = JsonUtility.ToJson(data, true);
        //File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        File.WriteAllText(savePath, json);
    }

    public void Load()
    {
        //string path = Application.persistentDataPath + "/savefile.json";
        // if (File.Exists(path))
        // {
        //     string json = File.ReadAllText(path);
        //     RankData data = JsonUtility.FromJson<RankData>(json);
        //     this.data = data.saveData;
        // }
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            RankData data = JsonUtility.FromJson<RankData>(json);
            rankList = data.saveDataList ?? new List<SaveData>();
        }
    }
}

[System.Serializable]
class RankData
{
    //public SaveData saveData;
    public List<SaveData> saveDataList;
}

[System.Serializable]
public class SaveData
{
    public string name;
    public int score;
}
