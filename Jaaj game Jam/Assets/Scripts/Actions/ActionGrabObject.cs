using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(ActionUnlock))]
public class ActionGrabObject : ActionTalk
{
    private bool canGrab = false;

    public override void DoAction() {
        base.DoAction();
    }

    public override void EndAction() {
        base.EndAction();

        this.gameObject.SetActive(false);
        this.GetComponent<ActionUnlock>().UnlockItem();
    }
}
