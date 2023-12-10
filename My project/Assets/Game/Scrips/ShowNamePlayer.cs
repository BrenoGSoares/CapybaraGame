using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class ShowNamePlayer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        if(photonView.IsMine){
            GameObject.Find("nomeper").GetComponent<TextMeshProUGUI>().text = photonView.Owner.NickName;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
