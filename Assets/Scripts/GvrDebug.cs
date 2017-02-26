using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GvrDebug : MonoBehaviour {

    public GameObject player;
    public Camera cam;

    private Text textField;


    private void Awake() {
        textField = GetComponent<Text>();
    }

    // Use this for initialization
    void Start() {
        if (cam == null) {
            cam = Camera.main;
        }

        if (cam != null) {
            // Tie this to the camera, and do not keep the local orientation.
            transform.SetParent(cam.GetComponent<Transform>(), true);
        }
    }

    // Update is called once per frame
    void Update() {
        textField.text =
            GvrController.TouchPos.ToString() + "\n" +
            player.transform.position.y + "\n" +
            cam.transform.forward + "\n" +
            cam.transform.right + "\n" +
            player.GetComponent<Rigidbody>().velocity;

    }
}
