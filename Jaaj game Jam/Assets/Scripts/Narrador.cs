using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ActionTalk))]
public class Narrador : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<ActionTalk>().DoAction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
