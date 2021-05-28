using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalText : MonoBehaviour
{
    public TextMeshProUGUI deathText;

    public void Update() {
        deathText.text = Manager.deathCount.ToString();
    }
    
}
