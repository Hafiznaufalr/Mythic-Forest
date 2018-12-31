using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
private Animator animator;
public float speed;
public float stoppingDistance;
public float retreatDistance;

private float timeBtwShots;
public float startTimeBtwShots;

public GameObject projectile;
public Transform player;
public float h = 0;
public float v = 0;

public int health;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;	
		health = 100;
		timeBtwShots = startTimeBtwShots;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(health);
		if (health <= 0)
        {
            Destroy(gameObject);;
        }
		h = player.transform.position.x - transform.position.x;
    v = player.transform.position.y - transform.position.y;
		
		Vector3 tempVect = new Vector3(h, v, 0);
		if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
		{
			
			transform.position = Vector2.MoveTowards(transform.position, player.position, speed*Time.deltaTime);
		
		}
		else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && (Vector2.Distance(transform.position, player.position) > retreatDistance)){
			
				transform.position = this.transform.position;
		
		}
		else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && (Vector2.Distance(transform.position, player.position) > retreatDistance)){
			
					transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
		
		}
		if(timeBtwShots <= 0){
			Instantiate(projectile, transform.position, Quaternion.identity);
			//StartCoroutine(shootdelay());
			timeBtwShots = startTimeBtwShots;
		}
	}
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PBullet"))
        {
            health -= 20;
        }
    }


	public void AnimateMovement(Vector3 tempVect)
    {
        animator.SetLayerWeight(1, 1);
        animator.SetFloat("x", tempVect.x);
        animator.SetFloat("y", tempVect.y);
    }
	IEnumerator shootdelay()
    {
				timeBtwShots = 3;
				Debug.Log(timeBtwShots);
        yield return new WaitForSeconds(3);
				timeBtwShots = 0;
				Debug.Log(timeBtwShots);
    }
}
