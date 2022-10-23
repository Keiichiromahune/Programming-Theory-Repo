using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance;


    private int hp;
    private string playerName;
    [SerializeField] TMP_Text playerNameText;
    [SerializeField] TMP_Text hp_Text;
    private Animator playerAnim;
    public Vector3 placeHere;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {

        //playerName = GameManager.Instance.playerName;
        playerAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        placeHere = transform.position;
        playerNameText.text = playerName;
        hp_Text.text = "HP: " + hp.ToString();
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
            GameManager.Instance.LoadPlayerInfo();
            SceneManager.LoadScene(2);
        }

    }
}
