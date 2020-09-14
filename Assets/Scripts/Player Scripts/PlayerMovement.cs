    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;
    // Update is called once per frame
    protected bool isAttacking = false;
    [SerializeField] private Transform pfBullet;
    public GameObject m_projectile;    // this is a reference to your projectile prefab
    public Transform m_SpawnTransform;
    public GameObject auid;
    public AudioClip clip;
    public AudioClip clip2;
    void Update()
    {
        //Input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Attack());
        }
        else
        {
           if (isAttacking == false)
            {
                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");
                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
               
           }
            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {

               
                animator.SetFloat("LastX", movement.x);
                animator.SetFloat("LastY", movement.y);
             
            }
            animator.SetFloat("Speed", movement.sqrMagnitude);

        }
       
    }

    void FixedUpdate()
    {
        //Movement
        if (isAttacking == true)
        {
            ActiveLayer("Attack Layer");
        }
        else
        {
            ActiveLayer("Base Layer");
            rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
            m_SpawnTransform = rb.transform;
        }
    }
    public IEnumerator Attack()
    {
      if (!isAttacking)
        {
            AudioSource audios = auid.GetComponent<AudioSource>();
            isAttacking = true;
            animator.SetBool("attack", true);
            audios.PlayOneShot(clip);
            yield return new WaitForSeconds(0.5f);
            isAttacking = false;
            float test = animator.GetFloat("LastX");
            float test1 = animator.GetFloat("LastY");
            var angle = Mathf.Atan2(test1, test) * Mathf.Rad2Deg;
            Instantiate(m_projectile, m_SpawnTransform.position, Quaternion.AngleAxis(angle,Vector3.forward));
            audios.PlayOneShot(clip2); ;
            animator.SetBool("attack", false);
            Debug.Log("done attack");
        }
      

    }

    public void ActiveLayer(string layername)
    {
        for (int i = 0; i < animator.layerCount; i ++)
        {
            animator.SetLayerWeight(i, 0);
        }
        animator.SetLayerWeight(animator.GetLayerIndex(layername), 1);
    }
    public void Changespeed()
    {
        movespeed += 0.1f;
    }
}
