// Script à compléter
//Script de base du lapin bleu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class LapinBleu : MonoBehaviour {

	/*////////////////////////////////////////////////////////////////////////////////////
	//Variables privées
	///////////////////////////////////////////////////////////////////////////////////*/
	Animator lapinAnim; // référence au composant Animator du lapin
	Rigidbody lapinRigid; // référence au composant Rigidbody du lapin
	bool marche; // permet de savoir si le lapin marche ou non
	bool saute; // permet de savoir si le lapin est en saut
	bool auSol = true; // permet de savoir si le lapin est au sol
	int decompteAuSol; // permet de régler un bogue si le sol n'est pas détecté lors du saut du lapin

	/*////////////////////////////////////////////////////////////////////////////////////
	//Variables publiques
	///////////////////////////////////////////////////////////////////////////////////*/
	public float vitesse; // permet de changer la vitesse de déplacement du lapin
	public float vitesseTourne; // permet de changer la vitesse de rotation du lapin
	public float forceSaut;  // permet de changer la vélocityé du saut
    public int monPointage = 0;



	/*////////////////////////////////////////////////////////////////////////////////////*/
	void Start () {
		lapinAnim = GetComponent<Animator>();
		lapinRigid = GetComponent<Rigidbody>();
	}
	/*////////////////////////////////////////////////////////////////////////////////////*/


	/*////////////////////////////////////////////////////////////////////////////////////*/
	//Détection des touches du claviers pour tourner, avancer et sauter. Les vélocités sont modifiées dans le FixedUpdate
	void Update () {

		transform.Rotate(0,Input.GetAxis("Horizontal")*vitesseTourne,0);
		if(Input.GetAxisRaw("Vertical")!=0f)
		{
			marche = true;
			lapinAnim.SetBool("marche",true);
			lapinAnim.SetFloat("direction",Input.GetAxisRaw("Vertical"));

		}
		else
		{
			marche = false;
			lapinAnim.SetBool("marche",false);
		}

		if(Input.GetButtonDown("Jump"))
		{
			RaycastHit objetTouche;
			Vector3 vecteurAjuste = transform.position + new Vector3 (0f, 0.3f, 0f);
			if(Physics.Raycast(vecteurAjuste, -transform.up, out objetTouche,0.5f))
			{
				lapinAnim.SetTrigger("saute");
				auSol = false;
				lapinAnim.SetBool("auSol",false);
				saute = true;
			}
		}
	}
	/*////////////////////////////////////////////////////////////////////////////////////*/


	/*////////////////////////////////////////////////////////////////////////////////////*/
	// Changement des vélocités du lapin pour la marche et le saut.
	void FixedUpdate()
	{

		if(marche && auSol )
		{

			var velociteDeplacement = transform.forward*vitesse*Input.GetAxisRaw("Vertical");
			Vector3 velociteLapin = new Vector3 (velociteDeplacement.x, lapinRigid.velocity.y, velociteDeplacement.z);
			lapinRigid.velocity = velociteLapin;
		}
		if(saute)
		{
			saute = false;
			StartCoroutine (GestionSaut ());
		}
		lapinAnim.SetFloat("velociteY",lapinRigid.velocity.y);
	}
	/*////////////////////////////////////////////////////////////////////////////////////*/



	/*////////////////////////////////////////////////////////////////////////////////////*/
	// Gestion du Saut du personnage
	IEnumerator GestionSaut()
	{
		yield return new WaitForSeconds(0.2f);
		var velociteDeplacement = transform.forward*vitesse*Input.GetAxisRaw("Vertical");
		velociteDeplacement.y = forceSaut;
		lapinRigid.velocity = velociteDeplacement;
		decompteAuSol = 0;
		InvokeRepeating("DetectionSol",0.5f,0.1f); // Appel en boucle d'une fonction pour détecter le sol. On attend 0.5 secondes pour laisser le temps au lapin de sauter.
	}
	/*////////////////////////////////////////////////////////////////////////////////////*/



	/*////////////////////////////////////////////////////////////////////////////////////*/
	// Détection du sol après le saut du lapin
	void DetectionSol()
	{
		decompteAuSol++;
		RaycastHit objetTouche;
		//if(Physics.Raycast(transform.position+ Vector3(0,0.2,0), -transform.up, objetTouche,0.5))
		Vector3 vecteurAjuste = transform.position + new Vector3(0f,0.2f,0f);
		if(Physics.SphereCast(vecteurAjuste,0.1f,-transform.up, out objetTouche,0.5f)|| decompteAuSol==20)
		{
			auSol = true;
			lapinAnim.SetBool("auSol",true);
			CancelInvoke();
		}
	}
	/*////////////////////////////////////////////////////////////////////////////////////*/



	/*////////////////////////////////////////////////////////////////////////////////////*/
	/// Détection de collision avec les carottes
	void OnCollisionEnter(Collision infoCollision)
	{

		if(infoCollision.gameObject.name == "Carotte(Clone)")
		{
            monPointage += 1;
            Transform enfant = infoCollision.gameObject.transform.GetChild(0); // Activation du système de particule (premier enfant de la carotte)
			enfant.gameObject.SetActive(true);
			enfant.transform.parent=null; //on déparente la particule
			Destroy(infoCollision.gameObject); // destruction de la carotte
		}
	}
    /*////////////////////////////////////////////////////////////////////////////////////*/

    /*////////////////////////////////////////////////////////////////////////////////////*/
    // Pleure
    IEnumerator Pleure()
    {
        monPointage -= 5;
        vitesse = 0;
        vitesseTourne = 0;
        forceSaut = 0;
        lapinAnim.SetBool("Pleure", true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(5f);
        lapinAnim.SetBool("Pleure", false);
        vitesse = 2;
        vitesseTourne = 2;
        forceSaut = 8;
    }
    /*////////////////////////////////////////////////////////////////////////////////////*/
}
