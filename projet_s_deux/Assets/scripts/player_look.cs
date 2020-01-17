using UnityEngine;

public class player_look : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform player;
    float lookUpAndDown = 0f;
    float gravity = 4.19f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //récuperer positions sourie
        float viewX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float viewY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        //regarder gauche droite
        player.Rotate(Vector3.up * viewX); 
        
        //regarder haut bas
        lookUpAndDown -= viewY; //définir l'angle de mouvement caméra
        lookUpAndDown = Mathf.Clamp(lookUpAndDown, -90f, 90); //vérouiller vision verticale entre 90° et -90° (position de départ : 0°)
        transform.localRotation = Quaternion.Euler(lookUpAndDown, 0f, 0f); //tourner la caméra verticalement de lookUpAndDown°

        //appliquer la gravité au joueur


        
    }
}
