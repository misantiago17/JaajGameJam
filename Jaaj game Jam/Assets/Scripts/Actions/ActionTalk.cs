using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public delegate void EndOfDialogue(bool unlock, bool choice, int choiceID);

public class ActionTalk : ActionTrigger
{
    // --- Public Variables --- //
    public AudioSource audio;
    // Abre para adicionar mais de uma opção de diálogo
    public bool MultipleOptions = false;
    // Título que aparece antes das escolhas do jogador
    [TextArea(1, 3)] public string PromptHeader;
    // As escolhas que o jogador pode selecionar
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
            if (audio)
                audio.Play();
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
            this.GetComponent<ActionTalkChoices>().DoAction();
            EndAction();
        } else
            EndAction();
    }


    public override void EndAction() {
        base.EndAction();

        startDialogue = false;
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


/*[CustomEditor(typeof(ActionTalk))]
public class MyScriptEditor: Editor
{
    public override void OnInspectorGUI() {
        var Dialogue = target as ActionTalk;

        Dialogue.MultipleOptions = GUILayout.Toggle(Dialogue.MultipleOptions, "Multiple Options");

        if (Dialogue.MultipleOptions) {
            Dialogue.PromptHeader = EditorGUILayout.("Prompt Header");
            Dialogue.PromptHeader = EditorGUILayout.TextArea("Prompt Header");

            EditorGUILayout.PropertyField(serializedObject.FindProperty("DialoguePrompts"), true);
            serializedObject.ApplyModifiedProperties();
        }

    }
}*/