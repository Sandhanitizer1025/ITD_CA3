using UnityEngine;

public class TeleportZone : MonoBehaviour
{
    public int teleportNumber;
    public TutorialManager manager;

    [Header("Materials")]
    public Material greyMaterial;
    public Material greenMaterial;

    private Renderer rend;
    private bool activated = false;
    private Transform player;

    void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (activated) return;

        if (manager == null || player == null) return;

        if (IsPlayerInside())
        {
            activated = true;
            manager.TeleportCompleted(teleportNumber);
        }
    }

    bool IsPlayerInside()
    {
        Bounds bounds = GetComponent<Collider>().bounds;
        return bounds.Contains(player.position);
    }

    public void SetActiveVisual(bool isActive)
    {
        if (rend == null) return;

        if (isActive)
            rend.material = greenMaterial;
        else
            rend.material = greyMaterial;
    }
}