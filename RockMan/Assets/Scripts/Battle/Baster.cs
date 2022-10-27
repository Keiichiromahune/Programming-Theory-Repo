using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baster : MonoBehaviour
{

    private float speed = 30;
    public static int damage = 10;
    public bool pentention = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveBaster(speed);
    }

    public virtual void MoveBaster(float velosity)
    {
        transform.Translate(Vector3.right * Time.deltaTime * velosity);

        if (transform.position.x > 15)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(!pentention)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
        }
        
    }
}
