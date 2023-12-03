using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pegaNomeAvatar : MonoBehaviour
{
    public Button jogar;
    public Button dino;
    public Button capi;
    public string player;
    public string playerName;
    // Start is called before the first frame update
    void Start()
    {
        jogar.interactable = false;
    }

    public void selecioneAvatar(string i)
    {
        // print(i);
        player = i;
        // print(player)
        // playerName = ;
        // aqui eu tenho que salvar qual avatar foi clicado
    }


    public void selecionaName(string name)
    {
        playerName = name;
        print(playerName);
        jogar.interactable = true;

        //     // Application.LoadLevel();
        //     print(player);
        //     print("vou mudar de cena");
        // }
    }
}
