using UnityEngine;

public class PetStateController : MonoBehaviour
{
    public PetStats petStats;
    public Animator animator;
    public PetEmotionController emotionController;

    private float happyTimer = 0f;
    public float happyDuration = 2f;

    private bool isSleeping = false;

    void Update()
    {
        if (isSleeping)
            return;

        if (happyTimer > 0f)
        {
            happyTimer -= Time.deltaTime;
            emotionController.SetHappy();
            return;
        }

        switch (petStats.CurrentMood)
        {
            case PetStats.PetMood.Normal:
                emotionController.SetNormal();
                break;

            case PetStats.PetMood.Happy:
                emotionController.SetHappy();
                break;

            case PetStats.PetMood.Crying:
                emotionController.SetCrying();
                break;

            case PetStats.PetMood.Angry:
                emotionController.SetAngry();
                break;

            case PetStats.PetMood.Tired:
                emotionController.SetCrying();
                break;
        }
    }

    public void PlayHappyReaction()
    {
        happyTimer = happyDuration;
        emotionController.SetHappy();
        animator.SetTrigger("Happy");
    }

    public void PlaySleepReaction()
    {
        isSleeping = true;
        animator.SetTrigger("Sleep");
    }

    public void StopSleeping()
    {
        isSleeping = false;
    }
}