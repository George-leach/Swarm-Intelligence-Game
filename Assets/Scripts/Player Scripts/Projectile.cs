using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    /// <summary>
    /// Public fields
    /// </summary>
    public float m_Speed = 5f;   // this is the projectile's speed
    public float m_Lifespan = 3f; // this is the projectile's lifespan (in seconds)

    /// <summary>
    /// Private fields
    /// </summary>
    private Rigidbody2D m_Rigidbody;

    /// <summary>
    /// Message that is called when the script instance is being loaded
    /// </summary>
    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Message that is called before the first frame update
    /// </summary>
    void Start()
    {
       if (m_Rigidbody.transform.localEulerAngles.z == 0)
        {
            m_Rigidbody.velocity = new Vector2(m_Speed,0);
        }
       else if (m_Rigidbody.transform.localEulerAngles.z == 270)
        {
            m_Rigidbody.velocity = new Vector2(0, -m_Speed);
        }
        else if (m_Rigidbody.transform.localEulerAngles.z == 180)
        {
            m_Rigidbody.velocity = new Vector2(-m_Speed, 0);
        }
        else if (m_Rigidbody.transform.localEulerAngles.z == 90)
        {
            m_Rigidbody.velocity = new Vector2(0, m_Speed);
        }


        Destroy(gameObject, m_Lifespan);
    }
   
}
