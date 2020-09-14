using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Asset menu creation for easy behaviours
[CreateAssetMenu(menuName = "Flock/Behavior/RadiusBehaviour")]
public class Staywithinradius : FlockBehavior
{
    //Code below created by board to bits
    //variables initialized
    public Vector2 centre;
    public float radius = 90f;

    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {   
        //Gets the value of the opposite direction of the current agent
        Vector2 centreOffset = centre - (Vector2)agent.transform.position;
        //A calculation to get the value of the agents position based on the centre is t=0 then agent is at the centre if t=1 then the agent is at the edge of the radius
        float t = centreOffset.magnitude / radius;
        if (t < 0.9f)
        {
            //only returns the new value for the agent to return to the centre if the agent is within 10% of the edge of the flock.
            return Vector2.zero;
        }
        //squared t to give more effect 
        return centreOffset * t * t;
    }
}
