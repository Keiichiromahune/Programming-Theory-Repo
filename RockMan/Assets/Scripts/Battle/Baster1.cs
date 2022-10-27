using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baster1 : Baster
{


    // Start is called before the first frame update
    void Start()
    {
        pentention = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBaster(50);
    }

    // POLYMORPHISM
    public override void MoveBaster(float velosity)
    {
        base.MoveBaster(velosity);

        damage = 30;

    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
