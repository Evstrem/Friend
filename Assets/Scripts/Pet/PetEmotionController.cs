using UnityEngine;

public class PetEmotionController : MonoBehaviour
{
    public Renderer bodyRenderer;

    public Material normalMaterial;
    public Material happyMaterial;
    public Material cryingMaterial;
    public Material angryMaterial;

    public void SetNormal()
    {
        bodyRenderer.material = normalMaterial;
    }

    public void SetHappy()
    {
        bodyRenderer.material = happyMaterial;
    }

    public void SetCrying()
    {
        bodyRenderer.material = cryingMaterial;
    }

    public void SetAngry()
    {
        bodyRenderer.material = angryMaterial;
    }
}