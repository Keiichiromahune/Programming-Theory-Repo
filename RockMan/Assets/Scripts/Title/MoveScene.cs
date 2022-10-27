using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;



public class MoveScene : MonoBehaviour
{

    private string m_PlayerName;

    // ENCAPSULATION
    public string playerName
    {
        get { return m_PlayerName; }
        set
        {
            setName();
        }
    }
    private Vector3 startPos = new Vector3(0, 0, 0);
    public static MoveScene Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

    }

    [SerializeField] TMP_InputField inputField;


    // Start is called before the first frame update
    void Start()
    {
        inputField = GameObject.Find("InputField (TMP)").GetComponent<TMP_InputField>();
    }


    public void GameStart()
    {
        SaveInfo(100, startPos, playerName);
        SceneManager.LoadScene(1);
 
    }

    public void setName()
    {
        if (inputField.text == "")
        {
            m_PlayerName = "Hello World";
        }
        else
        {
            m_PlayerName = inputField.text;
        }
       
    }



    public void SetName()
    {
        playerName = inputField.text;
    }
    [System.Serializable]
    class PlayerData
    {
        public string playerName;
        public int hp;
        public Vector3 playerPos;
    }

    public void SaveInfo(int currentHpData, Vector3 currentPosiData, string playerName)
    {
        PlayerData data = new PlayerData();
        data.hp = currentHpData;
        data.playerPos = currentPosiData;
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

}
