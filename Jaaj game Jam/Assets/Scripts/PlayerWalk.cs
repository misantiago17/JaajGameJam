using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    public float PlayerVelocity = 10;
    public float PlayervelocityLimit = 7;

    private Rigidbody2D PlayerRB;

    private void Start() {
        PlayerRB = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Anda para a esquerda
        if (Input.GetKey(KeyCode.A)) {

            // Limita a velocidade
            if (PlayerRB.velocity.x > -PlayervelocityLimit) {
                PlayerRB.AddForce(PlayerVelocity * Vector2.left);
            }

        // Anda para a direita
        } else if (Input.GetKey(KeyCode.D)) {

            // Limita a velocidade
            if (PlayerRB.velocity.x < PlayervelocityLimit) {
                PlayerRB.AddForce(PlayerVelocity * Vector2.right);
            }

        }


    }
}
