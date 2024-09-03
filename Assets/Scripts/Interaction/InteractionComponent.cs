using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionComponent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// This function is executed whenever the player interacts with the gameObject that caontains this script as a component
    /// </summary>
    public void InteractionExecuted()
    {
        Debug.Log("Player interacted with " + gameObject.name);
        Destroy(gameObject);
    }
}
