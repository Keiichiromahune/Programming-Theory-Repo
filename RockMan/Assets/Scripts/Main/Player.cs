using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    private int hp;
    private string playerName;
    [SerializeField] TMP_Text playerNameText;
    [SerializeField] TMP_Text hp_Text;



    private void Start()
    {
        hp = 200;
        playerName = GameManager.Instance.platerName;
        Debug.Log("playernname is " + playerName + " Hp " + hp);
    }

    private void Update()
    {
        playerNameText.text = playerName;
        hp_Text.text = "HP: " + hp.ToString();
    }
}
