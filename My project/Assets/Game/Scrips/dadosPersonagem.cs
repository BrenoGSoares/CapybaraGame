using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class dadosPersonagem : MonoBehaviourPunCallbacks
{
    public string personagem;
    public string nomejogador;
    private static dadosPersonagem instance = null;

    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

}
