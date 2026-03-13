using UnityEngine;

public class batCollisoinDetacation : MonoBehaviour
{
    public ballController ballControllerRef;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            Debug.Log("Half work done");

            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if (rb != null && rb.linearVelocity.magnitude < 0.5f)
            {
                Debug.Log("Work done");
                ballControllerRef.ThrowBallToTapPoint();
            }
        }
    }
}
