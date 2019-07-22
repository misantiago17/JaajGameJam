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

    private bool ChekclistOn = true;

    public static CheckListManager Instance { get { return instance; } }

    private void Awake() {
        instance = this;
        
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.Space) && !ChekclistOn) {
            ShowCheckList();
        } else if (Input.GetKeyDown(KeyCode.Space) && ChekclistOn) {
            HideCheckList();
        }

    }

    public void AddItemCheckList(string text)
    {
        checklistTexts.Add(text);

        ShowCheckList();
    }


    public void RemoveItemCheckList(string text)
    {
        if (checklistTexts.Contains(text))
        {
            checklistTexts.Remove(text);
        }

        ShowCheckList();
    }


    private void ShowCheckList()
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

        ChekclistOn = true;
    }

    private void HideCheckList() {

        checklistBase.SetActive(false);
        checklistTextsHolders.SetActive(false);
        foreach (Transform textHolder in checklistTextsHolders.GetComponentInChildren<Transform>()) {
            textHolder.gameObject.SetActive(false);
        }

        ChekclistOn = false;

    }

}
