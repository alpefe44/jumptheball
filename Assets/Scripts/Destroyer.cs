using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Bu nesneye çarpan her şeyi yok et
    void OnTriggerEnter2D(Collider2D other)
    {
        // Eğer çarpan şey oyuncuysa OYUN BİTER (Onu yok etme, oyun bitiş ekranı aç)
        if (other.CompareTag("Player"))
        {
            Debug.Log("Oyun Bitti!");
            // SceneManager.LoadScene(0); // Yeniden başlatmak için
        }
        else
        {
            // Daireler veya başka objelerse yok et gitsin, hafıza dolsun istemeyiz
            Destroy(other.gameObject);
        }
    }
} 