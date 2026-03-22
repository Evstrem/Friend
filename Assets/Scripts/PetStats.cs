using UnityEngine;

public class PetStats : MonoBehaviour
{
    public float hunger = 100;
    public float energy = 100;
    public float happiness = 100;

    void Update()
    {
        hunger -= Time.deltaTime * 1;
        energy -= Time.deltaTime * 0.5f;
        happiness -= Time.deltaTime * 0.3f;

        hunger = Mathf.Clamp(hunger, 0, 100);
        energy = Mathf.Clamp(energy, 0, 100);
        happiness = Mathf.Clamp(happiness, 0, 100);
    }
}