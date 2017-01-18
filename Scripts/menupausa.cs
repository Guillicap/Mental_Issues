using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class menupausa : MonoBehaviour {

	public Transform canvas;
	public Transform Player;


	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) { //Si es clica "ESC"
			Pause (); //Activa tota la funcio Void Pause
		}
	}

	public void Pause (){
		if (canvas.gameObject.activeInHierarchy == false) { //Si cliquem "ESC" i el canvas NO esta actiu a la Hierarchy
			canvas.gameObject.SetActive (true); //L'activa 
			Time.timeScale = 0; //Pausa tot el joc
			Player.GetComponent<Movimiento> ().enabled = false; //I pausa el Jugador (No es podra moure)
		} else { //Si tornem a clicar "ESC"
			canvas.gameObject.SetActive (false); //Desactiva el Canvas de la hierarchy
			Time.timeScale = 1; //Activa de nou el joc
			Player.GetComponent<Movimiento> ().enabled = true; //Activa un altre cop al personatge
		}
	}

	public void CargaEscenas(string pNombreNivel){ //Es el que ens permetra dir quina escena volem carregar en els botons del menu dins del Canvas
		SceneManager.LoadScene (pNombreNivel); //Des del boto, en el Inspector, hauriem de triar la opcio que ens permet escollir per nom quina escena volem carregar
		Time.timeScale = 1;
	}
}
