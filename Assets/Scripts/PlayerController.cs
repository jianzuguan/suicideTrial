using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Camera cam;

    private Rigidbody rb;
    private PlayerModel model;

    // Use this for initialization
    void Start() {
        cam = Camera.main;

        rb = GetComponent<Rigidbody>();
        model = GetComponent<PlayerModel>();

    }


    private void Update() {
        if (GvrController.AppButton) {
            transform.position = new Vector3(155, 460, -145);
        }
    }
    // Update is called once per physic step
    private void FixedUpdate() {

        Vector3 down = transform.TransformDirection(Vector3.down);
        this.model.isGrounded = Physics.Raycast(transform.position, down, 1.1f);

        float forward = 0f;
        float right = 0f;
        Vector2 direction = GvrController.TouchPos;

        if (GvrController.IsTouching) {
            if (direction.y < 0.4f) {
                forward = 1f;
            } else if (direction.y > 0.6f) {
                forward = -1f;
            }

            if (direction.x < 0.4f) {
                right = -1f;
            } else if (direction.x > 0.6f) {
                right = 1f;
            }
        }
        /*
                if (GvrController.ClickButtonUp) {
                    Ray ray = cam.ScreenPointToRay(GvrController.Orientation);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit, 1000))
                        transform.position = hit.point;
                }

            */
        if (Mathf.Abs(forward) > float.Epsilon || Mathf.Abs(right) > float.Epsilon) {
            Vector3 targetMovement = cam.transform.forward * forward + cam.transform.right * right;
            // targetMovement.Normalize();
            targetMovement.y = 0;
            float s = this.model.getSpeed();
            if (targetMovement.x > 0 && targetMovement.z > 0) {
                s = s / Mathf.Sqrt(2);
            }
            targetMovement *= s;

            if (rb.velocity.sqrMagnitude < this.model.getSpeed() * this.model.getSpeed()) {
                rb.AddForce(targetMovement, ForceMode.Impulse);
            }
        }

        rb.drag = model.getDrag();
        if (this.model.isGrounded || transform.position.y <= 1) {
            if (transform.position.y < 1) {
                transform.position = new Vector3(transform.position.x, 1, transform.position.z);
            }
            if (!GvrController.IsTouching && Mathf.Abs(forward) < float.Epsilon && Mathf.Abs(right) < float.Epsilon && rb.velocity.magnitude < 1f) {
                rb.Sleep();
            }
        }
    }

}
