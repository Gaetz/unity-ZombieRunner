using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform spawnGroup;
    public bool respawn = false;
    public Helicopter helicopter;

    public AudioClip WhatHappened;

    private AudioSource innerVoice;
    private Transform[] spawnPoints;
    private bool lastToggle;

	// Use this for initialization
	void Start () {
        spawnPoints = spawnGroup.GetComponentsInChildren<Transform>();

        AudioSource[] audioSources = GetComponents<AudioSource>();
        foreach (AudioSource source in audioSources)
        {
            if (source.priority == 1)
            {
                innerVoice = source;
            }
        }

        innerVoice.clip = WhatHappened;
        innerVoice.Play();
    }
	
	// Update is called once per frame
	void Update () {
		if(lastToggle != respawn)
        {
            Respawn();
            respawn = false;
        }
        else
        {
            lastToggle = respawn;
        }
	}

    private void Respawn()
    {
        int i = Random.Range(1, spawnPoints.Length); // 1 not to spawn in spawn group transform
        transform.position = spawnPoints[i].transform.position;
    }

    void OnFindClearArea()
    {
        helicopter.Call();
    }
}
