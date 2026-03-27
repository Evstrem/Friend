using UnityEngine;

public class PetStats : MonoBehaviour
{
    public enum PetMood
    {
        Normal,
        Happy,
        Crying,
        Angry,
        Tired
    }

    [Header("Stats")]
    public float hunger = 100f;
    public float energy = 100f;
    public float happiness = 100f;

    [Header("Limits")]
    public float maxValue = 100f;

    [Header("Decrease Speed")]
    public float hungerDecreaseSpeed = 1f;
    public float energyDecreaseSpeed = 0.5f;
    public float happinessDecreaseSpeed = 0.3f;

    [Header("Mood Thresholds")]
    public float lowHungerThreshold = 25f;
    public float lowEnergyThreshold = 25f;
    public float highHappinessThreshold = 80f;
    public float veryLowThreshold = 10f;

    public PetMood CurrentMood { get; private set; }

    void Update()
    {
        hunger -= Time.deltaTime * hungerDecreaseSpeed;
        energy -= Time.deltaTime * energyDecreaseSpeed;
        happiness -= Time.deltaTime * happinessDecreaseSpeed;

        hunger = Mathf.Clamp(hunger, 0f, maxValue);
        energy = Mathf.Clamp(energy, 0f, maxValue);
        happiness = Mathf.Clamp(happiness, 0f, maxValue);

        UpdateMood();
    }

    void UpdateMood()
    {
        if (energy <= lowEnergyThreshold)
        {
            CurrentMood = PetMood.Tired;
        }
        else if (hunger <= veryLowThreshold || happiness <= veryLowThreshold)
        {
            CurrentMood = PetMood.Angry;
        }
        else if (hunger <= lowHungerThreshold || happiness <= lowHungerThreshold)
        {
            CurrentMood = PetMood.Crying;
        }
        else if (happiness >= highHappinessThreshold)
        {
            CurrentMood = PetMood.Happy;
        }
        else
        {
            CurrentMood = PetMood.Normal;
        }
    }

    public void AddHunger(float amount)
    {
        hunger = Mathf.Clamp(hunger + amount, 0f, maxValue);
        UpdateMood();
    }

    public void AddEnergy(float amount)
    {
        energy = Mathf.Clamp(energy + amount, 0f, maxValue);
        UpdateMood();
    }

    public void AddHappiness(float amount)
    {
        happiness = Mathf.Clamp(happiness + amount, 0f, maxValue);
        UpdateMood();
    }
}