using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{

    public string SpeakerName;
    [TextArea(1, 10)]
    public string Sentence;

}