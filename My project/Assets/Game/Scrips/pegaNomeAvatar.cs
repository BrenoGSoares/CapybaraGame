using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class pegaNomeAvatar : MonoBehaviour
{
    public Button jogar;
    public Button dino;
    public Button capi;
    public Text nome;

    // Start is called before the first frame update
    void Start()
    {
     jogar.interactable = false;   
    }

    public void selecioneAvatar(int i){
        // aqui eu tenho que salvar qual avatar foi clicado
        
    // public void selecionePlayer(string nome){
    //     if(nome == "capi"){
    //         player = "capi";
    //     }else{
    //         if(nome == "dino"){
    //             player ="dino";
    //         }
    //     }
    // }

    // public void jogar(){
    //     // Application.LoadLevel();
    //     print(player);
    //     print("vou mudar de cena");
    // }
    }
}
