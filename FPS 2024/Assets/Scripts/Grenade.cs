using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Grenade : MonoBehaviourPun
{
    [PunRPC]
    void Initialize(Vector3 throwForce)
    {
        GetComponent<Rigidbody>().AddForce(throwForce, ForceMode.Impulse);

        Destroy(gameObject, 10);
    }
}
