using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{

    public AudioClip callSound;

    private bool isHelicopterCalled;
    private AudioSource callAudioSource;

    Rigidbody rbody;

    public void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        foreach (AudioSource source in audioSources)
        {
            if (source.priority == 1)
            {
                callAudioSource = source;
            }
        }
        rbody = GetComponent<Rigidbody>();
        isHelicopterCalled = false;
    }

    public void Call()
    {
        if (!isHelicopterCalled)
        {
            // Bug, don't know why
            AudioSource[] audioSources = GetComponents<AudioSource>();
            foreach (AudioSource source in audioSources)
            {
                if (source.priority == 1)
                {
                    callAudioSource = source;
                }
            }
            rbody = GetComponent<Rigidbody>();

            // End bug fix

            callAudioSource.clip = callSound;
            callAudioSource.enabled = true;
            callAudioSource.Play();
            rbody.velocity = new Vector3(0, 0, 50f);
            isHelicopterCalled = true;
        }
    }
}
