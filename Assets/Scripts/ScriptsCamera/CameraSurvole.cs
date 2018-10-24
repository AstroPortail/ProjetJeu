using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSurvole : MonoBehaviour {

    
    public float vitesseDeplacementCam = 0.5f;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() 
        {
            

            print(Screen.width); // 859/2=429.5
            print(Screen.height); // 483/2=241.5

            if (Input.mousePosition.x >= Screen.width / 2)
            {
                transform.position = new Vector3(transform.position.x + vitesseDeplacementCam, transform.position.y, transform.position.z);
            }

            if (Input.mousePosition.x <= Screen.width / 2)
            {
                transform.position = new Vector3(transform.position.x - vitesseDeplacementCam, transform.position.y, transform.position.z);
            }

            if (Input.mousePosition.y >= Screen.height / 2)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + vitesseDeplacementCam);
            }

            if (Input.mousePosition.y <= Screen.height / 2)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - vitesseDeplacementCam);
            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, 28, 70), transform.position.y, Mathf.Clamp(transform.position.z, 14,84));


        }
  }
