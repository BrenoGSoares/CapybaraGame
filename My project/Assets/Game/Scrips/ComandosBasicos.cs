using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ComandosBasicos : MonoBehaviour
{
    public void carregaCena(string nomeCena)
    {
        Application.LoadLevel(nomeCena);
    }
}