using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    [SerializeField]
    GameObject jumpscareScreen;
    [SerializeField]
    CameraShake camera;
    bool enabled;
    // Start is called before the first frame update
    void Start()
    {
        enabled = true;
    }

    // Update is called once per framesaySomething
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && enabled){
            jumpscareScreen.SetActive(true);
            jumpscareScreen.GetComponent<Animator>().Play("JumpscarePocong");
            camera.ShakeCamera(4f, 0.015f);
            enabled = false;
            other.SendMessage("saySomething", "Aah!");
        }
    }

    void Scare(){

    }
}
