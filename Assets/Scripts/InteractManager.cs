using UnityEngine;

public class InteractManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Çarpan nesnede Ball scripti var mı kontrol et
        Ball ballScript = other.gameObject.GetComponent<Ball>();

        if (ballScript != null && other.gameObject.CompareTag("Interact"))
        {
            // EĞER YAKALANMAYA MÜSAİT DEĞİLSE HİÇBİR ŞEY YAPMA (ÇIKIŞ YAPIYORDUR)
            if (!ballScript.canInteract) return;

            if (ballScript.currenRotateBall != gameObject)
            {
                Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
                rb.linearVelocity = Vector2.zero; // Unity 6 kullanıyorsan linearVelocity, eskiyse velocity
                rb.isKinematic = true;

                other.gameObject.transform.SetParent(this.transform); // "this" şu anki dönen top
                ballScript.currenRotateBall = gameObject;
                Debug.Log("Yakalandı");
            }
            else
            {
                Debug.Log("Aynı yere vurdun yani oyun bitti");
            }
        }

    }
}