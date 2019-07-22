using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckListManager : MonoBehaviour
{
    private static CheckListManager instance;

    public GameObject checklistBase;

    public GameObject checklistTextsHolders;

    private List<string> checklistTexts = new List<string>();

    public static CheckListManager Instance { get { return instance; } }

    private void Awake() {
        instance = this;
        //this.GetComponent<ActionTalk>().DoAction();
    }

    public void AddItemCheckList(string text)
    {
        checklistTexts.Add(text);

        UpdateCheckList();
    }


    public void RemoveItemCheckList(string text)
    {
        if (checklistTexts.Contains(text))
        {
            checklistTexts.Remove(text);
        }

        UpdateCheckList();
    }


    private void UpdateCheckList()
    {
        checklistBase.SetActive(false);
        checklistTextsHolders.SetActive(false);
        foreach (Transform textHolder in checklistTextsHolders.GetComponentInChildren<Transform>())
        {
            textHolder.gameObject.SetActive(false);
        }


        if (checklistTexts.Count > 0) {

            checklistBase.SetActive(true);
            checklistTextsHolders.SetActive(true);

            int index = 0;
            foreach(Transform textHolder in checklistTextsHolders.GetComponentInChildren<Transform>()) {

                if (checklistTexts.Count >= index + 1) {
                    textHolder.gameObject.SetActive(true);
                    textHolder.GetComponent<Text>().text = checklistTexts[index];
                    index += 1;
                } else {
                    break;
                }
            }
        } 
    }

}
