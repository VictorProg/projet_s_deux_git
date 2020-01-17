using UnityEngine;

public class player_movement : MonoBehaviour
{
    public CharacterController character;
    public float speed = 12f;
    void Update()
    {
        float x = Input.GetAxis("Horizontal"); //récupérer l'orientation verticale de la caméra
        float z = Input.GetAxis("Vertical"); //récupérer l'orientation horizontale de la caméra

        //déterminer dans quelle direction se déplacer
        Vector3 move = transform.right * x + transform.forward * z;

        //se déplacer
        character.Move(move * speed * Time.deltaTime);
    }
}
