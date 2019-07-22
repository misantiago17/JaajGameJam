using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueManager: MonoBehaviour
{
    private static DialogueManager instance;

    private Queue<string> sentences;
    private Queue<string> speakerName;

    private EndOfDialogue EndDialogue;

    private int maxDialogueOptions = 1;

    private List<DialoguePrompt> dialoguePrompts = new List<DialoguePrompt>();
    [HideInInspector]
    public bool DialogueSelection = false;
    private int currentSelectedPrompt;


    [HideInInspector]
    public bool ConversationStarted = false;

    public Text nameText;
    public Text dialogueText;
    public Text dialogueHeader;
    public GameObject dialogueOptions;

    private bool canDisplayNextSentence = true;
    public float DelayBetweenSentencesValue = 0.3f;

    public static DialogueManager Instance { get { return instance; } }

    private void Awake() {
        instance = this;
        sentences = new Queue<string>();
        speakerName = new Queue<string>();

        this.GetComponent<AddItemCheckList>().AddItemInCheckList();
    }

    private void Update() {

        if (ConversationStarted) {
            if ((Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E)) && canDisplayNextSentence) {
                DisplayNextSentence();

            } else if (Input.GetKeyDown(KeyCode.Escape)) {
                EndDialog(false, false, 0);
            }
        }

        if (DialogueSelection) {

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxis("Mouse ScrollWheel") > 0f) {

                if (currentSelectedPrompt > 0) {
                    currentSelectedPrompt--;

                    dialogueOptions.transform.GetChild(currentSelectedPrompt + 1).GetChild(0).GetComponent<Text>().fontStyle = FontStyle.Normal;
                }

                dialogueOptions.transform.GetChild(currentSelectedPrompt).GetChild(0).GetComponent<Text>().fontStyle = FontStyle.Bold;


            } else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetAxis("Mouse ScrollWheel") < 0f) {

                if (currentSelectedPrompt < maxDialogueOptions) {
                    currentSelectedPrompt++;

                    dialogueOptions.transform.GetChild(currentSelectedPrompt - 1).GetChild(0).GetComponent<Text>().fontStyle = FontStyle.Normal;
                }

                dialogueOptions.transform.GetChild(currentSelectedPrompt).GetChild(0).GetComponent<Text>().fontStyle = FontStyle.Bold;

            } else if (((Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E)) && canDisplayNextSentence) || dialoguePrompts.Count == 1) {

                StartDialogue(dialoguePrompts[currentSelectedPrompt].dialogue);
                dialogueOptions.transform.GetChild(currentSelectedPrompt).GetChild(0).GetComponent<Text>().fontStyle = FontStyle.Normal;
                DialogueSelection = false;
                dialogueOptions.SetActiveRecursively(false);

            } else if (Input.GetKeyDown(KeyCode.Escape)) {
                DialogueSelection = false;
                dialogueOptions.SetActiveRecursively(false);
                EndDialog(false,false,0);
            }
        }

    }


    public void MouseOverButton(int numberOption) {

        foreach (Transform dialogueChild in dialogueOptions.GetComponentInChildren<Transform>(true)) {
            dialogueChild.GetChild(0).GetComponent<Text>().fontStyle = FontStyle.Normal;
        }

        currentSelectedPrompt = numberOption - 1;
        dialogueOptions.transform.GetChild(currentSelectedPrompt).GetChild(0).GetComponent<Text>().fontStyle = FontStyle.Bold;
    }

    // Se tem 1 prompt ele ignora o prompt e mostra o diálogo
    public void SelectPrompt(List<DialoguePrompt> _dialoguePrompts, EndOfDialogue endAction, string HeaderPrompt) {

        nameText.transform.parent.gameObject.SetActive(false);

        dialogueOptions.transform.parent.gameObject.SetActive(true);
        dialogueOptions.SetActive(true);

        dialoguePrompts = _dialoguePrompts;
        EndDialogue = endAction;

        maxDialogueOptions = dialoguePrompts.Count - 1;
        int index = 0;

        foreach (Transform dialogueChild in dialogueOptions.GetComponentInChildren<Transform>(true)) {

            if (index <= maxDialogueOptions) {

                dialogueChild.GetChild(0).GetComponent<Text>().text = dialoguePrompts[index].DialogPrompt;
                dialogueChild.gameObject.SetActiveRecursively(true);

                index++;
            }
        }

        dialogueOptions.transform.GetChild(0).GetChild(0).GetComponentInChildren<Text>().fontStyle = FontStyle.Bold;
        currentSelectedPrompt = 0;

        dialogueOptions.transform.parent.parent.gameObject.SetActive(true);
        dialogueOptions.SetActive(true);

        DialogueSelection = true;

        StartCoroutine(DelayBetweenSentences());
        canDisplayNextSentence = false;

    }

    public void StartDialogue(Dialogue[] dialogue) {

        nameText.transform.parent.gameObject.SetActive(true);
        sentences.Clear();

        foreach (Dialogue dialogueSentence in dialogue) {
            sentences.Enqueue(dialogueSentence.Sentence);
            speakerName.Enqueue(dialogueSentence.SpeakerName);
        }

        DisplayNextSentence();
        ConversationStarted = true;
    }

    private void DisplayNextSentence() {

        if (sentences.Count == 0) {

            //Debug.Log(dialoguePrompts[currentSelectedPrompt].Unlock + "Unlock");
            //Debug.Log(dialoguePrompts[currentSelectedPrompt].triggerChoices + "Choices");
            //Debug.Log(dialoguePrompts[currentSelectedPrompt].choicesID + "NUM");
            EndDialog(dialoguePrompts[currentSelectedPrompt].Unlock, dialoguePrompts[currentSelectedPrompt].triggerChoices, dialoguePrompts[currentSelectedPrompt].choicesID);
            return;
        }

        string sentence = sentences.Dequeue();
        string name = speakerName.Dequeue();

        nameText.text = name;
        nameText.fontStyle = FontStyle.Bold;
        dialogueText.text = sentence;

        StartCoroutine(DelayBetweenSentences());
        canDisplayNextSentence = false;

    }

    private void EndDialog(bool unlock, bool choice, int choiceID) {
        nameText.transform.parent.parent.gameObject.SetActive(false);
        ConversationStarted = false;
        EndDialogue(unlock,choice, choiceID);
    }

    IEnumerator DelayBetweenSentences() {

        yield return new WaitForSeconds(DelayBetweenSentencesValue);
        canDisplayNextSentence = true;
    }
}