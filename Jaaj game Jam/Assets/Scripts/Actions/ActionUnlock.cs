using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionUnlock : MonoBehaviour
{

    [HideInInspector] public bool Unlocked = false;

    // Start is called before the first frame update
    void Start()
    {
        Unlocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
