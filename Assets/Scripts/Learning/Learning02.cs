using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learning02 : MonoBehaviour
{
    public Rigidbody sphereBody;
    public float forceAmount = 100;
    public int testPrivateVariable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sphereBody.AddForce(sphereBody.transform.forward * forceAmount, ForceMode.VelocityChange);
    }
}
