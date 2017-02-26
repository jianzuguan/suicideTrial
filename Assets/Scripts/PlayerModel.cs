using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour {

    public float groundSpeed = 50f;
    public float airSpeed = 5f;
    public float groundDrag = 10f;
    public float airDrag = 1f;

    public float health = 200f;
    public bool isGrounded = true;

    private bool isAlive = true;

    public float getSpeed() {
        return isGrounded ? groundSpeed : airSpeed;
    }

    public float getDrag() {
        return isGrounded ? groundDrag : airDrag;
    }

    public void TakeDamage(float damage) {
        if (this.isAlive && this.health-damage > 0) {
            this.health -= damage;
        } else {
            this.health = 0;
            this.isAlive = false;
        }
    }

    public bool IsAlive() {
        return this.isAlive;
    }
    
}
