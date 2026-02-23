using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;


public class AssemblyManager : MonoBehaviour
{
    [Header("Sockets")]
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor crystalSocket;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor ringSocket;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor frameSocket;

    private bool assembled = false;

    void Update()
    {
        if (assembled) return;

        if (crystalSocket.hasSelection &&
            ringSocket.hasSelection &&
            frameSocket.hasSelection)
        {
            Assemble();
        }
    }

    void Assemble()
{
    assembled = true;

    var crystal = crystalSocket.firstInteractableSelected.transform.gameObject;
    var ring    = ringSocket.firstInteractableSelected.transform.gameObject;
    var frame   = frameSocket.firstInteractableSelected.transform.gameObject;

    // Disable sockets
    crystalSocket.enabled = false;
    ringSocket.enabled = false;
    frameSocket.enabled = false;

    // Parent hierarchy
    ring.transform.SetParent(crystal.transform, true);
    frame.transform.SetParent(ring.transform, true);

    // Disable grab on ring + frame
    var ringGrab = ring.GetComponent<XRGrabInteractable>();
    if (ringGrab != null) ringGrab.enabled = false;

    var frameGrab = frame.GetComponent<XRGrabInteractable>();
    if (frameGrab != null) frameGrab.enabled = false;

    // Make ring + frame passive
    var ringRb = ring.GetComponent<Rigidbody>();
    if (ringRb != null)
    {
        ringRb.isKinematic = true;
        ringRb.useGravity = false;
    }

    var frameRb = frame.GetComponent<Rigidbody>();
    if (frameRb != null)
    {
        frameRb.isKinematic = true;
        frameRb.useGravity = false;
    }

    // Only crystal remains active physics
    var crystalRb = crystal.GetComponent<Rigidbody>();
    if (crystalRb != null)
    {
        crystalRb.isKinematic = false;
        crystalRb.useGravity = true;
    }
}
}
