using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Movimiento : MonoBehaviour {


	public float fuerzaSalto = 100f;
	public Transform comprobadorSuelo;
	public LayerMask Suelo;

	private float comprobadorRadio = 0.60f;
	private bool enSuelo = true;
	private bool dobleSalto =  false;

	public Animator anim;

	public bool dirRight;

	private bool paused;


	void Start () {
		dirRight = true;
	}

	void FixedUpdate(){
		enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, Suelo);
		if(enSuelo){
			dobleSalto = false;
		}
	}

	void ControlPersonaje(){

		if (Input.GetKey (KeyCode.A)) {
			anim.SetBool ("stand", false);
			anim.SetBool ("mov_I", true);
			anim.SetBool ("mov_D", false);
			anim.SetBool ("salto", false);
			if (dirRight){
				dirRight = false;
				transform.Rotate (0, 180, 0);
			}
			transform.Translate (0.065f, 0, 0);
		} else {
			if (Input.GetKey (KeyCode.D)) {
				anim.SetBool ("stand", false);
				anim.SetBool ("mov_I", false);
				anim.SetBool ("mov_D", true);
				anim.SetBool ("salto", false);
				if (dirRight == false) {
					dirRight = true;
					transform.Rotate (0, 180, 0);
				}
				transform.Translate (0.065f, 0, 0);
			} else {
				anim.SetBool ("stand", true);
				anim.SetBool ("mov_I", false);
				anim.SetBool ("mov_D", false);
				anim.SetBool ("salto", false);

			}
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.SetBool ("ataque", true);
		} else {
			anim.SetBool ("ataque", false);
		}

		if((enSuelo || !dobleSalto) && Input.GetKeyDown(KeyCode.W)){
			anim.SetBool ("salto", true);
			anim.SetBool ("stand", false);
			anim.SetBool ("mov_I", false);
			anim.SetBool ("mov_D", false);
			anim.SetBool ("ataque", false);
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, fuerzaSalto);
				
			if(!dobleSalto && !enSuelo){
				dobleSalto = true;
			}	
		}

		/*if (Input.GetKey (KeyCode.Escape) && paused == false) {
			//paused = true;
			//Time.timeScale = 0;
			SceneManager.LoadScene ("pause");
		}else{
			if (Input.GetKey (KeyCode.Escape) && paused == true) {
				SceneManager.LoadScene ("Nivel_1");
				//paused = false;
				//Time.timeScale = 1;
			}
		}*/

	}

	void Update (){

		ControlPersonaje ();
	}
}