using UnityEngine;
using UnityEngine.SceneManagement;
public class passWithoutCollision : MonoBehaviour
{
    public scoreSystem2nd scoreSystem2Nd;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ball" || scoreSystem2Nd.hitStarted == true)
        {
            SceneManager.LoadScene("BallerScene");
            Debug.Log("sceneload");
        }
    }
}
