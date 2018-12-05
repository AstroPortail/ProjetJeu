using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ControlerPersonnage : MonoBehaviour
{

    // GESTION PERSONNAGE--------------------------------------------------------
    Rigidbody rbPerso; // va chercher le rigid du perso
    Animator animPerso; // va chercher l'anim du perso

    public float vitesseRotation; //la vitesse de rotation du perso
    public float vitesseDeplacement = 10f; // la vitesse de déplacement du perso

    public float vDeplacement; // la vitesse de déplacement du personnage
    public float vitesseSaut = 6; // hauteur de saut

    public bool auSol; //pour qu'on regarde si le perso est au sol ou non

    /* -------- Variable pour les objets dynamique ------------------- */
    public static float nombrePiece;
    public static bool cadeauRamasse = false;
    public static bool citrouilleRamasse = false;
    public static bool champiRamasse = false;
    public static float NiveauOxygene = 100f;
    public static float NiveauVie = 100f;
    public static bool estMort = false;
    public Text textNombrePiece;
    public Image imageBarreVie;
    public Image imageBarreOxy;
    public GameObject imageCadeau;
    public GameObject imageCitrouille;
    public GameObject imageChampi;

    public GameObject[] lesEnnemis;

    public GameObject panneauOxygene;
    public GameObject panneauVie;
    public GameObject panneauTouche;

    //Pour avoir du son
    AudioSource audioSource;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        rbPerso = GetComponent<Rigidbody>();
        animPerso = GetComponent<Animator>();

        //chercher le son
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        //print("niveauVie=" + NiveauVie);
        //print("niveauVie=" + NiveauOxygene);
        //------------- GESTION DU PERSONNAGE ---------------------//
        if (GestionCamera.pause == false) {
            // ----------- ON VÉRIFIE SI LE PERSO EST MORT ------------ //
            verifierSiEnVie();

            //----------- ON APPEL LA GESTION DES OBJETS ----------------//
            gestionObjetsInteractifs();
            //------------ APPEL DE LA GESTION DES BARRES DE VIE ET OXYGENE ------------------// 
            GestionOxygene();
            GestionVie();

          //  transform.Rotate(0, Input.GetAxis("Horizontal"), 0); // la rotation sur l'axe horizontal

            vDeplacement = Input.GetAxis("Vertical") * vitesseDeplacement; // vitesse de déplacement sur l'axe verticale

            rbPerso.velocity = (transform.forward * vDeplacement) + new Vector3(0, rbPerso.velocity.y, 0); // on fait avancer notre perso

            // si le perso est au sol, il peut sauter
        if (Input.GetKeyDown(KeyCode.Space) && auSol == true)
        {
            rbPerso.velocity += new Vector3(0, vitesseSaut, 0); // déclare la variable du saut pour l'attribuer dans l'Inspecteur

        }
        // on apelle l'animation 
        AnimerPerso();

       
        }
        else
        {
            animPerso.SetFloat("vitesseDep", 0); // le personnage en pause

            //les ennemis en pause
           /* var lesEnnemisAbres = GameObject.FindGameObjectsWithTag("ennemiArbre");
            var ennLenghtArbre = lesEnnemisAbres.Length;
            for (var i = 0; i < ennLenghtArbre; i++)
            {
                lesEnnemisAbres[i].GetComponent<NavMeshAgent>().enabled = false;
                lesEnnemisAbres[i].GetComponent<AI>().enabled = false;
            }

            var lesEnnemisAbeille = GameObject.FindGameObjectsWithTag("ennemiAbeille");
            var ennLenghtAbeille = lesEnnemisAbeille.Length;
            for (var i = 0; i < ennLenghtAbeille; i++)
            {
                lesEnnemisAbeille[i].GetComponent<NavMeshAgent>().enabled = false;
                lesEnnemisAbeille[i].GetComponent<AI>().enabled = false;
            }

            var lesEnnemisAraignee = GameObject.FindGameObjectsWithTag("ennemiAraignee");
            var ennLenghtAraignee = lesEnnemisAraignee.Length;
            for (var i = 0; i < ennLenghtAraignee; i++)
            {
                lesEnnemisAraignee[i].GetComponent<NavMeshAgent>().enabled = false;
                lesEnnemisAraignee[i].GetComponent<AI>().enabled = false;
            }*/

        }

    }// FIN DU UPDATE

    //-------------GESTION ANIMATION PERSONNAGE---------------------
    void AnimerPerso()
    {
        animPerso.SetFloat("vitesseDep", rbPerso.velocity.magnitude);
        RaycastHit infoCollision;
        auSol = Physics.SphereCast(transform.position + new Vector3(0, 0.5f, 0), 0.2f, -Vector3.up,
        out infoCollision, 0.8f); // on regarde si le personnage touche le sol
        //Si le personnage n'est pas au Sol alors l'animation saut doit jouer sinon elle arrête
        animPerso.SetBool("animSaut", !auSol);
    }

    //-------------Gestion de la détection de collision---------------------
    void OnCollisionEnter(Collision infoCollision)
    {

        if (infoCollision.gameObject.name == "tireBouchonAsset(Clone)" || infoCollision.gameObject.name == "mecaniqueAsset(Clone)")
        {
            nombrePiece += 1;
            Countdown.totalTime += 5f;
            GameObject son = GameObject.Find("sonPiece");
            son.GetComponent<AudioSource>().Play();
            Destroy(infoCollision.gameObject);
        }

        if (infoCollision.gameObject.name == "bombonneAsset(Clone)")
        {
            NiveauOxygene += 15;
            GameObject son = GameObject.Find("sonOxygene");
            son.GetComponent<AudioSource>().Play();
            Destroy(infoCollision.gameObject);
        }

        if (infoCollision.gameObject.name == "cadeauAsset")
        {
            cadeauRamasse = true;
            Countdown.totalTime += 15f;
            GameObject son = GameObject.Find("sonCadeau");
            son.GetComponent<AudioSource>().Play();
            Destroy(infoCollision.gameObject);
        }

        if (infoCollision.gameObject.name == "champisAsset")
        {
            champiRamasse = true;
            Countdown.totalTime += 15f;
            GameObject son = GameObject.Find("sonChampi");
            son.GetComponent<AudioSource>().Play();
            Destroy(infoCollision.gameObject);
        }

        if (infoCollision.gameObject.name == "citrouilleAsset")
        {
            citrouilleRamasse = true;
            Countdown.totalTime += 15f;
            GameObject son = GameObject.Find("sonCitrouille");
            son.GetComponent<AudioSource>().Play();
            Destroy(infoCollision.gameObject);
        }

        if (infoCollision.gameObject.name == "ennemiAbeille" || infoCollision.gameObject.name == "ennemiAraignee" || infoCollision.gameObject.name == "ennemiArbre")
        {
            panneauTouche.SetActive(true); // quand un ennemi touche le personne un panneau rouge dans l'écran du joueur s'active et a la fin de son animation se désactive
          //  Camera.main.gameObject.GetComponent<Animator>().enabled = true;
            //Wait for seconds pour desactiver le animator
            // Mettre les rotations de la cameras a 0 et jouer avec ceux du parents

            // vérifier quel type d'ennemis et baisser la vie en conséquence 
            if (infoCollision.gameObject.name == "ennemiAbeille")
            {
                NiveauVie -= 5;
                print("TOUCHE ABEILLE");
                print("Niveau vie " +NiveauVie);
            }

            // vérifier quel type d'ennemis et baisser la vie en conséquence 
            if (infoCollision.gameObject.name == "ennemiAraignee")
            {
                NiveauVie -= 20;
            }

            // vérifier quel type d'ennemis et baisser la vie en conséquence 
            if (infoCollision.gameObject.name == "ennemiArbre")
            {
                NiveauVie -= 35;

                print("toucheArbre");
            }

           // print("niveauVie = " + NiveauVie);
        }
    }

     void OnTriggerStay(Collider other)
    {
        if (GestionCamera.pause == false)
        {
            //print(" PAUSE == FALSE ?????????????????????????????");
            if (other.gameObject.name == "colliderAraignee")
            {
                // print("ENTRE");
                lesEnnemis =

                lesEnnemis = GameObject.FindGameObjectsWithTag("ennemiAraignee");
                var ennLenght = lesEnnemis.Length;
                for (var i = 0; i < ennLenght; i++)
                {
                    lesEnnemis[i].GetComponent<NavMeshAgent>().enabled = true;
                    lesEnnemis[i].GetComponent<AI>().enabled = true;
                }
            }

            if (other.gameObject.name == "colliderAbeille")
            {
                //print("ENTRE");
                lesEnnemis = GameObject.FindGameObjectsWithTag("ennemiAbeille");
                var ennLenght = lesEnnemis.Length;
                for (var i = 0; i < ennLenght; i++)
                {
                    lesEnnemis[i].GetComponent<NavMeshAgent>().enabled = true;
                    lesEnnemis[i].GetComponent<AI>().enabled = true;
                }
            }

            if (other.gameObject.name == "colliderArbre")
            {
                // print("ENTRE");
                lesEnnemis = GameObject.FindGameObjectsWithTag("ennemiArbre");
                var ennLenght = lesEnnemis.Length;
                for (var i = 0; i < ennLenght; i++)
                {
                    lesEnnemis[i].GetComponent<NavMeshAgent>().enabled = true;
                    lesEnnemis[i].GetComponent<AI>().enabled = true;
                }
            }
        }
        else
        {

          //  print(" PAUSE == TRUE !!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            //les ennemis en pause
            var lesEnnemisAbres = GameObject.FindGameObjectsWithTag("ennemiArbre");
            var ennLenghtArbre = lesEnnemisAbres.Length;
            for (var i = 0; i < ennLenghtArbre; i++)
            {
                lesEnnemisAbres[i].GetComponent<NavMeshAgent>().enabled = false;
                lesEnnemisAbres[i].GetComponent<AI>().enabled = false;
            }

            var lesEnnemisAbeille = GameObject.FindGameObjectsWithTag("ennemiAbeille");
            var ennLenghtAbeille = lesEnnemisAbeille.Length;
            for (var i = 0; i < ennLenghtAbeille; i++)
            {
                lesEnnemisAbeille[i].GetComponent<NavMeshAgent>().enabled = false;
                lesEnnemisAbeille[i].GetComponent<AI>().enabled = false;
            }

            var lesEnnemisAraignee = GameObject.FindGameObjectsWithTag("ennemiAraignee");
            var ennLenghtAraignee = lesEnnemisAraignee.Length;
            for (var i = 0; i < ennLenghtAraignee; i++)
            {
                lesEnnemisAraignee[i].GetComponent<NavMeshAgent>().enabled = false;
                lesEnnemisAraignee[i].GetComponent<AI>().enabled = false;
            }

        }
    }

    void OnTriggerEnter(Collider infoCollision)
    {
     
            if (infoCollision.gameObject.name == "colliderAraignee")
            {
               // print("ENTRE");
                lesEnnemis =

                lesEnnemis = GameObject.FindGameObjectsWithTag("ennemiAraignee");
                var ennLenght = lesEnnemis.Length;
                for (var i = 0; i < ennLenght; i++)
                {
                    lesEnnemis[i].GetComponent<NavMeshAgent>().enabled = true;
                    lesEnnemis[i].GetComponent<AI>().enabled = true;
                }
            }

            if (infoCollision.gameObject.name == "colliderAbeille")
            {
                //print("ENTRE");
                lesEnnemis = GameObject.FindGameObjectsWithTag("ennemiAbeille");
                var ennLenght = lesEnnemis.Length;
                for (var i = 0; i < ennLenght; i++)
                {
                    lesEnnemis[i].GetComponent<NavMeshAgent>().enabled = true;
                    lesEnnemis[i].GetComponent<AI>().enabled = true;
                }
            }

            if (infoCollision.gameObject.name == "colliderArbre")
            {
               // print("ENTRE");
                lesEnnemis = GameObject.FindGameObjectsWithTag("ennemiArbre");
                var ennLenght = lesEnnemis.Length;
                for (var i = 0; i < ennLenght; i++)
                {
                    lesEnnemis[i].GetComponent<NavMeshAgent>().enabled = true;
                    lesEnnemis[i].GetComponent<AI>().enabled = true;
                }
            }
        

    }

    void OnTriggerExit(Collider infoCollision)
    {
        if (infoCollision.gameObject.name == "colliderAraignee")
        {
            //print("SORT");
            lesEnnemis = GameObject.FindGameObjectsWithTag("ennemiAraignee");
            var ennLenght = lesEnnemis.Length;
            for (var i = 0; i < ennLenght; i++)
            {
                lesEnnemis[i].GetComponent<NavMeshAgent>().enabled = false;
                lesEnnemis[i].GetComponent<AI>().enabled = false;
            }
        }

        if (infoCollision.gameObject.name == "colliderAbeille")
        {
           // print("SORT");
            lesEnnemis = GameObject.FindGameObjectsWithTag("ennemiAbeille");
            var ennLenght = lesEnnemis.Length;
            for (var i = 0; i < ennLenght; i++)
            {
                lesEnnemis[i].GetComponent<NavMeshAgent>().enabled = false;
                lesEnnemis[i].GetComponent<AI>().enabled = false;
            }
        }

        if (infoCollision.gameObject.name == "colliderArbre")
        {
            // print("SORT");
            lesEnnemis = GameObject.FindGameObjectsWithTag("ennemiArbre");
            var ennLenght = lesEnnemis.Length;
            for (var i = 0; i < ennLenght; i++)
            {
                lesEnnemis[i].GetComponent<NavMeshAgent>().enabled = false;
                lesEnnemis[i].GetComponent<AI>().enabled = false;
            }
        }
    }

    void gestionObjetsInteractifs()
    {
        /*Changer le texte des pieces*/

        textNombrePiece.text = nombrePiece.ToString() + " / 12";

        /* changer le alpha des images si leur objets est rammassé*/
        if(cadeauRamasse == true)
        {
            imageCadeau.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        } else
        {
            imageCadeau.GetComponent<Image>().color = new Color32(255, 255, 255, 50);
        }

        if (champiRamasse == true)
        {
            imageChampi.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else
        {
            imageChampi.GetComponent<Image>().color = new Color32(255, 255, 255, 50);
        }

        if (citrouilleRamasse == true)
        {
            imageCitrouille.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else
        {
            imageCitrouille.GetComponent<Image>().color = new Color32(255, 255, 255, 50);
        }
    }

    public void GestionOxygene()
    {

        if (NiveauOxygene > 0)
        {
            NiveauOxygene -= 0.01f;
            imageBarreOxy.fillAmount = NiveauOxygene / 100f;

            if (NiveauOxygene < 15f) // si la panneau de l'oxygene est plus petit ou égal à 10 l'écran va flasher bleu
            {
               panneauOxygene.SetActive(true);
            }

        } else
        {
            estMort = true;
        }
    }

    public void GestionVie()
    {

        if (NiveauVie > 0)
        {
           // NiveauVie -= 0.01f;
            imageBarreVie.fillAmount = NiveauVie / 100f;


            if (NiveauVie < 15f) // si la panneau de l'oxygene est plus petit ou égal à 10 l'écran va flasher bleu
            {
                panneauVie.SetActive(true);
            }

        } else
        {
            estMort = true;
        }
    }

    public void verifierSiEnVie()
    {
        if(estMort == true)
        {
            SceneManager.LoadScene("SceneFin");
            estMort = false;

        }
    }


}// fin de la classe
