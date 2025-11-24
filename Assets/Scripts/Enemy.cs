using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Hız Ayarları")]
    public float minSpeed = 2f;  // En yavaş hareket hızı
    public float maxSpeed = 5f;  // En hızlı hareket hızı
    private float currentSpeed;  // Şu anki hızımız

    [Header("Sınır Ayarları")]
    public float minX = -2f;     // Sol sınır
    public float maxX = 2f;      // Sağ sınır
    void Start()
    {
        // Oyun başlayınca hızı ve ilk yönü belirle
        SetRandomSpeed();
    }
    void Update()
    {
        // 1. HAREKET ETTİR
        // Vector3.right (1,0,0) demektir. Bunu hız ve zamanla çarpıp pozisyona ekliyoruz.
        // Eğer currentSpeed eksi ise sola, artı ise sağa gider.
        transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);

        // 2. SINIR KONTROLÜ (DUVARA ÇARPTI MI?)

        // Eğer sağ sınıra (2) geldiyse VE hala sağa gitmeye çalışıyorsa (Hız pozitifse)
        if (transform.position.x >= maxX && currentSpeed > 0)
        {
            currentSpeed = -currentSpeed; // Hızı tersine çevir (Sola dön)
        }
        // Eğer sol sınıra (-2) geldiyse VE hala sola gitmeye çalışıyorsa (Hız negatifse)
        else if (transform.position.x <= minX && currentSpeed < 0)
        {
            currentSpeed = -currentSpeed; // Hızı tersine çevir (Sağa dön)
        }
    }
    void SetRandomSpeed()
    {
        // Rastgele bir hız büyüklüğü seç (Örn: 3.5f)
        float randomSpeed = Random.Range(minSpeed, maxSpeed);

        // Rastgele bir yön seç (Sağ mı Sol mu?)
        // %50 ihtimalle sağa başlasın, %50 sola
        if (Random.value > 0.5f)
        {
            currentSpeed = randomSpeed;  // Sağa git (+)
        }
        else
        {
            currentSpeed = -randomSpeed; // Sola git (-)
        }
    }
}
