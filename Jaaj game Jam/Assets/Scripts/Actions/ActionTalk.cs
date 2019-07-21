using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EndOfDialogue(bool unlock, bool choice, int choiceID);

public class ActionTalk : ActionTrigger
{
    // --- Public Variables --- //
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

        if (canStartDialogAgain) {
            DialogueManager.Instance.SelectPrompt(DialoguePrompts, function, PromptHeader);
            startDialogue = true;
            canStartDialogAgain = false;
        } else {
            base.EndAction();
        }
    }

    public void EndDialogue(bool unlock, bool choice, int choiceID) {

        if (unlock)
            this.GetComponent<ActionUnlock>().UnlockItem();

        if (choice)
        {
            Debug.Log("Sou uma escolha");
            startDialogue = false;
            this.GetComponent<ActionTalkChoices>().DoAction();
        } else
            EndAction();
    }


    public override void EndAction() {
        base.EndAction();


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
