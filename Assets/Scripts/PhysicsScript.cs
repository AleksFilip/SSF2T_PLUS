using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsScript : MonoBehaviour
{
    public bool inAir = false;

    void Update(){
        Rigidbody2D RigBody = GetComponent<Rigidbody2D>();
        if (Input.GetKeyDown(KeyCode.W) && inAir == false) {
            inAir = true;
            RigBody.AddForce(new Vector3(0,500,0), ForceMode2D.Force);
        }
    }
}

