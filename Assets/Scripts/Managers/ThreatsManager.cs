using UnityEngine;

public class ThreatsManager : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public float Speed => speed;

    [SerializeField]
    private float speedMod;

    [SerializeField]
    private AudioSource music;

    public void IncreaseSpeed()
    {
        speed += speedMod;

        switch (speed)
        {
            case 2:
                music.pitch = 1.15f;
                break;

            case 4:
                music.pitch = 1.25f;
                break;

            case 6:
                music.pitch = 1.5f;
                break;
        }
    }
}
