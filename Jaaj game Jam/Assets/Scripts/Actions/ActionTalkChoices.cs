﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTalkChoices : ActionTrigger
{
    // --- Public Variables --- //
    public int ChoicesIDInObject = 0;

    [TextArea(1, 3)] public string PromptHeader; 
    public List<DialoguePrompt> DialoguePrompts = new List<DialoguePrompt>();

    // --- Private Variables --- //
    private EndOfDialogue function;
    private bool startDialogue = false;
    [HideInInspector] public bool canStartDialogAgain = true;


    // --- Public Functions --- //

    public override void DoAction()
    {
        base.DoAction();

        function = EndAction;

        if (canStartDialogAgain)
        {
            DialogueManager.Instance.SelectPrompt(DialoguePrompts, function, PromptHeader);
            startDialogue = true;
            canStartDialogAgain = false;
        }
        else
        {
            base.EndAction();
        }
    }

    public override void EndAction()
    {
        base.EndAction();

        startDialogue = false;
        StartCoroutine(WaitUntilDialogIsFinished());
    }

    // --- Private Functions --- //

    private void Update()
    {
    }

    private IEnumerator WaitUntilDialogIsFinished()
    {

        yield return new WaitForSeconds(0.3f);
        canStartDialogAgain = true;
    }
}

