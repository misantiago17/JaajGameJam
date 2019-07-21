using UnityEngine;

[System.Serializable]
public class DialoguePrompt
{
    public bool Unlock = false;
    public bool triggerChoices = false;
    public int choicesID = 0;
    [TextArea(1, 2)]
    public string DialogPrompt;
    public Dialogue[] dialogue;
}
