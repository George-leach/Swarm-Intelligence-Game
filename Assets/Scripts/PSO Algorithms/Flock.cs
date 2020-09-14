using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehavior behavior;
    //Starting varaibles that can be eddited 
    [Range(10, 500)]
    public int startingCount = 10;
    const float AgentDensity = 0.08f;
    [Range(1f, 100f)]
    public float driveFactor = 10f;
    [Range(1f, 100f)]
    public float maxSpeed = 5f;
    [Range(1f, 10f)]
    public float neighborRadius = 1.5f;
    [Range(0f, 5f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    float squareMaxSpeed;
    float squareNeighborRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    // Start is called before the first frame update
    void Start()
    {
        int mapsize = 90;
        //Values are squared this is because they are used to compare values not caluclate, if calculating would involve calculating vector 2 magnitude which would need the values to be square rooting so just saving time
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighborRadius = neighborRadius * neighborRadius;
        squareAvoidanceRadius = squareNeighborRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;
        //initialize basic variables
        Collider2D[] hitColliders;
        Vector2 pos;
        //Loops through from 0 to the initial starting count of the variables which are flock members
        for (int i = 0; i < startingCount; i++)
        {
            do
            {
                //create a random position within the map size and checks that there is overlap with a collider.
                pos = new Vector2(Random.Range(-mapsize, mapsize), Random.Range(-mapsize, mapsize));
                hitColliders = Physics2D.OverlapCircleAll(pos, 1, 1);

            } while (hitColliders.Length > 0);
            //when no overlap happens a agent of the flock is created at that positions ,a random rotation and is set as a child of the flock.
        
            FlockAgent newAgent = Instantiate(
                agentPrefab,
               pos,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform);
            newAgent.name = "Agent " + i;
            newAgent.Initialize(this);
            agents.Add(newAgent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //loops through every agent of the flock.
        foreach (FlockAgent agent in agents)
        {
            //Every frame a behaviour move is calculated for member of the flock.
            List<Transform> context = GetNearbyObjects(agent);
         
            //The behaviour chosen and the flocks move is calculated variables provides are the agents in the flock ,the nearby objects to that agent and the flock controller itself.
            Vector2 move = behavior.CalculateMove(agent, context, this);
            move *= driveFactor;
            //ensure that the move is not more than the max speed and if it is then it is normalized to a range within the max speed.
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            //agents vector2 move it sent over.
            agent.Move(move);
        }
    }
    public void addmember()
    {
        //just like the initialization inside of the start but is callable this is used by the spawner for the game.
        int mapsize = 90;
        Collider2D[] hitColliders;
        Vector2 pos;
        do
        {
            pos = new Vector2(Random.Range(-mapsize, mapsize), Random.Range(-mapsize, mapsize));
            hitColliders = Physics2D.OverlapCircleAll(pos, 1, 1);

        } while (hitColliders.Length > 0);
        FlockAgent newAgent = Instantiate(
                 agentPrefab,
                pos,
                 Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                 transform);
        newAgent.name = "Agent " + startingCount;
        startingCount = startingCount + 1;
        newAgent.Initialize(this);
        agents.Add(newAgent);
    }
    List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        //makes a new list of transforms
        List<Transform> context = new List<Transform>();
        //context colliders gets a list of current entites that have colliders on in the nearby area
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(agent.transform.position, neighborRadius);
        //loops through each entity in the area
        foreach (Collider2D c in contextColliders)
        {
            //ensures that the agents added to the array are not the current agent thats area is being checked
            if (c != agent.AgentCollider)
            {
                context.Add(c.transform);
            }
        }
        return context;
    }

}
