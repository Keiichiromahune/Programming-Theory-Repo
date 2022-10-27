using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour, IDamaged
{
    private float speed = -10;
    private int damage = 10;

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
        //transform.rotation = Quaternion.AngleAxis(Time.deltaTime * 1000, Vector3.up);
        if (transform.position.x < -6)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rockwoman"))
        {
            Destroy(gameObject);
        }
    }

    public void DamageToPlayer()
    {
        PlayerBattleContoroller.Instance.hp -= damage;
    }

}
