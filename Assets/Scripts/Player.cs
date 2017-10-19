using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform spawnGroup;
    public bool respawn = false;

    private Transform[] spawnPoints;
    private bool lastToggle;

	// Use this for initialization
	void Start () {
        spawnPoints = spawnGroup.GetComponentsInChildren<Transform>();

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
}
