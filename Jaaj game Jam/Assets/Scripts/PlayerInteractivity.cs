using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractivity : MonoBehaviour
{

    private static PlayerInteractivity instance;

    private GameObject InteractiveObject;

    public static PlayerInteractivity Instance { get { return instance; } }

    private void Awake() {
        instance = this;
    }

    private void Update() {
        
        if(Input.GetKeyDown(KeyCode.E) && InteractiveObject) {

            InteractiveObject.GetComponent<ActionTrigger>().DoAction();
        }

    }


    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.GetComponent<ActionTrigger>()) {
            InteractiveObject = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {

        if (collision.GetComponent<ActionTrigger>()) {
            InteractiveObject = null;
        }
    }
}
