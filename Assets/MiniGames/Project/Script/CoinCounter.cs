using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public HUDController hud;
    public NeonAnimation neonBlinker;
    public NeonAnimation neonBlinker2;
    private float timeLastCoin = 0f;
    public AudioSource coinSound;

    void Update()
    {
        timeLastCoin += Time.deltaTime;

        if (timeLastCoin >= 10f)
        {
            AnimationBlink();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chip1"))
        {
            hud.AddChip(1);
            AnimationBlink();
            PlayCoinSound();
        }
        if (other.CompareTag("Chip2"))
        {
            hud.AddChip(2);
            AnimationBlink();
            PlayCoinSound();
        }
        if (other.CompareTag("Chip5"))
        {
            hud.AddChip(5);
            AnimationBlink();
            PlayCoinSound();
        }
        if (other.CompareTag("Chip10"))
        {
            hud.AddChip(10);
            AnimationBlink();
            PlayCoinSound();
        }

        if (other.CompareTag("CoinEuro"))
        {
            hud.AddCoin("Euro");
            AnimationBlink();
            PlayCoinSound();
        }

        if (other.CompareTag("CoinStar"))
        {
            hud.AddCoin("Star");
            AnimationBlink();
            PlayCoinSound();
        }

        if (other.CompareTag("CoinLincoln"))
        {
            hud.AddCoin("Lincoln");
            AnimationBlink();
            PlayCoinSound();
        }
        Destroy(other.gameObject);
    }
    void AnimationBlink()
    {
        neonBlinker.Blink();
        neonBlinker2.Blink();
        timeLastCoin = 0f;
    }
    void PlayCoinSound()
    {
        coinSound.Play();
    }
}