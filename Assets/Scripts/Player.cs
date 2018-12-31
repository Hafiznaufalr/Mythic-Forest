using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

   

    AudioSource audioa;
    public AudioClip hitSound;
    public float speed = 100;
    public Rigidbody2D rb;
    public bool attack = false;
    public int health;
    Text healthUI;
    private Animator animator;
    // Use this for initialization
    public float h = 0;
    public float v = 0;
    void Start()
    {
        healthUI = GameObject.Find ("Health").GetComponent<Text> ();
        health = 5000;
        animator = GetComponent<Animator>();
        audioa = GetComponent<AudioSource>();
    }
    

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene ("Menu");
        }
        TampilkanHealth();
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        Vector3 tempVect = new Vector3(h, v, 0);
        if (Input.GetButtonDown("Fire1") && attack != true)
        {
            audioa.PlayOneShot(hitSound);
            animator.SetBool("attacking",true);
            animator.SetLayerWeight(2, 1);
            animator.SetFloat("x", tempVect.x);
            animator.SetFloat("y", tempVect.y);
            animator.SetBool("attacking", true);
        }
        else
        {
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            rb.MovePosition(rb.transform.position + tempVect);

            if (tempVect.x != 0 || tempVect.y != 0)
            {
                AnimateMovement(tempVect);
            }
            else
            {
                animator.SetLayerWeight(1, 0);
            }
        }
        if  (Input.GetButtonUp("Fire1"))
            {
                 
            //StartCoroutine(shootdelay());
            animator.SetBool("attacking", false);
            animator.SetLayerWeight(2, 0);
        }
    }
    IEnumerator shootdelay()
    {

        yield return new WaitForSeconds(1);
        attack = false;
    }

    public void AnimateMovement(Vector3 tempVect)
    {
        animator.SetLayerWeight(1, 1);
        animator.SetFloat("x", tempVect.x);
        animator.SetFloat("y", tempVect.y);
    }

   	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            health--;
        }
    }
void TampilkanHealth ()
  {
  Debug.Log ("Score P1nya: " + health );
  healthUI.text = health + "";

  }

}