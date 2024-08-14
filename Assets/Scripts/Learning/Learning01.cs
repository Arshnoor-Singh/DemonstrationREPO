using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learning01 : MonoBehaviour
{
    private int x;
    public int y;
    int z;

    // Start is called before the first frame update
    void Start()
    {
        x = 45;
        y = 9;
        z = DoSomeMath(y, x);

        Debug.Log("Value of x = " + x);

        Debug.Log("Value of y = " + y);

        Debug.Log("Value of z = " + z);
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void FixedUpdate()
    {
        
    }

    int DoSomeMath(int _parameter1, int _parameter2)
    {
        _parameter1 = _parameter2 * 54;
        _parameter2 = 65 * _parameter1;

        return _parameter2;
    }
}
