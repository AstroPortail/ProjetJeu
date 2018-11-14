using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableauScores : MonoBehaviour {

    public string[] tableauNoms = new string[4]; //Création du tableau des noms
    public int[] tableauValeursScore = new int[4]; //Création du tableau des valeurs

    public Text listeNoms; // Text pour la liste des noms
    public Text listeScores; //Text pour la liste des scores
    //variable à transformer en % NiveauOxygene

    

    void Start () {
      ChangementScenePortail.champNomJoueur.text="Kim";
      ControlerPersonnage.NiveauOxygene=10;




		
	}
	
	
	void Update () {
		
	}

}

 
