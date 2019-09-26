using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portable : MonoBehaviour {

    public const float fminTeleTime = 0.1f;
    float fTimeSinceTele = 0f;

    public void TeleportTo(Portal destination) {

        if (fTimeSinceTele < fminTeleTime) return;

        Debug.Log("Teleporting");

        this.transform.position = destination.transform.position;

    }

    public void Update() {
        fTimeSinceTele += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {

        Debug.Log("Found a trigger");

        Portal entrance = other.GetComponent<Portal>();

        if (entrance == null) return;

        TeleportTo(entrance.portalLinked);



    }


}
