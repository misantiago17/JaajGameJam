using UnityEngine;

[System.Serializable]
public class DialoguePrompt
{

    [TextArea(1, 2)]
    public string DialogPrompt;
    public Dialogue[] dialogue;
}
