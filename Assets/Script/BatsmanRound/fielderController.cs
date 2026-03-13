using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.AI;

public class fielderController : MonoBehaviour
{
    [Header("Ai setting")]
    public float runDistance = 10f;   
    NavMeshAgent agent;
    GameObject ball;
    
    bool hasStartedChasing = false;   //  New Flag

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {

        ball = GameObject.FindGameObjectWithTag("ball");    
        
        if(ball != null)
        {
            float distance = Vector3.Distance(transform.position, ball.transform.position);

            // If chase not started yet, check distance
            if (!hasStartedChasing)
            {
                if (distance < runDistance)
                {
                    hasStartedChasing = true;   // chase ON
                }
                else
                {
                    return; // still outside radius
                }
            }

            agent.SetDestination(ball.transform.position);

            if (distance <= 1f)
            {
                agent.speed = 0f;
               // Debug.Log("fielder catch");
                Rigidbody ballrb = ball.GetComponent<Rigidbody>();
                ballrb.linearVelocity = Vector3.zero;
            }
        }          
        
    }
}
