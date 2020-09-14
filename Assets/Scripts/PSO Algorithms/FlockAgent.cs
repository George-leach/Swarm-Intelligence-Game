
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FlockAgent : MonoBehaviour
{

    Flock agentFlock;
    public Flock AgentFlock { get { return agentFlock; } }

    readonly Collider2D agentCollider;
    public Collider2D AgentCollider { get { return agentCollider; } }
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //gets the rigid body component of the flock agent
        rb = this.GetComponent<Rigidbody2D>();
    
    }


    public void Initialize(Flock flock)
    {
        //initializes agent of flock.
        agentFlock = flock;
    }

    public void Move(Vector2 velocity)
    {
   
            rb = this.GetComponent<Rigidbody2D>();
            //  transform.up = velocity;
            rb.MovePosition(transform.up = velocity);
            rb.MovePosition(transform.position += ((Vector3)velocity * Time.deltaTime));
            //transform.position += (Vector3)velocity * Time.deltaTime;
        
    }
}
