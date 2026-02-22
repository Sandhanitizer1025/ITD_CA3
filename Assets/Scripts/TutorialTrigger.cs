using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public int triggerNumber;
    public TutorialManager manager;

    [Header("Materials")]
    public Material greyMaterial;
    public Material greenMaterial;

    private Renderer rend;
    private bool activated = false;

    void Awake()  // 👈 CHANGE Start() to Awake()
    {
        rend = GetComponent<Renderer>();
    }

    public void SetActiveVisual(bool isActive)
    {
        if (rend == null) return;

        if (isActive)
            rend.material = greenMaterial;
        else
            rend.material = greyMaterial;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!activated && other.CompareTag("Player"))
        {
            activated = true;
            manager.TriggerCompleted(triggerNumber);
        }
    }
}