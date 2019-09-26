using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public Portal portalLinked;
    public Camera cam;
    public Player player;
    public MeshRenderer mrPortal;

    public Material matStandardPortal;
    public Material mat;
    public RenderTexture rendTexture;

    public void Start() {

        if (cam.targetTexture != null) cam.targetTexture.Release();

        //Will have to change this if doing split screen
        rendTexture = new RenderTexture(Screen.width, Screen.height, 24);

        portalLinked.cam.targetTexture = rendTexture;

        mat = new Material(matStandardPortal);

        mat.mainTexture = rendTexture;

        Debug.Log(mat.shader);

        mrPortal.material = mat;

    }
}
