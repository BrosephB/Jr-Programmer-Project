using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; } // make variable read only outside this script;
    public Color TeamColor;

    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadColor();
    }

    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor()
    {
        if (File.Exists(Application.persistentDataPath + "/savefile.json"))
        {
            string jsonString = File.ReadAllText(Application.persistentDataPath + "/savefile.json");
            SaveData jsonData = JsonUtility.FromJson<SaveData>(jsonString);

            TeamColor = jsonData.TeamColor;
        }
    }

}
