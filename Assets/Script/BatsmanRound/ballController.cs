using UnityEngine;
using System.Collections.Generic;

public class ballController : MonoBehaviour
{
    [Header("BallInfo")]
    public float timer = 0;
    public float throwPower = 15f;
    public Transform startPoint;
    public GameObject ballPrefab;
    public GameObject currentBall;
    public List<Transform> points = new List<Transform>();

    private void Start()
    {
        
    }
    void Update()
    { 
      
    }

    public void ThrowBallToTapPoint()
    {
        int index = Random.Range(0, points.Count);
        Vector3 targetPos = points[index].position;
       
        currentBall = Instantiate(ballPrefab, startPoint.position, Quaternion.identity);
        Rigidbody rb = currentBall.GetComponent<Rigidbody>();

        Vector3 direction = (targetPos - startPoint.position).normalized;

        rb.AddForce(direction * throwPower, ForceMode.Impulse);

        //Debug.Log("Throwing ball to : " + targetPos);
    }
}





