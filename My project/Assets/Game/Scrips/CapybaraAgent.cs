using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class CapybaraAgent : Agent
{
    Rigidbody2D rBody;
    public float velocidadeMovimento;
    public float forcaPulo;

    public SpriteRenderer spriteRenderer;

    public Transform detectorChao;
    public float raioDeteccao;
    public LayerMask layerChao;

    private bool pulando;
    private bool estaNoChao;
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }
    public Transform TargetTransform;
    public Transform InitTransform;
    public override void OnEpisodeBegin()
    {
        if (this.transform.localPosition.y < -100)
        {
            this.rBody.angularVelocity = 0.0f;
            this.rBody.velocity = Vector2.zero;
            this.transform.localPosition = this.InitTransform.localPosition;
        }
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(TargetTransform.localPosition);
        sensor.AddObservation(this.transform.localPosition);
        sensor.AddObservation(rBody.velocity.x);
        sensor.AddObservation(rBody.velocity.y);
    }

    public bool EstaNoChao
    {
        get
        {
            return this.estaNoChao;
        }
    }


    void Movepersonagem(float horizontal)
    {

        Vector2 velocidade = this.rBody.velocity;
        velocidade.x = horizontal * this.velocidadeMovimento;
        this.rBody.velocity = velocidade;

        if (velocidade.x > 0)
        {
            this.spriteRenderer.flipX = true;
        }
        else if (velocidade.x < 0)
        {
            this.spriteRenderer.flipX = false;
        }
    }


    void Pular()
    {

        Collider2D collider = Physics2D.OverlapCircle(this.detectorChao.position, this.raioDeteccao, this.layerChao);

        if (collider != null)
        {
            this.estaNoChao = true;
            this.pulando = false;
        }
        else
        {
            this.estaNoChao = false;
        }

        if (this.estaNoChao)
        {
            if (!this.pulando)
            {
                Vector2 forca = new Vector2(0, this.forcaPulo);
                this.rBody.AddForce(forca, ForceMode2D.Impulse);
            }
        }

    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        int inp_direction = actions.DiscreteActions[0];
        float horizontal = 0;
        if (inp_direction == 0)
        {
            horizontal = 0;
        }
        else if (inp_direction == 1)
        {
            horizontal = 1.0f;
        }
        else if (inp_direction == 2)
        {
            horizontal = -1.0f;
        }
        int inp_pular = actions.DiscreteActions[1];
        bool pular = inp_pular > 0 ? true : false;
        Movepersonagem(horizontal);
        if (pular == true)
        {
            Pular();
        }
        float distancia_ao_objetivo = Vector3.Distance(this.transform.localPosition, TargetTransform.localPosition);
        if (distancia_ao_objetivo < 1.42f)
        {
            SetReward(10000.0f);
            EndEpisode();
        }
        else if (distancia_ao_objetivo >= 1.42f)
        {
            SetReward(-0.01f*distancia_ao_objetivo);
        }
        else if (this.transform.localPosition.y < 100)
        {
            EndEpisode();
        }
    }
}
