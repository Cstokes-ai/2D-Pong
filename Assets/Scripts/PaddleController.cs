using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    //Since this has 2 paddles, they must be controlled separately. 
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Vertical");

        // Move the right paddle
        transform.Translate(0, move * Time.deltaTime * 10, 0);
    }
}