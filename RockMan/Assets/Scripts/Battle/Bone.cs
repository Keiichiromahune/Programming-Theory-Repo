using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    private float speed = -10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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

}
