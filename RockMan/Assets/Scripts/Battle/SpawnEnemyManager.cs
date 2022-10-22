using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class SpawnEnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> enemys;
    public float randomX = 7;
    private List<int> positionYs = new List<int>() {-4, 0 ,4};
    public static float positionX = -4;
    public static float positionY;


    private void Start()
    {
        StartCoroutine("SpawnEnemyCoro");

    }

    IEnumerator SpawnEnemyCoro()
    {
        for(int i = 0; i < 3; i++)
        {
            int objRandomX = Random.Range(0, enemys.Count);
            int RandomY = Random.Range(0, positionYs.Count);
            positionY = positionYs[RandomY];
            Instantiate(enemys[objRandomX], new Vector3(randomX + 0.2f, 0, positionY), Quaternion.Euler(0, -90, 0));
            BattleManager.Instance.enemyLists.Add(enemys[objRandomX]);
            yield return new WaitForSeconds(1);
            randomX += 4;
            
        }
    }

}
