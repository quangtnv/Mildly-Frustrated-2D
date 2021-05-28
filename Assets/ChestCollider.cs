using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCollider : MonoBehaviour
{
    public GameObject spike1;
    public GameObject spike2;
    public GameObject spike3;
    public Animator chest;
    public float timeWait;
    private int once = 1;

    private void OnTriggerEnter2D(Collider2D other) { 
        if (other.CompareTag("Player") && once == 1) {
            chest.enabled = true;
            once -= 1;
            Invoke("SpikeMove",timeWait);
        }
    }

    private void SpikeMove() {
        spike1.transform.localPosition = new Vector3(spike1.transform.localPosition.x, spike1.transform.localPosition.y + 1f, spike1.transform.localPosition.z);
        spike2.transform.localPosition = new Vector3(spike2.transform.localPosition.x + 1.9f, spike2.transform.localPosition.y, spike2.transform.localPosition.z);
        spike3.transform.localPosition = new Vector3(-1.9f - spike3.transform.localPosition.x, spike3.transform.localPosition.y, spike3.transform.localPosition.z);
    }
    

}
