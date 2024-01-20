using UnityEngine;

public class Threat : MonoBehaviour
{
    public bool IsWorking { get; set; }

    protected ThreatsManager threatsManager;

    private void Awake()
    {
        threatsManager = FindObjectOfType<ThreatsManager>();
    }
}
