using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [Header("Trigger Zones")]
    public TutorialTrigger trigger1;
    public TutorialTrigger trigger2;
    public TutorialTrigger trigger3;

    [Header("Teleport Areas")]
    public TeleportZone teleport1;
    public TeleportZone teleport2;

    [Header("Congrats UI")]
    public GameObject congratsUI;

    private int triggerProgress = 0;
    private int teleportProgress = 0;

    void Start()
{
    trigger1.SetActiveVisual(true);
    trigger2.SetActiveVisual(false);
    trigger3.SetActiveVisual(false);

    teleport1.SetActiveVisual(false);
    teleport2.SetActiveVisual(false);

    teleport1.gameObject.SetActive(false);
    teleport2.gameObject.SetActive(false);

    congratsUI.SetActive(false);
}

    public void TriggerCompleted(int triggerNumber)
    {
        if (triggerNumber == triggerProgress + 1)
        {
            triggerProgress++;

            if (triggerProgress == 1)
            {
                trigger1.SetActiveVisual(false);
                trigger2.SetActiveVisual(true);
            }
            else if (triggerProgress == 2)
            {
                trigger2.SetActiveVisual(false);
                trigger3.SetActiveVisual(true);
            }
            else if (triggerProgress == 3)
            {
                trigger3.SetActiveVisual(false);
                teleport1.gameObject.SetActive(true);
                teleport1.SetActiveVisual(true);
            }
        }
    }

    public void TeleportCompleted(int teleportNumber)
    {
        if (teleportNumber == teleportProgress + 1)
        {
            teleportProgress++;

            if (teleportProgress == 1)
            {
                teleport1.SetActiveVisual(false);

                teleport2.gameObject.SetActive(true);
                teleport2.SetActiveVisual(true);
            }
            else if (teleportProgress == 2)
            {
                teleport2.SetActiveVisual(false);
                congratsUI.SetActive(true);
            }
        }
    }
}
