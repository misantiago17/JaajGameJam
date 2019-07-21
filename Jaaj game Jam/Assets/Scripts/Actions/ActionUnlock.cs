using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionUnlock : MonoBehaviour
{

    [HideInInspector] public bool Unlocked = false;

    public GameObject Condicao;

    private bool ActivatedAction = false;

    // Start is called before the first frame update
    void Update()
    {
        /*if (Condicao) {
            if (Condicao.GetComponentInChildren<ActionUnlock>(true).Unlocked && !ActivatedAction)
            {
                UnlockItem();
                ActivatedAction = true;
            }
        }*/
    }

    public void UnlockItem()
    {
        Unlocked = true;
        if (this.GetComponent<AddItemCheckList>())
            this.GetComponent<AddItemCheckList>().AddItemInCheckList();
        if (this.GetComponent<CompleteItemCheckList>())
            this.GetComponent<CompleteItemCheckList>().RemoveItemInCheckList();
        if (this.GetComponent<ChangeGeneralDialogue>())
            this.GetComponent<ChangeGeneralDialogue>().ChangeDialogue();
        if (this.GetComponent<TrocaAssets>())
            this.GetComponent<TrocaAssets>().ChangeAssets();
    }
}
