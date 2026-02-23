using UnityEngine;


public class InteractionGate : MonoBehaviour
{
    [Header("Start locked?")]
    public bool lockedAtStart = true;

    UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable[] interactables;
    Behaviour[] extraBehaviours; // for Interactors like XRSocketInteractor, etc.

    void Awake()
    {
        // XRBaseInteractable covers XRGrabInteractable, XRSimpleInteractable, etc.
        interactables = GetComponentsInChildren<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>(true);

        // XRSocketInteractor is an Interactor (Behaviour), not an Interactable
        extraBehaviours = GetComponentsInChildren<Behaviour>(true);

        if (lockedAtStart)
            SetLocked(true);
    }

    public void SetLocked(bool locked)
    {
        // Disable all interactables
        foreach (var x in interactables)
            x.enabled = !locked;

        // Disable common interactor types (Sockets etc.)
        foreach (var b in extraBehaviours)
        {
            if (b == null) continue;

            // Only target XR Interaction Toolkit components that should be gated
            // Sockets are XRSocketInteractor (Behaviour)
            if (b.GetType().Name.Contains("XRSocketInteractor"))
                b.enabled = !locked;
        }
    }
}