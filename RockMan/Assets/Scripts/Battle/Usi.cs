using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usi : Enemy
{
    public bool flg = false;
    private bool attackFlg = false;
    private Vector3 attaskStartPosi = new Vector3(11, 0, 0);

    private void Start()
    {
        hp = 200;
        Enemy.damage = 10;
     
    }
    // Start is called before the first frame update
    private void Update()
    {
        textHP.text = hp.ToString();
        positionSetting();
        waitEnemy();
        if (waitE)
        {
            moveVertical();
            Attack();
            DeathEnemy();
        }
        
    }
    private void moveVertical()
    {
        if (!attackFlg)
        {
            if (transform.position.z >= 4)
            {
                flg = true;
            }
            else if (transform.position.z <= -4)
            {
                flg = false;
            }

            if (transform.position.z < 4 && flg == false)
            {
                transform.Translate(Vector3.right * Time.deltaTime * 5);
            }
            else if (transform.position.z > -4 && flg == true)
            {
                transform.Translate(Vector3.left * Time.deltaTime * 5);
            }
        }
        
    }

    private void Attack()
    {

        if (!attackFlg)
        {
            if (positionY == PlayerBattleContoroller.Instance.positionY)
            {
                transform.localPosition = new Vector3(positionX + 11, 0, positionY);
                attaskStartPosi = gameObject.transform.position;
                attackFlg = true;
            }
        }
        
        if (attackFlg)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 5);
            if (transform.position.x <= -5)
            {
                transform.localPosition = attaskStartPosi;
                attackFlg = false;
            }
            
        }
    }
}
