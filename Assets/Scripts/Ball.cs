using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Ayarlar")]
    public float power = 10f;        // Fırlatma gücü çarpanı
    public float maxDrag = 5f;       // Maksimum çekme mesafesi (sınırlama)

    private Rigidbody2D rb;
    private Vector2 startPoint;      // Tıklama başlangıç noktası
    private Vector2 endPoint;        // Bırakma noktası
    private Vector2 direction;       // Fırlatma yönü
    public bool canInteract = true;
    private Camera cam;

    [HideInInspector] public GameObject currenRotateBall;

    // Görsel çizgi için (Opsiyonel)
    public LineRenderer lr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        cam = Camera.main;
    }

    // Fare veya Parmak topun üzerine tıklandığında çalışır
    void OnMouseDown()
    {
        rb.linearVelocity = Vector2.zero;

        startPoint = transform.position; // Topun merkezini referans alıyoruz

        if (lr != null) lr.enabled = true; // Çizgiyi aç
    }

    // Sürükleme esnasında sürekli çalışır
    void OnMouseDrag()
    {

        // Farenin ekran pozisyonunu dünya pozisyonuna çevir
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        // Ne kadar çektik hesapla
        Vector2 currentPoint = mousePos;
        Vector2 difference = startPoint - currentPoint; // Ters yöne gitmesi için Start - Current

        // Çekme mesafesini sınırla (çok aşırı gerilmesin)
        direction = Vector2.ClampMagnitude(difference, maxDrag);

        // Görsel olarak çizgiyi çiz (Nişan hattı)
        if (lr != null)
        {
            lr.SetPosition(0, startPoint);
            lr.SetPosition(1, startPoint - direction); // Çektiğin yönün tersini gösterir
        }


    }

    // Fareyi bıraktığında çalışır
    void OnMouseUp()
    {
        rb.isKinematic = false; // Fiziği tekrar aç

        // Gücü uygula (ForceMode2D.Impulse anlık patlama gücü verir)
        DisableInteractionBriefly();
        rb.AddForce(direction * power, ForceMode2D.Impulse);

        if (lr != null) lr.enabled = false; // Çizgiyi kapat
    }

    public void DisableInteractionBriefly()
    {
        StartCoroutine(InteractionCooldown());
    }

    IEnumerator InteractionCooldown()
    {
        canInteract = false; // Yakalanmayı kapat
        yield return new WaitForSeconds(0.01f); // 0.2 saniye bekle (top çemberden çıksın diye)
        canInteract = true;  // Yakalanmayı tekrar aç
    }
}