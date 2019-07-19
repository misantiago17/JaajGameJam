using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteSwap : MonoBehaviour
{
    [Tooltip("Ponha como 'Size' o número de estados diferentes que o objeto terá. Considere o primeiro como o sprite inicial")]
    public Sprite[] stateSprites;
    
    private int index = 0;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = stateSprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire1")) //ao clique esquerdo do mouse
        {
            //incremento feito no início já que o primeiro estado já estará visível
            index++;
            
            // deve reiniciar index caso tenha chegado no final do array
            if (index > stateSprites.Length - 1) { index = 0; } 

            // Troca sprite para o seguinte
            spriteRenderer.sprite = stateSprites[index];
        }
    }
}
