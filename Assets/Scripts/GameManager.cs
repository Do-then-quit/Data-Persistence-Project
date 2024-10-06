using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string currentPlayerName;
    public int currentPlayerScore;

    public string bestPlayerName;
    public int bestPlayerScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestPlayerData();
    }

    [System.Serializable]
    class BestSaveData
    {
        public string bestPlayerName;
        public int bestPlayerScore;
    }

    public void SaveBestPlayerData()
    {
        BestSaveData data = new BestSaveData();
        data.bestPlayerName = currentPlayerName;
        data.bestPlayerScore = currentPlayerScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestSaveData data = JsonUtility.FromJson<BestSaveData>(json);

            bestPlayerName = data.bestPlayerName;
            bestPlayerScore = data.bestPlayerScore;
        }
    }
}
