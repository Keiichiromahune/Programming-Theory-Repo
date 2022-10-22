using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class PlayerBattleContoroller : MonoBehaviour
{
    // Start is called before the first frame update

    private int hp = 100;
    //private string name;
    private Transform position;
    public  float positionX;
    public  float positionY;
    public GameObject baster;
    public TMP_Text playerHp;
    private float waitTime = 0;

    public static PlayerBattleContoroller Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        position = GetComponent<Transform>();
        transform.localPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        waitTime += Time.deltaTime;
        playerHp.text = hp.ToString();
        if(waitTime >= 3.0f)
        {
            MovePlayer();
            Baster();
        }

    }

    public void MovePlayer()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && (positionY < 4))
        {
            position.Translate(new Vector3(-4, 0, 0));
            positionY += 4;

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && (positionY > -4))
        {
            position.Translate(new Vector3(4, 0, 0));
            positionY -= 4;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && (positionX < 4))
        {
            position.Translate(new Vector3(0, 0, 4));
            positionX += 4;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && (positionX > -4))
        {
            position.Translate(new Vector3(0, 0, -4));
            positionX -= 4;
        }
    }

    public void Baster()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(baster, new Vector3(transform.position.x, 1,transform.position.z), Quaternion.identity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            hp -= Enemy.damage;

        }else if (collision.collider.CompareTag("Bone"))
        {
            hp -= 10;
        }else if (collision.collider.CompareTag("Cylinder"))
        {
            hp -= Cylinder.damage;
        }else if (collision.collider.CompareTag("Oomeran"))
        {
            hp -= oomerang.damage;
        }
            

    }
}