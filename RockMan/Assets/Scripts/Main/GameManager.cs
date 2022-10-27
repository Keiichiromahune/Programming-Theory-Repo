using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class GameManager : MonoBehaviour
{
    private MoveScene  moveScene;
    public static GameManager Instance;


    //シーン間で保持するデータを保存
    public string playerName;
    public int currentHp;
    public Vector3 playerCurrentPosi;

    private void Awake()
    {
        LoadPlayerInfo();
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    void Start()
    {

    }
    private void Update()
    {
        playerCurrentPosi = Player.Instance.placeHere;
    }

    [System.Serializable]
    class PlayerData
    {
        public string playerName;
        public int hp;
        public Vector3 playerPos;
    }

    public void SaveInfo(int currentHpData, Vector3 currentPosiData)
    {
        PlayerData data = new PlayerData();
        data.hp = currentHpData;
        data.playerPos = currentPosiData;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void SaveDataHpOnly(int HP)
    {
        PlayerData data = new PlayerData();
        data.hp = HP;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadPlayerInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            playerCurrentPosi = data.playerPos;
            currentHp = data.hp;
            playerName = data.playerName;
            
            string jsonStr = JsonUtility.ToJson(data);
            Debug.Log(jsonStr);
        }


    }


}
