using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learning03 : MonoBehaviour
{

    Learning02 testLearning02;
    // Start is called before the first frame update
    void Start()
    {
        testLearning02.forceAmount = 5;
        testLearning02.testPrivateVariable = 8;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
