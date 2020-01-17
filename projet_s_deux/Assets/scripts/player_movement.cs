using UnityEngine;

public class player_movement : MonoBehaviour
{
    public CharacterController character;
    public float speed = 12f;
    float gravity = -10f;
    public Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    bool grounded;
    void Update()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (grounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal"); //récupérer l'orientation verticale de la caméra
        float z = Input.GetAxis("Vertical"); //récupérer l'orientation horizontale de la caméra

        //déterminer dans quelle direction se déplacer
        Vector3 move = transform.right * x + transform.forward * z;

        //se déplacer
        character.Move(move * speed * Time.deltaTime);

        //appliquer la gravité
        velocity.y += gravity * Time.deltaTime;

        character.Move(velocity * Time.deltaTime);
    }
}
