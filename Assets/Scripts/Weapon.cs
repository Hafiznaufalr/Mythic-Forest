using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public Transform firePointD;
	public Transform firePointT;
	public Transform firePointR;
	public Transform firePointL;
	public GameObject bulletPrefabT;
	public GameObject bulletPrefabR;
	public GameObject bulletPrefabL;
	public GameObject bulletPrefabD;
	float x;
	float y;
	Player direction;
	public bool attack = false;
	void Start(){
	GameObject thePlayer = GameObject.Find("Player");
	direction = thePlayer.GetComponent<Player>();
	}
	
	void Update () {
		attack = direction.attack;
	x = direction.h;
	y = direction.v;

	if (!attack)
	{
		if(Input.GetButtonDown("Fire1") && y < 0){
			//StartCoroutine(shootdelay());
				ShootD();
		}
		else if (Input.GetButtonDown("Fire1") && y > 0)
		{
			//StartCoroutine(shootdelay());
				ShootT();
		}
		else if (Input.GetButtonDown("Fire1") && x > 0)
		{
			//StartCoroutine(shootdelay());
				ShootR();
		}

		else if (Input.GetButtonDown("Fire1") && x < 0)
		{
			//StartCoroutine(shootdelay());
				ShootL();
		}	
	}
	}
IEnumerator shootdelay()
    {
				attack = true;
        yield return new WaitForSeconds(1);
        attack = false;
    }
	void ShootD(){
			Instantiate(bulletPrefabD, firePointD.position, firePointD.rotation);
	}
	void ShootR(){
			Instantiate(bulletPrefabR, firePointR.position, firePointR.rotation);
	}
	void ShootT(){
			Instantiate(bulletPrefabT, firePointT.position, firePointT.rotation);
	}
	void ShootL(){
			Instantiate(bulletPrefabL, firePointL.position, firePointL.rotation);
	}


}
