using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inu : Enemy
{
    public bool flg = false;
    [SerializeField] GameObject bone;
    public bool attackFlg = false;

    // Start is called before the first frame update
    void Start()
    {
        hp = 50;

    }

    // Update is called once per frame
    void Update()
    {
        textHP.text = hp.ToString();
        positionSetting();
        
        positionSetting();
        waitEnemy();
        if (waitE)
        {
            MoveHorizonatal();
            Attack();
            DeathEnemy();
        }

    }

    private void MoveHorizonatal()
    {
        if (transform.position.x <= 7)
        {
            flg = true;
        }
        else if (transform.position.x >= 15)
        {
            flg = false;
        }

        if (transform.position.x > 7 && flg == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 5);
        }
        else if (transform.position.x < 15 && flg == true)
        {
            transform.Translate(Vector3.back * Time.deltaTime * 5);
        }
    }

    private void Attack()
    {
        if (!attackFlg)
        {
            if (positionY == PlayerBattleContoroller.Instance.positionY)
            {
                StartCoroutine("BoneSpawnSpam");
                
                Instantiate(bone, new Vector3(gameObject.transform.position.x, 1, gameObject.transform.position.z), Quaternion.identity);
            }
        }

    }

    IEnumerator BoneSpawnSpam()
    {
        attackFlg = true;
        yield return new WaitForSeconds(2);
        attackFlg = false;
    }
    
}
