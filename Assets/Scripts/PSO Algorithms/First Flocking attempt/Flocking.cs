using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Flocking : MonoBehaviour
{
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * speed, Time.deltaTime * speed,0 );
    }
}
