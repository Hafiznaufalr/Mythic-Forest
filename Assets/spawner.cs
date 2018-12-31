using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

public Transform ini;
	public GameObject Monster;
	bool spawnning = false;
	// Use this for initialization
	void Start () {
		ini = this.transform;
	}
	IEnumerator spawndelay()
    {
				Instantiate(Monster,ini.position,ini.rotation);
				spawnning = true;
        yield return new WaitForSeconds(10);
				spawnning = false;
    }
	// Update is called once per frame
	void Update () {
		if (spawnning == false)
		{
				StartCoroutine(spawndelay());
		}
		
	}
}
