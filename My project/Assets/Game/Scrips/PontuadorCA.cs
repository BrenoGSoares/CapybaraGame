using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PontuadorCA : MonoBehaviour
{
    public TextMeshProUGUI ScoreTxt, TimeTxt;
    
    public PhotonView photonView;
    
    private int score;
    private float tgame;
    private bool EndTime;

    void Start()
    {
        score = 0;
        EndTime = false;
        tgame = 250;
        ScoreTxt.text     = "Pontuação: "+score.ToString();
        AtualizaTempo();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!EndTime){
            if (col.CompareTag("CA1"))
            {
                score += 2;
                Destroy(col.gameObject);
                //print(score);
                ScoreTxt.text     = "Pontuação: "+score.ToString();
            }
            if (col.CompareTag("CA2"))
            {
                score += 4;
                Destroy(col.gameObject);
                //print(score);
                ScoreTxt.text     = "Pontuação: "+score.ToString();
            }
            if (col.CompareTag("CA3"))
            {
                score += 6;
                Destroy(col.gameObject);
                //print(score);
                ScoreTxt.text     = "Pontuação: "+score.ToString();
            }
            if (col.CompareTag("CA4"))
            {
                score += 10;
                Destroy(col.gameObject);
                //print(score);
                ScoreTxt.text     = "Pontuação: "+score.ToString();
            }
            if (col.CompareTag("FIM")){
                print("FIM");
                FimContagem();
                
            }
        }
    }
    void AtualizaTempo()
    {
        TimeTxt.text = "Tempo: "+ ((int)tgame).ToString();
    }
    void ContaTempo()
    {
        //EndTime = false;
        if (!EndTime&& tgame >0){//
            tgame -= Time.deltaTime;
            AtualizaTempo();
            if (tgame<=0){
                FimContagem();
            }
            
        }
    }

    void FimContagem(){
        EndTime = true;
        score += (int)tgame *2;
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("Tempo", (int)tgame);
        ScoreTxt.text     = "Pontuação: "+score.ToString();
    }
    void Update()
    {
        ContaTempo();
    }
    

}
