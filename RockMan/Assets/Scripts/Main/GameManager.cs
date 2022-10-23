using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    private MoveScene  moveScene;
    public static GameManager Instance;


    //シーン間で保持するデータを保存
    public string playerName = "Rock";
    public int currentHp;
    public Vector3 playerCurrentPosi;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        LoadPlayerInfo();
        //JsonFileからデータを取得して保存

        //消さないように、他のシーンから映ってきた時に、名前を取得
        //moveScene = GameObject.Find("SceneManager").GetComponent<MoveScene>();
        //platerName = moveScene.playerName;
    }
    private void Update()
    {
        playerCurrentPosi = Player.Instance.placeHere;
    }


    [System.Serializable]
    class SaveData
    {
        //public string playerName;
        public int hp;
        public Vector3 playerPos;
    }

    public void SaveInfo()
    {
        SaveData data = new SaveData();
        data.hp = currentHp;
        data.playerPos = playerCurrentPosi;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }
    public void SaveInfoHPOnly()
    {
        SaveData data = new SaveData();
        data.hp = currentHp;
        //data.playerPos = playerCurrentPosi;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }



    public void LoadPlayerInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerCurrentPosi = data.playerPos;
            currentHp = data.hp;
        }

        
    }
}
