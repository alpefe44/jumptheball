using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [Header("Gerekli Bileşenler")]
    public AudioSource audioSource; // Müzik kaynağı
    public Transform player;        // Takip edilecek oyuncu (Top)

    [Header("Ayarlar")]
    public float sensitivity = 0.01f; // Yükseklik müziği ne kadar etkilesin? (Küçük sayı = Az etki)
    public float maxPitch = 2.0f;     // Müzik en fazla ne kadar hızlansın? (2 = 2 katı)
    public float minPitch = 1.0f;     // Müzik en yavaş ne olsun? (1 = Normal hız)

    private float startY; // Oyunun başladığı yükseklik

    void Start()
    {
        // Başlangıç yüksekliğini kaydet
        if (player != null)
        {
            startY = player.position.y;
        }
        
        // Müziği normal hızda başlat
        audioSource.pitch = 1f;
    }

    void Update()
    {
        if (player == null) return;

        // 1. Oyuncu ne kadar yükseldi?
        float currentHeight = player.position.y - startY;

        // Eğer oyuncu başlangıçtan aşağı düştüyse (eksiye gittiyse) 0 kabul et
        if (currentHeight < 0) currentHeight = 0;

        // 2. Yeni hızı hesapla
        // Formül: Normal Hız + (Yükseklik * Hassasiyet)
        // Örnek: 1 + (100 metre * 0.005) = 1.5 Pitch
        float newPitch = 1f + (currentHeight * sensitivity);

        // 3. Hızı sınırla (Mathf.Clamp)
        // Müzik 3-4 katına çıkıp cıyaklamasın diye bir tavan (maxPitch) koyuyoruz.
        audioSource.pitch = Mathf.Clamp(newPitch, minPitch, maxPitch);
    }
}