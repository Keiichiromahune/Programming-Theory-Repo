using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour, IDamaged
{

    private int damage = 20;
    // Start is called before the first frame update
    void Update()
    {
        //transform.rotation = Quaternion.AngleAxis(Time.deltaTime * 1000, Vector3.up);
        if (transform.position.y < 1)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Rockwoman"))
        {
            Destroy(gameObject);
        }
    }

    public void DamageToPlayer()
    {
        PlayerBattleContoroller.Instance.hp -= damage;
    }
}
