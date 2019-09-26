using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCameraFollow : MonoBehaviour {

    public Portal portOwner;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Vector3 v3PlayerOffsetFromPortal = portOwner.player.transform.position - portOwner.portalLinked.transform.position;

        this.transform.position = portOwner.transform.position + v3PlayerOffsetFromPortal;

        float fAngularDifferenceBetweenPortals = Quaternion.Angle(portOwner.transform.rotation, portOwner.portalLinked.transform.rotation);

        Quaternion qPortalRotationDifference = Quaternion.AngleAxis(fAngularDifferenceBetweenPortals, Vector3.up);

        Vector3 v3NewCameraDirection = qPortalRotationDifference * portOwner.player.transform.forward;
        this.transform.rotation = Quaternion.LookRotation(v3NewCameraDirection, Vector3.up);
    }
}
