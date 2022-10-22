using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> enemyLists = new List<GameObject>();

    public static BattleManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        battleFinished();
    }

    public void battleFinished()
    {
        if (enemyLists.Count == 0 )
        {
            Debug.Log("BattleFinished");
            SceneManager.LoadScene(1);
        }
    }
}
