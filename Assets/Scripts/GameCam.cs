using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCam : MonoBehaviour
{
    public GameObject Player1, Player2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mid = (Player1.transform.position + Player2.transform.position) * 0.5f;
        if (mid.x <= -5.15f) {
            transform.position = new Vector3(-5.15f, mid.y+1.9425f, -100);
        } else if (mid.x  >= 5.15f) {
            transform.position = new Vector3(5.15f, mid.y+1.9425f, -100);
        } else {
            transform.position = new Vector3(mid.x, mid.y+1.9425f, -100);
        }
    }
}
