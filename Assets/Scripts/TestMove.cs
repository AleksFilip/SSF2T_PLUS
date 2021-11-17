using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TestMove : MonoBehaviour
{
    private Animator PlayerAnims;
    private Vector3 Direction;
    void Start()
    {
        PlayerAnims = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D RigBody = GetComponent<Rigidbody2D>();
        if (Input.GetKeyDown(KeyCode.A)) {
           // Debug.Log("A was pressed");
            Direction = new Vector3(-10f,0,0);
        };

        if (Input.GetKeyDown(KeyCode.D))
        {
           // Debug.Log("D was pressed");
            Direction = new Vector3(10f,0,0);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
           PlayerAnims.SetTrigger("HasPunched");
        }

         if (Input.GetKeyDown(KeyCode.U))
        {
           PlayerAnims.SetTrigger("HasKicked");
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) {
            Direction = Vector3.zero;
        };

        if (Input.GetKey(KeyCode.S)) {
           // Debug.Log("S was pressed");
            PlayerAnims.SetBool("IsDucking", true);
            Direction = Vector3.zero;
        } else {
            PlayerAnims.SetBool("IsDucking", false);
        };

        if (Input.GetKeyDown(KeyCode.W))
        {
           // Debug.Log("W was pressed");
           PlayerAnims.SetTrigger("HasJumped");
          //  transform.position += new Vector3(0,0.1f,0);
        };
      
        if (transform.position.y <= -2.025f) {
             PlayerAnims.SetTrigger("HasLanded/OnLand");
             GetComponent<PhysicsScript>().inAir = false;
            } else {
                GetComponent<PhysicsScript>().inAir = true;
            };

        transform.position += Direction*Time.deltaTime;
        if (GetComponent<SpriteRenderer>().flipX == true) {
            PlayerAnims.SetFloat("XaxisWalk", -Direction.x);
        } else {
            PlayerAnims.SetFloat("XaxisWalk", Direction.x);
        }

        if (transform.position.x > GameObject.Find("Player2").transform.position.x) {
            GetComponent<SpriteRenderer>().flipX = true;
            GameObject.Find("Player2").GetComponent<SpriteRenderer>().flipX = false;
        } else {
            GetComponent<SpriteRenderer>().flipX = false;
            GameObject.Find("Player2").GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
