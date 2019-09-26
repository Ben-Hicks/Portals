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

        //Think about making the third parameter a cross product
        float fAngularDifferenceBetweenPortals = Vector3.SignedAngle(portOwner.transform.forward, portOwner.portalLinked.transform.forward, Vector3.up);
        float fRecip = Vector3.SignedAngle(portOwner.portalLinked.transform.forward, portOwner.transform.forward, Vector3.up);

       
        Debug.Log(fAngularDifferenceBetweenPortals + " " + fRecip);

        Quaternion qPortalRotationDifference = Quaternion.AngleAxis(fAngularDifferenceBetweenPortals, Vector3.up);
        Quaternion qPortalRotationRecip = Quaternion.AngleAxis(fRecip, Vector3.up);

        Vector3 v3NewCameraDirection = qPortalRotationRecip * portOwner.player.transform.forward;

        v3PlayerOffsetFromPortal = qPortalRotationRecip * -v3PlayerOffsetFromPortal;
        this.transform.position = portOwner.transform.position + v3PlayerOffsetFromPortal;

        this.transform.rotation = Quaternion.LookRotation(-v3NewCameraDirection, Vector3.up);
    }
}
