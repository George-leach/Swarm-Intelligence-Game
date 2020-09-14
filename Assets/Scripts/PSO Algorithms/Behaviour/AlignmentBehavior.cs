using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Alignment")]
public class AlignmentBehavior : FlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neighbors, maintain current alignment
        if (context.Count == 0)
            return agent.transform.up;
        //add all points together and average
        Vector2 Move = Vector2.zero;
        foreach (Transform item in context)
        {
            Move += (Vector2)item.transform.up;
        }
        Move = Move/ context.Count;

        return Move;
    }
}
