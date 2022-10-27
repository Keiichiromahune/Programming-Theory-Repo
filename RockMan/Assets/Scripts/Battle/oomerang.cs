using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oomerang : MonoBehaviour , IDamaged
{
    private float speed = 10;
    private int damage = 20;
    private bool curvebool = false ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (!curvebool)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }


        if (transform.position.x <= -4)
        {
            curvebool = true;
        }

        if (transform.position.x > 17)
        {
            Destroy(gameObject);
        }
    }
    public void DamageToPlayer()
    {
        PlayerBattleContoroller.Instance.hp -= damage;
    }
}
