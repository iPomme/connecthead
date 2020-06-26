using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGestures : MonoBehaviour
{
    public Collider colliderThumb;
    public Collider colliderIndex;
    public Collider colliderMiddle;
    public Collider colliderPinky;

    public Collider colliderInsidePalm;
    public Collider colliderStopSign;

    public TextMesh confidenceTxt;
    public TextMesh trackingStatus;
    public TextMesh poseTxt;

    private OVRHand rightHand;

    private string detectedPose;

    // Start is called before the first frame update
    void Start()
    {
        rightHand = GetComponent<OVRHand>();
    }

    // Update is called once per frame
    void Update()
    {
        detectedPose = "none";

        trackingStatus.text = "tracking status = " + rightHand.IsTracked.ToString();
        confidenceTxt.text = "confidence = " + rightHand.HandConfidence.ToString();
        
        poseTxt.text = "Pose = " + detectedPose;

    }
}
