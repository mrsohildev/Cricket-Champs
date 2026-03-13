using UnityEngine;

public class BowlerThrow : MonoBehaviour
{   
    public float throwPower = 15f;
    public Transform startPoint;
    public GameObject ballPrefab;
    public GameObject currentballl;
    private void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))  // Tap or Click
        {
            ThrowBallToTapPoint();
        }
    }

    void ThrowBallToTapPoint()
    {
        // Step 1: Screen tap position
        Vector3 tapPos = Input.mousePosition;

        // Step 2: Raycast from camera to world
        Ray ray = Camera.main.ScreenPointToRay(tapPos);
        RaycastHit hit;

         currentballl =  Instantiate(ballPrefab, startPoint.position, Quaternion.identity);
       // Transform balltrans = currentballl.transform;   
        Rigidbody ballRB = currentballl.GetComponent<Rigidbody>();  

        if (Physics.Raycast(ray, out hit))
        {
            // Step 3: Calculate direction
            Vector3 direction = (hit.point - ballRB.transform.position).normalized;

            // Step 4: Apply force
            ballRB.AddForce(direction * throwPower, ForceMode.Impulse);

            Debug.Log("Throw towards: " + hit.point);
        }
    }
}
