using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class pegaNomeAvatar : MonoBehaviourPunCallbacks
{
    public Button jogar;
    public Button dino;
    public Button capi;
    public TextMeshProUGUI comptexto;
    public dadosPersonagem jogadorObject;
    public GameObject dinoUI, capiUI;
    // Start is called before the first frame update
    void Start()
    {
        jogar.interactable = false;
    }

    public void selecioneAvatar(string player)
    {
       
        if(player == "dino"){
            capiUI.SetActive(false);
            dinoUI.SetActive(true);
        }else{
            capiUI.SetActive(true);
            dinoUI.SetActive(false);
        }
        Debug.Log("Selecionou: " + player);
        jogadorObject.personagem = player;
    }

    public void selecionaName(string name)
    {
        Debug.Log("NOME: " + name);
        jogadorObject.nomejogador = comptexto.text;

        jogar.interactable = true;

        //     // Application.LoadLevel();
        //     print(player);
        //     print("vou mudar de cena");
        // }
    }
}
