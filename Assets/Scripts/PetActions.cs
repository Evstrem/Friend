using UnityEngine;

public class PetActions : MonoBehaviour
{
    public PetStats petStats;

    public int coins = 0;

    public void FeedPet()
    {
        petStats.hunger += 20f;
        petStats.happiness += 5f;
        coins += 2;

        petStats.hunger = Mathf.Clamp(petStats.hunger, 0, 100);
        petStats.happiness = Mathf.Clamp(petStats.happiness, 0, 100);
    }

    public void PlayWithPet()
    {
        petStats.happiness += 20f;
        petStats.energy -= 10f;
        coins += 5;

        petStats.happiness = Mathf.Clamp(petStats.happiness, 0, 100);
        petStats.energy = Mathf.Clamp(petStats.energy, 0, 100);
    }

    public void SleepPet()
    {
        petStats.energy += 25f;
        petStats.hunger -= 5f;

        petStats.energy = Mathf.Clamp(petStats.energy, 0, 100);
        petStats.hunger = Mathf.Clamp(petStats.hunger, 0, 100);
    }
}