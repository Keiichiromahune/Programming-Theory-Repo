using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private MoveScene  moveScene;
    public static GameManager Instance;


    //シーン間で保持するデータを保存
    public string playerName = "Rock";
    public int hp = 200;
    public Vector3 startPlace = new Vector3(10, 0, 0);

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
        //消さないように、他のシーンから映ってきた時に、名前を取得
        //moveScene = GameObject.Find("SceneManager").GetComponent<MoveScene>();
        //platerName = moveScene.playerName;
    }

    
}
