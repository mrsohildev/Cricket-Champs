using System.Collections;
using UnityEngine;

public class batesMan : MonoBehaviour
{
    [Header("Animation")]
    Animator animator;    
    public float batSwingSpeed = 5f;
    public float speed;

    public bool LBW = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {        
        if (Input.GetMouseButtonDown(0))  // Tap or Click
        {
            StartCoroutine(batanim());
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(horizontal * speed, 0, 0);
    }

    IEnumerator batanim()
    {
        animator.SetBool("swing", true);
        yield return new WaitForSeconds(batSwingSpeed);
        animator.SetBool("swing", false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ball")
        {
            Debug.Log("Out");
            LBW = true;           
        }
    }

}   
