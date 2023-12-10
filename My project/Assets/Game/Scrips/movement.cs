using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class movement : MonoBehaviour{
    
    public float velocidadeMovimento;
    public float forcaPulo;

    private Rigidbody2D rigbody2d;
    public SpriteRenderer spriteRenderer;

    public Transform detectorChao;
    public float raioDeteccao;
    public LayerMask layerChao;

    private bool pulando;
    private bool estaNoChao;

    public PhotonView photonView;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("nomeper").GetComponent<TextMeshProUGUI>().text = GameObject.Find("coletadados").GetComponent<dadosPersonagem>().nomejogador;
        rigbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine){
            Movepersonagem();
            Pular();
        }  
    }


    public bool EstaNoChao{
        get {
            return this.estaNoChao;
        }
    }

    [PunRPC]
    void Movepersonagem(){

        float horizontal = Input.GetAxis("Horizontal");
        Vector2 velocidade = this.rigbody2d.velocity;
        velocidade.x = horizontal * this.velocidadeMovimento;
        this.rigbody2d.velocity = velocidade;

        if (velocidade.x > 0){
            this.spriteRenderer.flipX = true;
        } else if (velocidade.x < 0){
            this.spriteRenderer.flipX = false;
        }
    }


    private void OnDrawinGizmos(){
        Gizmos.DrawWireSphere(this.detectorChao.position, this.raioDeteccao);
    }


    void Pular(){

        Collider2D collider = Physics2D.OverlapCircle(this.detectorChao.position, this.raioDeteccao, this.layerChao);
        
        if (collider != null){
            this.estaNoChao = true;
            this.pulando = false;
        } else {
            this.estaNoChao = false;
        }

        if (this.estaNoChao){
            if (Input.GetKeyDown(KeyCode.Space)){
                if (!this.pulando){
                    Vector2 forca = new Vector2(0, this.forcaPulo);
                    this.rigbody2d.AddForce(forca, ForceMode2D.Impulse);
                }
            }
        }

    }
}