using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor))]
public class StorageUnlocker : MonoBehaviour
{
    [Header("Drawer Control")]
    public ConfigurableJoint drawerJoint;   // drawer's joint
    public GameObject lockVisual;           // optional

    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;
    private bool unlocked = false;

    void Awake()
    {
        socket = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor>();
        socket.selectEntered.AddListener(OnKeyInserted);

        // Lock drawer at start
        if (drawerJoint != null)
            drawerJoint.zMotion = ConfigurableJointMotion.Locked;
    }

    void OnDestroy()
    {
        if (socket != null)
            socket.selectEntered.RemoveListener(OnKeyInserted);
    }

    void OnKeyInserted(SelectEnterEventArgs args)
    {
        if (unlocked) return;
        unlocked = true;

        // Unlock drawer movement
        if (drawerJoint != null)
            drawerJoint.zMotion = ConfigurableJointMotion.Limited;

        // Optional: hide lock visual
        if (lockVisual != null)
            lockVisual.SetActive(false);

        // Destroy key
        if (args.interactableObject != null)
            Destroy(args.interactableObject.transform.gameObject);

        socket.enabled = false;
    }
}