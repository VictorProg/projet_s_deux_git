using UnityEngine;

public class player_movement : MonoBehaviour
{
    public CharacterController characterController;
    float run = 10f;
    float sprint = 50f ;
    float walk = 1f;
    float movementspeed = 10f;
    float gravity = -20f;
    Vector3 fallspeed;
    float jumpHeight = 2f;

    public Transform groundCheck;
    float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool grounded;
    void Update()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask); //vrai si le joueur est en contact avec un objet de Layer "ground"

        //augmenter la vitesse de la chute
        if (grounded && fallspeed.y < 0)
        {
            fallspeed.y = -2f ;
        }

        //Appui des touches de déplacement
        float appuiGaucheDroite = Input.GetAxis("Horizontal"); //gauche/droite
        float appuiAvantArriere = Input.GetAxis("Vertical"); //avant/arrière 

        //déterminer comment se déplacer
        Vector3 move = transform.right * appuiGaucheDroite + transform.forward * appuiAvantArriere;

        //se déplacer
        characterController.Move(move * movementspeed * Time.deltaTime);

        //appliquer la gravité
        fallspeed.y += gravity * Time.deltaTime;
        characterController.Move(fallspeed * Time.deltaTime);

        //sauter
        if (Input.GetKeyDown("space") && grounded)
        {
            fallspeed.y = Mathf.Sqrt(jumpHeight * -1f * gravity);
        }

        //rétablir vitesse normale (run)
        if (Input.GetKeyUp("x") || Input.GetKeyUp("c"))
        {
            movementspeed = run;
        }

        //courir
        if (Input.GetKeyDown("x") && appuiAvantArriere > 0)
        {
            movementspeed = sprint;
        }

        //marcher
        if (Input.GetKeyDown("c"))
        {
            movementspeed = walk;
        }

        
    }
}
