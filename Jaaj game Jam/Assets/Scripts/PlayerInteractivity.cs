using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractivity : MonoBehaviour
{

    private static PlayerInteractivity instance;

    private GameObject InteractiveObject;
    private bool canStartDialogueAgain = true;

    public static PlayerInteractivity Instance { get { return instance; } }

    private void Awake() {
        instance = this;
    }

    private void Update() {
        
        if(Input.GetKeyDown(KeyCode.E) && InteractiveObject) {

            if (InteractiveObject.GetComponent<ActionTalkCondicional>() && InteractiveObject.GetComponent<ActionTalkCondicional>().ObjectoCondicional.GetComponent<ActionUnlock>().Unlocked && canStartDialogueAgain) {
                InteractiveObject.GetComponent<ActionTalkCondicional>().DoAction();
                canStartDialogueAgain = InteractiveObject.GetComponent<ActionTalkCondicional>().canStartDialogAgain;

            } else if (InteractiveObject.GetComponent<ActionTalk>() && canStartDialogueAgain) {
                InteractiveObject.GetComponent<ActionTalk>().DoAction();
                canStartDialogueAgain = InteractiveObject.GetComponent<ActionTalk>().canStartDialogAgain;
            }
        }

        if (InteractiveObject) {
            if (InteractiveObject.GetComponent<ActionTalkCondicional>() && InteractiveObject.GetComponent<ActionTalkCondicional>().ObjectoCondicional.GetComponent<ActionUnlock>().Unlocked) {
                canStartDialogueAgain = InteractiveObject.GetComponent<ActionTalkCondicional>().canStartDialogAgain;
            } else {
                canStartDialogueAgain = InteractiveObject.GetComponent<ActionTalk>().canStartDialogAgain;
            }
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
