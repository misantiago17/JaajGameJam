using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCantWalk : MonoBehaviour
{
    private static PlayerCantWalk instance;

    public static PlayerCantWalk Instance { get { return instance; } }

    private void Awake() {
        instance = this;
    }

    public void CantWalk() {
        this.GetComponent<PlayerWalk>().CanWalk = false;
    }

    public void CanWalk() {
        this.GetComponent<PlayerWalk>().CanWalk = true;
    }


}
