using System.Collections;
using UnityEngine;

public class BatsmanAI : MonoBehaviour
{   
    public float hitDistance = 1.8f;
    public Animator animator;
    public float batSwingSpeed;
    void Update()
    {
        GameObject ball = GameObject.FindWithTag("ball");
         
        if (ball != null)
        {
            float distance = Vector3.Distance(transform.position, ball.transform.position);

            if (distance < hitDistance)
            {
                Vector3 direction = ball.transform.position - transform.position;
                float x = direction.x;

                Vector3 pos = transform.position;
                pos.x = ball.transform.position.x;
                transform.position = pos;

                //I wish I had an animator friend.
                if (x > 0.3f)
                {
                    Debug.Log("right");
                    StartCoroutine(batanim());
                }
                else if (x < -0.3f)
                {
                    Debug.Log("left");
                    StartCoroutine(batanim());
                }
                else
                {
                    Debug.Log("straight");
                    StartCoroutine(batanim());
                }
            }
       
        }
    }
    IEnumerator batanim()
    {
        animator.SetBool("swing", true);
        yield return new WaitForSeconds(batSwingSpeed);
        animator.SetBool("swing", false);
    }
}
