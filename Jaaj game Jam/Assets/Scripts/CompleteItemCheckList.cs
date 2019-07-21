using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteItemCheckList : MonoBehaviour
{
    public List<string> texts = new List<string>();

    public void RemoveItemInCheckList()
    {
        foreach (string text in texts)
        {
            CheckListManager.Instance.RemoveItemCheckList(text);
        }
    }
}
