using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class VisibleStep : MonoBehaviour
{
    public Tilemap steps;

    private void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            steps.transform.localPosition = new Vector3(steps.transform.localPosition.x, steps.transform.localPosition.y, 0);
        }
        //Debug.Log(other.name);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            steps.transform.localPosition = new Vector3(steps.transform.localPosition.x, steps.transform.localPosition.y, -38);
        }
    }

}
