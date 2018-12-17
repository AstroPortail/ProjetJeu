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
        //ChangementScenePortail.leNomDuJoueur = "Kim";
        //ControlerPersonnage.NiveauOxygene=10;

        PlayerPrefs.DeleteKey("FichierScores"); //Effacer les données précédemment enregistrées
        PlayerPrefs.DeleteKey("FichierNoms"); //Effacer les données précédemment enregistrées

        bool infoExisteDeja = PlayerPrefs.HasKey("FichierNoms"); //Regarde si valeurs présentes
        //si valeurs trouvées on affiche 
        if (infoExisteDeja == true)
        {
            //lecture des données 
            tableauValeursScore = PlayerPrefsX.GetFloatArray("FichierScores");
            tableauNoms = PlayerPrefsX.GetStringArray("FichierNoms");
           
        }

        tableauNoms[3] = ChangementScenePortail.leNomDuJoueur;

        tableauValeursScore[3] =  ControlerPersonnage.NiveauOxygene;
        //listeScores.text = tableauValeursScore[0].ToString();

        //Trier le tableau selon le score 
        System.Array.Sort(tableauValeursScore, tableauNoms);
        System.Array.Reverse(tableauValeursScore); // 
        System.Array.Reverse(tableauNoms); //

        AfficherElements();
        //Écriture des données  
        PlayerPrefsX.SetFloatArray("FichierScores", tableauValeursScore);
        PlayerPrefsX.SetStringArray("FichierNoms", tableauNoms);
    }
	

    public void AfficherElements()
    {
       //Cumuler la liste des scores dans une boucle
        string chaineScore = "";
        string chaineNoms = "";

        for (int i = 0; i<3; i++)
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

 
