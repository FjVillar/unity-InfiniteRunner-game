using UnityEngine;
using System.Collections;

public class PuntuacionBloque : MonoBehaviour {
	private bool haColisionadoConElJugador = false;
	public int puntosGanados = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision){
		//Debug.Log(collision.collider.gameObject.name);
		if ((collision.collider.gameObject.name == "PataInferiorDerechaB" || collision.collider.gameObject.name == "PataInferiorIzquierdaB") && !haColisionadoConElJugador ) {
			haColisionadoConElJugador = true;
			NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", puntosGanados );
		}
	}
}
