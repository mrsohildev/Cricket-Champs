using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class scoreSystem2nd : MonoBehaviour
{
    [Header("Ball Hit Control")]
    Rigidbody ballRB;
    public bool hitStarted = false;

    [Header("Distance Tracking")]
    Vector3 lastPosition;
    float totalDistance;

    [Header("Scores")]
    public static int totalScore = 0;   
    public int score = 0;    

    [Header("Score Distance Rules")]
    public float run1Distance = 10f;
    public float run2Distance = 20f;
    public float run4Distance = 35f;
    public float run6Distance = 50f;

    public int mysore;
    scoreSystem scoreSystems;
    void Start()
    {
        
    }

    
    void OnCollisionEnter(Collision collision)
    {
        if (!hitStarted && collision.gameObject.CompareTag("ball"))
        {
            Debug.Log("ball ko get kare liya hai");

            hitStarted = true;
            totalDistance = 0f;

            ballRB = collision.gameObject.GetComponent<Rigidbody>();
            if (ballRB == null) return;

            lastPosition = ballRB.position;
        }
    }

    void FixedUpdate()
    {
        if (!hitStarted || ballRB == null) return;

        float frameDistance = Vector3.Distance(ballRB.position, lastPosition);
        totalDistance += frameDistance;
        lastPosition = ballRB.position; //Becouse joo + ho chuka hai woh waps naa ho 
    }

    void Update()
    {
        mysore = scoreSystem.totalScore;
        if(mysore > totalScore)
        {
            Debug.Log("you win");
        }
        else if(mysore == totalScore)
        {
            Debug.Log("Tie");
        }
        else
        {
            Debug.Log("you lose");
        }
        if (!hitStarted || ballRB == null) return;

        if (totalDistance >= run6Distance || ballRB.linearVelocity.magnitude < 0.3f)
        {
            hitStarted = false;

            CalculateScore(totalDistance);
            Debug.Log("hona chaiyee reload");
            SceneManager.LoadScene("BallerScene");
        }
    }

    void CalculateScore(float distance)
    {
        if (distance < run1Distance)
            score = 1;
        else if (distance < run2Distance)
            score = 2;
        else if (distance < run4Distance)
            score = 4;
        else
            score = 6;

        totalScore += score;

        Debug.Log(" Ball Score: " + score);
        Debug.Log(" Total Score: " + totalScore);
    }
}
