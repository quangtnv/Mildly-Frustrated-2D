using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    public GameObject vc;

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("Player") && !other.isTrigger) {
            vc.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D other) {

        if (other.CompareTag("Player") && !other.isTrigger) {
            vc.SetActive(false);
        }
        
    }
}
