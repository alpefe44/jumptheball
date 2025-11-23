using UnityEngine;

public class CircleMechanism : MonoBehaviour
{
    [Header("Hız Ayarları")]
    public float minSpeed = 50f; // En yavaş ne kadar dönsün?
    public float maxSpeed = 150f; // En hızlı ne kadar dönsün?

    private float currentSpeed;   // O anki belirlenen hız

    private void Start()
    {
        SetRandomRotation();
    }
    
    void Update()
    {
        transform.Rotate(currentSpeed * Time.deltaTime * Vector3.forward);
    }


    void SetRandomRotation()
    {
        // 1. Rastgele bir hız seç (Min ile Max arasında)
        float randomSpeed = Random.Range(minSpeed, maxSpeed);

        // 2. Rastgele bir yön seç (Yazı tura atıyoruz)
        // Random.value 0 ile 1 arasında sayı verir. 0.5'ten büyükse saat yönü, değilse tersi.
        bool isClockwise = Random.value > 0.5f;

        // Eğer saat yönünün tersine dönecekse hızı negatif yap (-1 ile çarp)
        if (isClockwise)
        {
            currentSpeed = -randomSpeed;
        }
        else
        {
            currentSpeed = randomSpeed;
        }
    }

}
