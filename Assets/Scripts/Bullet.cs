using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

public float speed;
public Rigidbody2D rb;
private Transform player;
private Vector2 target;


	void Start () {
		string SBullet = this.ToString();
		rb.velocity = new Vector2(0,1) * speed;
		if (SBullet == "BulletR(Clone) (Bullet)")
		{
				Debug.Log("Go rigth");
				rb.velocity = new Vector2(1,0) * speed;
		}
		else if (SBullet == "BulletT(Clone) (Bullet)")
		{
				Debug.Log("Go Top");
				rb.velocity = new Vector2(0,1) * speed;
		}
		else if (SBullet == "BulletD(Clone) (Bullet)")
		{
				Debug.Log("Go down");
				rb.velocity = new Vector2(0,-1) * speed;
		}
		else if (SBullet == "BulletL(Clone) (Bullet)")
		{
				Debug.Log("Go Left");
				rb.velocity = new Vector2(-1,0) * speed;
		}
		else if(SBullet == "BulletE(Clone) (Bullet)")
		{
				player = GameObject.FindGameObjectWithTag("Player").transform;

			target = new Vector2(player.position.x, player.position.y);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player")){ 
			}
			else
			{
					Destroy(gameObject);
			}
		
	}
	

}
