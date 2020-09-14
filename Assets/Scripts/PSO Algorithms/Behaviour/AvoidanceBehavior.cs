using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behavior/Avoidance")]
public class AvoidanceBehavior : FlockBehavior
{
    public override Vector2 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neighbors, return no adjustment
        if (context.Count == 0)
            return Vector2.zero;

        //add all points together and average
        Vector2 Move = Vector2.zero;
        int nAvoid = 0;
    
        foreach (Transform item in context)
        {
            //loops through every neighbours , checks that the value differrence is within the flock avoidance radius.
            if (Vector2.SqrMagnitude(item.position - agent.transform.position) < flock.SquareAvoidanceRadius && item.name !="Player")
            {
                 nAvoid++;
                //if is avoid by getting the difference between locations
                Move += (Vector2)(agent.transform.position - item.position);
            }
            else if (item.name == "Debris")
            {
                Vector2 Vector = Vector2.zero;
               nAvoid++;
                //Rotates vector based on x and y position
                  if (agent.transform.position.x < 0 && agent.transform.position.y <0)
                  {
                    Vector = Rotate((Vector2)((agent.transform.localPosition)), -180);
                }
                  else if (agent.transform.position.x < 0 && agent.transform.position.y > 0)
                  {
                      Vector = Rotate((Vector2)((agent.transform.localPosition)), -180);
                  }
                  else if (agent.transform.position.x > 0 && agent.transform.position.y < 0)
                  {
                      Vector = Rotate((Vector2)((agent.transform.localPosition)), 180);
                  }
                  else if (agent.transform.position.x > 0 && agent.transform.position.y > 0)
                  {
                       Vector = Rotate((Vector2)((agent.transform.localPosition)), 180);
                  }

                Move += Vector;




            }
            else if (item.name == "Wall")
            {
                nAvoid++;
                Vector2 Vector = Rotate((Vector2)(agent.transform.localPosition), 180);

                Move += Vector;
               
              //      avoidanceMove -= (Vector2)(agent.transform.InverseTransformDirection(agent.transform.forward));
          
                
            }
            else if (item.name == "Player")
            {
                nAvoid++;
                Move -= (Vector2)(agent.transform.position - item.position);
            }


        }
        if (nAvoid > 0)
            //Divides by number of avoided obstacles to get average            
            Move = Move/ nAvoid;

        return Move;
    }
    public  Vector2 Rotate(Vector2 v, float degrees)
    {
        float radians = degrees * Mathf.Deg2Rad;
        float sin = Mathf.Sin(radians);
        float cos = Mathf.Cos(radians);
        float tx = v.x;
        float ty = v.y;
        return new Vector2(cos * tx - sin * ty, sin * tx + cos * ty);
    }
}
