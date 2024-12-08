using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float move = 0;

        // Control the left paddle with W and S keys
        if (Input.GetKey(KeyCode.W))
            move = 1;
        else if (Input.GetKey(KeyCode.S))
            move = -1;

        // Move the paddle
        transform.Translate(0, move * Time.deltaTime * 10, 0);
    }
}
