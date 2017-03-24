using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class EstadoJuego : MonoBehaviour {

	public int puntuacionMaxima = 0;
	public static EstadoJuego estadoJuego;
	private String rutaArchivo;

	void Awake(){
		rutaArchivo = Application.persistentDataPath + "/datos.dat";
		if (estadoJuego == null) {
			estadoJuego = this;
			DontDestroyOnLoad (gameObject);
		} else if (estadoJuego != this) {
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		Cargar ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Cargar(){
		if(File.Exists (rutaArchivo)){
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (rutaArchivo, FileMode.Open); //abrir
			DatosAGuardar datos = (DatosAGuardar)bf.Deserialize (file);
			puntuacionMaxima = datos.puntuacionMaxima;
			file.Close ();
		}else{
			puntuacionMaxima = 0;
		}
	}

	public void Guardar(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (rutaArchivo); //crear
		DatosAGuardar datos = new DatosAGuardar ();
		datos.puntuacionMaxima = puntuacionMaxima;
		bf.Serialize (file, datos); //esto guarda (escribe)
		file.Close ();
	}
}//EstadoJuego

[Serializable]
class DatosAGuardar {
	public int puntuacionMaxima;
}
