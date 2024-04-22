using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Microsoft;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;

public class HandTracking : MonoBehaviour
{
    public GameObject sphereMarker;

    MixedRealityPose pose;

    GameObject thumbObject;
    GameObject indexObject;
    GameObject middleObject;
    GameObject ringObject;
    GameObject pinkyObject;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hand tracking is called");
        thumbObject = Instantiate(sphereMarker, this.transform);
        indexObject = Instantiate(sphereMarker, this.transform);
        middleObject = Instantiate(sphereMarker, this.transform);
        ringObject = Instantiate(sphereMarker, this.transform);
        pinkyObject = Instantiate(sphereMarker, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        thumbObject.GetComponent<Renderer>().enabled = false;
        indexObject.GetComponent<Renderer>().enabled = false;
        middleObject.GetComponent<Renderer>().enabled = false;
        ringObject.GetComponent<Renderer>().enabled = false;
        pinkyObject.GetComponent<Renderer>().enabled = false;

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbTip, Handedness.Right, out pose))
        {
            thumbObject.GetComponent<Renderer>().enabled = true;
            thumbObject.transform.position = pose.Position;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out pose))
        {
            indexObject.GetComponent<Renderer>().enabled = true;
            indexObject.transform.position = pose.Position;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.MiddleTip, Handedness.Right, out pose))
        {
            middleObject.GetComponent<Renderer>().enabled = true;
            middleObject.transform.position = pose.Position;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.RingTip, Handedness.Right, out pose))
        {
            ringObject.GetComponent<Renderer>().enabled = true;
            ringObject.transform.position = pose.Position;
        }

        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.PinkyTip, Handedness.Right, out pose))
        {
            pinkyObject.GetComponent<Renderer>().enabled = true;
            pinkyObject.transform.position = pose.Position;
        }

    }
}
