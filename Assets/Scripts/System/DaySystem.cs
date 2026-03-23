using UnityEngine;

public class DaySystem : MonoBehaviour
{
    public float dayDuration = 60f;
    private float timer = 0f;

    public int currentDay = 1;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= dayDuration)
        {
            currentDay++;
            timer = 0f;
        }
    }
}