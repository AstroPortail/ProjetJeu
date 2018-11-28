using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableauScores : MonoBehaviour {

    public string[] tableauNoms = new string[4]; //Création du tableau des noms
    public float[] tableauValeursScore = new float[4]; //Création du tableau des valeurs

    public Text listeNoms; // Text pour la liste des noms
    public Text listeScores; //Text pour la liste des scores
    //variable à transformer en % NiveauOxygene

    

    void Start () {
        //ChangementScenePortail.champNomJoueur.text="Kim";
        //ControlerPersonnage.NiveauOxygene=10;
        tableauNoms[3] = ChangementScenePortail.leNomDuJoueur;

        tableauValeursScore[3] =  ControlerPersonnage.NiveauOxygene;
        //listeScores.text = tableauValeursScore[0].ToString();

        //Trier le tableau selon le score 
        System.Array.Sort(tableauValeursScore, tableauNoms);
        System.Array.Reverse(tableauValeursScore); // 
        System.Array.Reverse(tableauNoms); //

        AfficherElements();
    }
	

    public void AfficherElements()
    {
       //Cumuler la liste des scores dans une boucle
        string chaineScore = "";
        string chaineNoms = "";

        for (int i = 0; i<4; i++)
        {
            chaineScore += tableauValeursScore[i] + "%" + "\n";
            chaineNoms += tableauNoms[i] + "\n";
            print(chaineScore);
            print(chaineNoms);
        }

        //afficher la chaîne des noms et la chaine des scores
        listeNoms.text = chaineNoms;
        listeScores.text = chaineScore;
       
    }

}

 
