using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocaAssets : MonoBehaviour
{
    public List<GameObject> originalObjects = new List<GameObject>();
    public List<Sprite> replaceObjects = new List<Sprite>();

    public void ChangeAssets() {

        for(int i = 0; i < originalObjects.Count; i++) {
            originalObjects[i].transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = replaceObjects[0];
        }
        
    }

}
