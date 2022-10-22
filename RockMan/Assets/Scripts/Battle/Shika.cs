using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shika : Enemy
{

    public bool atckFlg = false;

    [SerializeField] GameObject bumeran;
    // Start is called before the first frame update
    void Start()
    {
        hp = 150;
        waitE = false;
    }

    // Update is called once per frame
    void Update()
    {

        textHP.text = hp.ToString();
        positionSetting();
        waitEnemy();
        if (waitE)
        {
            Attack();
            DeathEnemy();
        }
    }


    public void Attack()
    {

        if (!atckFlg)
        {
            Instantiate(bumeran, new(gameObject.transform.position.x, 1, gameObject.transform.position.z), Quaternion.identity);
            StartCoroutine("AttackFlgManger");
        }
    }

    IEnumerator AttackFlgManger()
    {
        atckFlg = true;
        yield return new WaitForSeconds(7);
        atckFlg = false;
    }

}
