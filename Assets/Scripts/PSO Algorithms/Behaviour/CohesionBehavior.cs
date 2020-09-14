using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Asset menu creation for easy behaviours
[CreateAssetMenu(menuName = "Flock/Behavior/Cohesion")]
public class CohesionBehavior : FlockBehavior
{

    Vector2 currentVelocity;
    public float agentSmoothTime = 0.5f;
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neighbors, return none
        if (context.Count == 0)
            return Vector2.zero;

        //total all points of agents together and average
        Vector2 Move = Vector2.zero;
  
        foreach (Transform item in context)
        {
            Move += (Vector2)item.position;
        }
        //gets the average
        Move = Move/ context.Count;
        //converts into vector2 - to bring agents together
        Move -= (Vector2)agent.transform.position;
        //the vector is smoothed by a function that ensures no overshooting
        Move = Vector2.SmoothDamp(agent.transform.up, Move, ref currentVelocity, agentSmoothTime);
        return Move;
    }
}

