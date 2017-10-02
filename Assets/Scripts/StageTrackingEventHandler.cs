using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageTrackingEventHandler : Vuforia.DefaultTrackableEventHandler
{
    Vector3 startingPos;
    Renderer[] renderers;
    Collider[] colliders;
    Rigidbody ball;

    private void Awake()
    {
        renderers = GetComponentsInChildren<Renderer>();
        colliders = GetComponentsInChildren<Collider>();
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody>();
        startingPos = ball.transform.localPosition;

        //ball.isKinematic = true;
        //ball.useGravity = false;
    }

    protected override void OnTrackingFound()
    {
        ball.transform.localPosition = startingPos;
        ball.velocity = Vector3.zero;
        ball.isKinematic = false;
        ball.useGravity = true;

        foreach(Collider c in colliders)
        {
            c.enabled = true;
        }

        foreach(Renderer r in renderers)
        {
            if (r)
                r.enabled = true;
        }

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
    }

    protected override void OnTrackingLost()
    {
        //ball.isKinematic = true;
        //ball.useGravity = false;

        foreach (Collider c in colliders)
        {
            c.enabled = false;
        }

        foreach (Renderer r in renderers)
        {
            if (r)
                r.enabled = false;
        }

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
    }

    private void Update()
    {
        //ball.isKinematic = false;
        //ball.useGravity = true;
       // Debug.Log("Ball's isKinematic: " + ball.isKinematic);
    }   
}
