using UnityEngine;
using System.Collections;

public class SalaBoss_Nvl1 : MonoBehaviour {

	public Vector3 coordsMC;
	public Vector3 coordsMC2;

	public Camera mc;


	void Start () {
	
	}

	void OnTriggerStay2D(Collider2D obj){
		if (obj.gameObject.tag == "Player") {
			mc.transform.position = coordsMC;
		} else {
			mc.transform.position = coordsMC2;
		}
	}

	void Update () {
	}
}