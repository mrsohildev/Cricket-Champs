using UnityEngine;
using UnityEngine.SceneManagement;

public class scoreSystem : MonoBehaviour
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

    [Header("Ball Controller Reference")]
    public ballController ballController;

    [Header("Score Distance Rules")]
    public float run1Distance = 10f;
    public float run2Distance = 20f;
    public float run4Distance = 35f;
    public float run6Distance = 50f;

    [Header("Over System Settings")]
    public int maxBallsPerOver = 6;

    [Header("Over Runtime Data")]
    public static int currentBallCount = 0;   
    bool overStarted = false;

    void Start()
    {
        overStarted = true;
        ThrowNextBall();
    }

    void ThrowNextBall()
    {
        if (!overStarted) return;

        if (currentBallCount >= maxBallsPerOver)
        {
            OverComplete();
            return;
        }

        currentBallCount++;
       
        ballController.ThrowBallToTapPoint();
    }

    void OverComplete()
    {
        overStarted = false;
      
        currentBallCount = 0;   
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!hitStarted && collision.gameObject.CompareTag("ball"))
        {
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
        lastPosition = ballRB.position;
    }

    void Update()
    {       

        if (!hitStarted || ballRB == null) return;

        if (totalDistance >= run6Distance || ballRB.linearVelocity.magnitude < 0.3f)
        {
            hitStarted = false;

            CalculateScore(totalDistance);
                       
            SceneManager.LoadScene("BatsmanScene");
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

        //Debug.Log(" Ball Score: " + score);
        //Debug.Log(" Total Score: " + totalScore);
    }
}
