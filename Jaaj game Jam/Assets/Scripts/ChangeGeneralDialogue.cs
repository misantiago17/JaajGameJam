using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(ActionTalk))]
public class ChangeGeneralDialogue : MonoBehaviour
{

    // --- Public Variables --- //
    [TextArea(1, 3)] public string PromptHeader;
    public List<DialoguePrompt> DialoguePrompts = new List<DialoguePrompt>();

    public void ChangeDialogue()
    {

    }

}
