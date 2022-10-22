using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public int hp;
    public float positionX;
    public float positionY;
    public bool boolX;
    public bool boolY;
    public static int damage;
    public TMP_Text textHP;
    public bool waitE = false;
    public float waitTIme = 0;



    void Start()    
    {
        hp = 100;
        damage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        textHP.text = hp.ToString();
        DeathEnemy();
    }

    public void waitEnemy()
    {
        waitTIme += Time.deltaTime;
        if (positionX  == -4.0f)
        {
            if (waitTIme > 3)
            {
                waitE = true;
            }
        }
        else if (positionX == 0f)
        {
            if (waitTIme > 2)
            {
                waitE = true;
            }
        }
        else
        {
            if (waitTIme > 1)
            {
                waitE = true;
            }
        }

    }

    public void DeathEnemy()
    {
        if(hp <= 0)
        {
            int countLast = BattleManager.Instance.enemyLists.Count - 1;
            BattleManager.Instance.enemyLists.RemoveAt(countLast);
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Baster"))
        {
            hp -= Baster.damage;
        }
    }



    public void positionSetting()
    {
        if(transform.position.z <= 4 && transform.position.z > 2)
        {
            positionY = 4;
        } else if(transform.position.z <= 2 && transform.position.z > -2)
        {

            positionY = 0;

        }
        else if(transform.position.z <= -2 && transform.position.z >= -4)
        {
            
            positionY = -4;
        }

        if (transform.position.x <= 15 && transform.position.x > 13)
        {
            positionX = 4;

        }
        else if (transform.position.x <= 13 && transform.position.x > 9)
        {
            positionX = 0;
        }
        else if (transform.position.x <= 9 && transform.position.x >= 7)
        {
            positionX = -4;
        }


    }
    

}
