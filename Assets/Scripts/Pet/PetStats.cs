using UnityEngine;

public class PetStats : MonoBehaviour
{
    public float hunger = 100f;
    public float energy = 100f;
    public float happiness = 100f;

    public float maxValue = 100f;

    public float hungerDecreaseSpeed = 1f;
    public float energyDecreaseSpeed = 0.5f;
    public float happinessDecreaseSpeed = 0.3f;

    void Update()
    {
        hunger -= Time.deltaTime * hungerDecreaseSpeed;
        energy -= Time.deltaTime * energyDecreaseSpeed;
        happiness -= Time.deltaTime * happinessDecreaseSpeed;

        hunger = Mathf.Clamp(hunger, 0f, maxValue);
        energy = Mathf.Clamp(energy, 0f, maxValue);
        happiness = Mathf.Clamp(happiness, 0f, maxValue);
    }

    public void AddHunger(float amount)
    {
        hunger = Mathf.Clamp(hunger + amount, 0f, maxValue);
    }

    public void AddEnergy(float amount)
    {
        energy = Mathf.Clamp(energy + amount, 0f, maxValue);
    }

    public void AddHappiness(float amount)
    {
        happiness = Mathf.Clamp(happiness + amount, 0f, maxValue);
    }
}