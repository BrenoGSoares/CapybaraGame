using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationPlayerDino : MonoBehaviour
{

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private Rigidbody2D rigidbody2d;

    [SerializeField]
    private movementDino jogador;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.jogador.EstaNoChao){
            float velocidadeX = Mathf.Abs(this.rigidbody2d.velocity.x);
            if (velocidadeX > 0){
                this.animator.SetBool("correndoEstado", true);
            } else {
                this.animator.SetBool("correndoEstado", false);
            }
        } else {
            float velocidadeY = this.rigidbody2d.velocity.y;
            if (velocidadeY > 2){
                this.animator.SetBool("pulandoEstado", true);
            } else {
                this.animator.SetBool("pulandoEstado", false);
            }
            
        }
        
    }
}
