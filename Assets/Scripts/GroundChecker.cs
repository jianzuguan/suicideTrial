using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour {

    public GameObject player;

    private PlayerModel model;

	// Use this for initialization
	void Start () {
        model = player.GetComponent<PlayerModel>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        model.isGrounded = true; 
    }

    private void OnTriggerExit(Collider other) {
        model.isGrounded = false;
    }
}
