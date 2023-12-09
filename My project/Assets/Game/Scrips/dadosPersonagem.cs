using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dadosPersonagem : MonoBehaviour
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
