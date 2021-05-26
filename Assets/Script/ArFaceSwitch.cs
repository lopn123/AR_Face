using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ArFaceSwitch : MonoBehaviour
{
    [SerializeField] private Material[] materials;

    private ARFaceManager arFaceManager;
    private int switchCount;

    // Start is called before the first frame update
    void Start()
    {
        arFaceManager = GetComponent<ARFaceManager>();
        arFaceManager.facePrefab.GetComponent<MeshRenderer>().material = materials[0];
        switchCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            SwitchFace();
        }
        
    }

    private void SwitchFace()
    {
        foreach(ARFace face in arFaceManager.trackables)
        {
            face.GetComponent<MeshRenderer>().material = materials[switchCount];
            switchCount = (switchCount + 1) % materials.Length;
        }
    }
}
