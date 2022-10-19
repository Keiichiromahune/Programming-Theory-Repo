using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private MoveScene  moveScene;
    public static GameManager Instance;
    public string platerName;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //moveScene = GameObject.Find("SceneManager").GetComponent<MoveScene>();
        //platerName = moveScene.playerName;
        platerName = "Rock";
        Debug.Log(platerName);
    }

    
}
