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
        if (Input.GetButton("Left")) {

            // Limita a velocidade
            if (PlayerRB.velocity.x > -PlayervelocityLimit) {
                PlayerRB.AddForce(PlayerVelocity * Vector2.left);
            }

        // Anda para a direita
        } else if (Input.GetButton("Right")) {

            // Limita a velocidade
            if (PlayerRB.velocity.x < PlayervelocityLimit) {
                PlayerRB.AddForce(PlayerVelocity * Vector2.right);
            }

        }

        // Anda para a cima
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {

            // Limita a velocidade
            if (PlayerRB.velocity.y > -PlayervelocityLimit)
            {
                PlayerRB.AddForce(PlayerVelocity * Vector2.up);
            }

            // Anda para a baixo
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {

            // Limita a velocidade
            if (PlayerRB.velocity.y < PlayervelocityLimit)
            {
                PlayerRB.AddForce(PlayerVelocity * Vector2.down);
            }

        }


    }
}
