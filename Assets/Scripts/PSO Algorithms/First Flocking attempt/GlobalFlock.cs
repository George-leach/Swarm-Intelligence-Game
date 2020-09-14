using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;



public class GlobalFlock : MonoBehaviour
{
    public GameObject Moleprefab;
    public static int mapsize = 10;
    // Start is called before the first frame update
    static int numberofMoles = 10;
    public static GameObject[] AllMoles = new GameObject[numberofMoles];
    private GameObject playerObj = null;
    Collider2D[] hitColliders;
    public static Vector3 goalPos;
    void Start()
    {
        if (playerObj == null)
            playerObj = GameObject.Find("Player");
        goalPos = playerObj.transform.position;
        //Okay to instance at the start 
        for (int i = 0; i < numberofMoles; i++)
        {
            Vector2 pos;
         
            do
            {
               pos = new Vector2(Random.Range(-mapsize, mapsize), Random.Range(-mapsize, mapsize));
                hitColliders = Physics2D.OverlapCircleAll(pos, 1,1);

            } while (hitColliders.Length > 0);
               AllMoles[i] = (GameObject)Instantiate(Moleprefab, pos, Quaternion.identity);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        goalPos = playerObj.transform.position;

    }
}
