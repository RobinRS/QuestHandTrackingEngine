using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class HandTrackingGrabber : OVRGrabber
{
    private Hand hand;
    public float pinchThreshold = 0.7f;

    protected override void Start()
    {
        base.Start();
        hand = GetComponent<Hand>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        CheckPinch();
    }

    void CheckPinch()
    {
        float pinchStrength = hand.PinchStrength(OVRPlugin.HandFinger.Index);
        bool isPinch = pinchStrength > pinchThreshold;
        Debug.Log(isPinch);
        if (!m_grabbedObj && isPinch && m_grabCandidates.Count > 0)
            GrabBegin();
        else if (m_grabbedObj && !isPinch)
            GrabEnd();
    }
}
