using UnityEngine;
using UnityEngine.Assertions.Must;

public class wicketOut : MonoBehaviour
{
    public scoreSystem scoreSystem;
    public bool isWicketOut = false;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger touched by: " + other.name);

        if (other.CompareTag("ball"))
        {
            Debug.Log("Ball detected");

            if (!scoreSystem.hitStarted)
            {
                Debug.Log("OUT");               
                isWicketOut = true; 
            }
        }
    }

}




