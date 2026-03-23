using UnityEngine;

public class PetActions : MonoBehaviour
{
    public PetStats petStats;
    public int coins = 0;

    public void FeedPet()
    {
        petStats.AddHunger(20f);
        petStats.AddHappiness(5f);
        coins += 2;
    }

    public void PlayWithPet()
    {
        petStats.AddHappiness(20f);
        petStats.AddEnergy(-10f);
        coins += 5;
    }

    public void SleepPet()
    {
        petStats.AddEnergy(25f);
        petStats.AddHunger(-5f);
    }
}