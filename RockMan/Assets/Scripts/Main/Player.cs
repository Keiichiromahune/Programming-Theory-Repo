using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance;


    public int hp;
    private string playerName;
    [SerializeField] TMP_Text playerNameText;
    [SerializeField] TMP_Text hp_Text;
    private Animator playerAnim;
    public Vector3 placeHere;
    [SerializeField] GameObject clearPanel;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerName = GameManager.Instance.playerName;
        transform.position = GameManager.Instance.playerCurrentPosi;
        hp = GameManager.Instance.currentHp;
        hp_Text.text = "HP: " + hp.ToString();
        playerNameText.text = playerName;
        playerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        placeHere = transform.position;
        playerNameText.text = playerName;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 10);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.back * Time.deltaTime * 10);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("EnemyObj"))
        {
            //データを保存してシーン移動
            SceneManager.LoadScene(2);
        }else if (collision.collider.CompareTag("GameClear"))
        {
            Time.timeScale = 0;
            clearPanel.SetActive(true);
        }

    }
}
