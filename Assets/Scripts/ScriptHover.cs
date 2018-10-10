using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//SCRIPT NON FONCTI0NNEL AVEC MES ÉTOILES, FONCTIONNE AVEC D'AUTRES FORMES SIMPLES PAR CONTRE
//Je voulais le mettre et il ne fonctionnait pas, je voulais tout de même vous montrer que j'avais essayé
//Je voulais qu'une de mes difficultés soit que le personnage doit passer sa souris sur l'étoile pour voir la couleur.

public class ScriptHover : MonoBehaviour
{

    public Color basicColor; // on établie la couleur 
    public Color hoverColor;

    private Renderer render;


    void Start()
    {
        render = GetComponent<Renderer>(); // aller chercher le component
        render.material.color = basicColor; // attribuer la couleur de base a l'étoile
    }



    void OnMouseEnter()

    {
        
            render.material.color = hoverColor;
        
    }

    private void OnMouseExit()
    {
        
            render.material.color = basicColor;
    }




}

