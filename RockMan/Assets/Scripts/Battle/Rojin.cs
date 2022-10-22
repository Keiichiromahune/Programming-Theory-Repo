using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rojin : Enemy
{

    public Vector3 rojinPos = new Vector3(0, 0, 0);
    public bool moveFlg = false;
    public List<float> randomPos = new List<float>() {-4, 0 ,4};
    public bool atckFlg = false;
    [SerializeField] GameObject sphear;

// Start is cal led before the first frame update
void Start()
    {
       hp = 50;
    }

    // Update is called once per frame
    void Update()
    {
        textHP.text = hp.ToString();

        positionSetting();
        waitEnemy();
        if (waitE)
        {
            MoVeRojin();
            Attack();
            DeathEnemy();
        }

    }

    public void MoVeRojin()
    {
        if (!moveFlg)
        {
            float randomPosX = randomPos[Random.Range(0, randomPos.Count)];
            float randomPosY = randomPos[Random.Range(0, randomPos.Count)];
            rojinPos = new Vector3(randomPosX + 11, 0, randomPosY);
            gameObject.transform.position = rojinPos;
            StartCoroutine("moveSpan");

        }
    }

    IEnumerator moveSpan()
    {

        moveFlg = true;
        yield return new WaitForSeconds(1);
        moveFlg = false;
    }

    public void Attack()
    {
        
        if (!atckFlg)
        {
            float randomPosX = randomPos[Random.Range(0, randomPos.Count)];
            float randomPosY = randomPos[Random.Range(0, randomPos.Count)];
            Instantiate(sphear, new(randomPosX, 5, randomPosY), Quaternion.identity);
            StartCoroutine("AttackFlgManger");
        }
    }

    IEnumerator AttackFlgManger()
    {
        atckFlg = true;
        yield return new WaitForSeconds(5);
        atckFlg = false;
    }
}
