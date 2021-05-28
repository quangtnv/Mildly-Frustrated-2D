using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Tilemaps;

public class PlayerColl : MonoBehaviour
{
    public CharacterController2D movement;
    public GameObject Saw;
    public GameObject Spike;
    public GameObject stepSpike;
    public GameObject FakestepSpike_1;
    public GameObject DelaySaw;
    public GameObject DelayMovingSpike;
    public Tilemap Invisi;

    public Collider2D box;
    public Collider2D round;

    public Animator anime;
    public int sawSpeed;
    public float stepSpeed;
    public float timeWait = 5.0f;

    private Rigidbody2D sawBody;
    private Rigidbody2D spikeBody;
    private float timer = 0.0f;
    
    private string[] deathTrig = {"Saw", "Spikes", "Spike", "Spike_Up", "SpikeLeft", "SpikeRight"};

    private void Awake() {
        sawBody = Saw.GetComponent<Rigidbody2D>();
        spikeBody = Spike.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log(other.name);
        if (other.name == "SawTrigger") {
            sawBody.velocity = Vector2.up * sawSpeed;
            spikeBody.velocity = Vector2.right * sawSpeed;
        }

        if (other.name == "Step spikes Trigger") {
            //Debug.Log(stepSpike.transform.localPosition);
            stepSpike.transform.localPosition = new Vector3(stepSpike.transform.localPosition.x, 0.8f, stepSpike.transform.localPosition.z);
            //stepSpike.transform.position = new Vector2(stepSpike.transform.position.x, stepSpike.transform.position.y + stepSpeed * Time.deltaTime);
            if (stepSpike.transform.localPosition.y >= 0.86) {
                stepSpike.transform.localPosition = new Vector3(stepSpike.transform.localPosition.x, stepSpike.transform.localPosition.y, stepSpike.transform.localPosition.z);
            }
        }

        if (other.name == "Fake Step Trigger") {
            FakestepSpike_1.transform.localPosition = new Vector3(FakestepSpike_1.transform.localPosition.x, -4.2f, FakestepSpike_1.transform.localPosition.z);
            //FakestepSpike_1.transform.localPosition = new Vector3(FakestepSpike_1.transform.localPosition.x, -4.27, FakestepSpike_1.transform.localPosition.z);
        }

        if (other.name == "Invisible") {
            Invisi.transform.localPosition = new Vector3(Invisi.transform.localPosition.x, Invisi.transform.localPosition.y, 0);
        }

        if (deathTrig.Contains(other.name)) {
            box.enabled = false;
            round.enabled = false;
            movement.enabled = false;
            anime.SetBool("isDead", true);
            FindObjectOfType<Manager>().ended();
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        
        if (other.name == "Saw Stay") {
                       
            timer += Time.deltaTime;
            if (timer >= timeWait) {
                DelaySaw.transform.localPosition = new Vector3(DelaySaw.transform.localPosition.x, 0.4f, DelaySaw.transform.localPosition.z); 
                ResetTimer(); 
            }
        }

        if (other.name == "Delay Moving Spike") {

            timer += Time.deltaTime;
            if (timer >= timeWait - 0.5) {
                DelayMovingSpike.transform.localPosition = new Vector3(-0.2f, DelayMovingSpike.transform.localPosition.y, DelayMovingSpike.transform.localPosition.z); 
                ResetTimer(); 
            }

        }

        Debug.Log(timer);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.name == "Saw Stay" && other.name == "Delay Moving Spike") {
            ResetTimer(); 
        }
       
    }

    private void ResetTimer() {
        timer = 0.0f;
    }
}
