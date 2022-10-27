using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> enemyLists = new List<GameObject>();
    [SerializeField] GameObject player;
    [SerializeField] Canvas GameOverText;

    public static BattleManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        battleFinished();
        GameOver();
    }

    public void battleFinished()
    {
        if (enemyLists.Count == 0 )
        {
            GameManager.Instance.currentHp = PlayerBattleContoroller.Instance.hp;
            //GameManager.Instance.SaveInfoHPOnly();
            SceneManager.LoadScene(1);
        }
    }

    public void GameOver()
    {
         if (PlayerBattleContoroller.Instance.hp <= 0)
         {
            player.gameObject.SetActive(false);
            GameOverText.gameObject.SetActive(true);
            Time.timeScale = 0;
         }
        
    }
}
