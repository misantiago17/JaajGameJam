using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItemCheckList : MonoBehaviour
{
    public List<string> texts = new List<string>();

    public void AddItemInCheckList()
    {
        foreach(string text in texts)
        {
            CheckListManager.Instance.AddItemCheckList(text);
        }
    }

}
