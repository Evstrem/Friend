using UnityEngine;

public class PetGrowth : MonoBehaviour
{
    public DaySystem daySystem;
    private Renderer petRenderer;

    void Start()
    {
        petRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (daySystem.currentDay < 3)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            petRenderer.material.color = Color.yellow;
        }
        else if (daySystem.currentDay < 5)
        {
            transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            petRenderer.material.color = Color.green;
        }
        else
        {
            transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
            petRenderer.material.color = Color.cyan;
        }
    }
}