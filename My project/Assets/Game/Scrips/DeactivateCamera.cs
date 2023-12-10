using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DeactivateCamera : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        if(!photonView.IsMine){
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
