using UnityEngine;
using System.Collections;

public class CameraMov : MonoBehaviour {

	public Vector3 coordsMC;
	public Vector3 coordsJugador;

	public Camera mc;
	public GameObject Jugador;

	void Start () {
	}
	

	void OnTriggerEnter2D(Collider2D obj){ 
		if (obj.gameObject.tag == "Player") {
			mc.transform.position = coordsMC;
			Jugador.transform.position = coordsJugador;
		}
	}
		
	void Update () {
	
	}
}