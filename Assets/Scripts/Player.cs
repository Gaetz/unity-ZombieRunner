using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Transform spawnGroup;
    public bool respawn = false;
    public GameObject landingArea;

    private Transform[] spawnPoints;
    private bool lastRespawnToggle;

	// Use this for initialization
	void Start () {
        spawnPoints = spawnGroup.GetComponentsInChildren<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
		if(lastRespawnToggle != respawn)
        {
            Respawn();
            respawn = false;
        }
        else
        {
            lastRespawnToggle = respawn;
        }
	}

    private void Respawn()
    {
        int i = Random.Range(1, spawnPoints.Length); // 1 not to spawn in spawn group transform
        transform.position = spawnPoints[i].transform.position;
    }

    void OnFindClearArea()
    {
        Invoke("DropFlare", 3f);
        DropFlare();
    }

    void DropFlare()
    {
        Instantiate(landingArea, transform.position, transform.rotation);
    }
}
