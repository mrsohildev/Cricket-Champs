using UnityEngine;

public class ballOverController : MonoBehaviour
{
    public Transform startpoint;
    public GameObject prefabObj;
    public float speed = 500f;
    public bool ispause = false;

    [Header("Over Settings")]
    public int maxBallsPerOver = 6;

    [Header("Runtime Data")]
    public static int currentBallCount = 0;  
    public static bool isOver = false;        

    void Start()
    {
        ispause = false;   
    }

    void Update()
    {
        if (ispause || isOver) return;

        if (Input.GetMouseButtonDown(0))
        {
            ispause = true;
            ThrowNextBall();

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f;

            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousePos);
            Vector3 rbdir = worldPoint - startpoint.position;

            GameObject overBall = Instantiate(prefabObj, startpoint.position, Quaternion.identity);
            Rigidbody rb = overBall.GetComponent<Rigidbody>();
            rb.AddForce(rbdir.normalized * speed, ForceMode.Impulse);
        }
    }

    public void ThrowNextBall()
    {
        if (currentBallCount >= maxBallsPerOver)
        {
            OverComplete();
            return;
        }

        currentBallCount++;
        Debug.Log("Ball No: " + currentBallCount);
    }

    void OverComplete()
    {
        Debug.Log("Over Complete!");
        isOver = true;
    }
}
