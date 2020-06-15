using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class handTrackingTest : MonoBehaviour
{
    public ParticleSystem particleFinger;
	public OVRHand rightHand;
    public TextMesh textDebug;
    public bool isIndexFingerPinching;
    public float ringFingerPinchStrength;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        isIndexFingerPinching = rightHand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        ringFingerPinchStrength= rightHand.GetFingerPinchStrength(OVRHand.HandFinger.Ring);
        textDebug.text = $"indexFinxerPinchin bool = {isIndexFingerPinching} ringFingerStrength = {ringFingerPinchStrength}";
        if (isIndexFingerPinching == true)
        {
            particleFinger.emissionRate = 1000;
        }
        else
        {
            particleFinger.emissionRate = 0;

        }

    }
}
