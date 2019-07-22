using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    public float PlayerVelocity = 10;
    public float PlayervelocityLimit = 7;

    private Rigidbody2D PlayerRB;
    private Animator PlayerAnim;

    private void Start() {
        PlayerRB = this.GetComponent<Rigidbody2D>();
        PlayerAnim = this.GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(PlayerRB.velocity.x) < 1 || Mathf.Abs(PlayerRB.velocity.y) < 1)
        {
            PlayerAnim.SetBool("moving", false);
        }

        // Anda para a esquerda
        if (Input.GetButton("Left")) {

            // Caminhada para a esquerda
            PlayerAnim.SetBool("mirror", true);
            PlayerAnim.SetBool("moving", true);

            // Limita a velocidade
            if (PlayerRB.velocity.x > -PlayervelocityLimit) {
                PlayerRB.AddForce(PlayerVelocity * Vector2.left);
            }

        // Anda para a direita
        } else if (Input.GetButton("Right")) {

            // Caminhada para a direita
            PlayerAnim.SetBool("mirror", false);
            PlayerAnim.SetBool("moving", true);

            // Limita a velocidade
            if (PlayerRB.velocity.x < PlayervelocityLimit) {
                PlayerRB.AddForce(PlayerVelocity * Vector2.right);
            }

        }

        // Anda para a cima
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            
            // Está andando
            PlayerAnim.SetBool("moving", true);

            // Limita a velocidade
            if (PlayerRB.velocity.y > -PlayervelocityLimit)
            {
                PlayerRB.AddForce(PlayerVelocity * Vector2.up);
            }

        } else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            
            // Está andando
            PlayerAnim.SetBool("moving", true);

            // Limita a velocidade
            if (PlayerRB.velocity.y < PlayervelocityLimit)
            {
                PlayerRB.AddForce(PlayerVelocity * Vector2.down);
            }

            // Anda para a baixo

        }


    }
}
