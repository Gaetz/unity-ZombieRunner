using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

    public AudioClip callSound;

    private bool isCalled = false;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButton("CallHelicopter") && !isCalled)
        {
            isCalled = true;
            audioSource.clip = callSound;
            audioSource.Play();
        }
    }
}
