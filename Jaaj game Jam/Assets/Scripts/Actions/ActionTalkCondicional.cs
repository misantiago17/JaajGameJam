using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTalkCondicional: ActionTrigger
{
    // --- Public Variables --- //
    public AudioSource audio;
    public GameObject ObjectoCondicional;

    [TextArea(1, 3)] public string PromptHeader;
    public List<DialoguePrompt> DialoguePrompts = new List<DialoguePrompt>();

    // --- Private Variables --- //
    private EndOfDialogue function;
    private bool startDialogue = false;
    [HideInInspector] public bool canStartDialogAgain = true;


    // --- Public Functions --- //

    public override void DoAction() {
        base.DoAction();

        function = EndDialogue;

        if (canStartDialogAgain && ObjectoCondicional.GetComponent<ActionUnlock>().Unlocked) {
            if (audio)
                audio.Play();
            DialogueManager.Instance.SelectPrompt(DialoguePrompts, function, PromptHeader);
            startDialogue = true;
            canStartDialogAgain = false;
        } else {
            base.EndAction();
        }
    }

    public void EndDialogue(bool unlock, bool choice, int choiceID)
    {

        if (unlock)
            this.GetComponent<ActionUnlock>().UnlockItem();

        if (choice) {
            this.GetComponent<ActionTalkChoices>().DoAction();
            EndAction();
        }
        else
            EndAction();
    }

    public override void EndAction() {
        base.EndAction();

        startDialogue = false;
        ObjectoCondicional.GetComponent<ActionUnlock>().Unlocked = false;
        StartCoroutine(WaitUntilDialogIsFinished());
    }

    // --- Private Functions --- //

    private void Update() {
    }

    private IEnumerator WaitUntilDialogIsFinished() {

        yield return new WaitForSeconds(0.3f);
        canStartDialogAgain = true;
    }
}
