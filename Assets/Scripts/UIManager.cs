using UnityEngine;
using UnityEngine.UI;
using System.Collections; // Coroutine için gerekli

public class UIManager : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    public Transform playButtonBallTransform;
    public Transform quitPlayBallTransform;

    public Transform ball;

    // Hareket sırasında üst üste basılırsa karışmasın diye hafızada tutuyoruz
    private Coroutine currentMoveCoroutine;

    public void PlayPress()
    {
        Debug.Log("bok");
        // Eğer top zaten hareket halindeyse, eski emri iptal et
        if (currentMoveCoroutine != null) StopCoroutine(currentMoveCoroutine);

        // Yeni hareketi başlat
        currentMoveCoroutine = StartCoroutine(MoveBall(playButtonBallTransform.position));
    }

    public void QuitPress()
    {
        if (currentMoveCoroutine != null) StopCoroutine(currentMoveCoroutine);
        currentMoveCoroutine = StartCoroutine(MoveBall(quitPlayBallTransform.position));
    }

    // Hareket işlemini zamana yayan yardımcı fonksiyon (Coroutine)
    IEnumerator MoveBall(Vector3 targetPosition)
    {
        // Hedefin X ve Y'sini al, ama Z olarak topun KENDİ Z'sini kullan.
        // Böylece top arkaya kaçmaz veya öne fırlamaz.
        Vector3 targetAdjusted = new Vector3(targetPosition.x, targetPosition.y, ball.position.z);

        while (Vector3.Distance(ball.position, targetAdjusted) > 0.01f)
        {
            ball.position = Vector3.Lerp(ball.position, targetAdjusted, 5f * Time.deltaTime);
            yield return null;
        }

        ball.position = targetAdjusted;
        // Zıplamanın ayarları
        float jumpHeight = 0.5f; // Ne kadar yükseğe zıplasın?
        float jumpSpeed = 5f;    // Ne kadar hızlı zıplasın?

        // Orijinal Yüksekliği kaydet (Zemin kabul et)
        float floorY = ball.position.y;

        while (true) // Sonsuz döngü (Sen başka tuşa basıp durdurana kadar döner)
        {
            // MATEMATİKSEL BÜYÜ:
            // Mathf.Sin normalde dalga yapar (-1 ile 1 arası).
            // Mathf.Abs (Mutlak Değer) eksileri artı yapar, böylece top top gibi seker (|uuu| şekli).
            float newY = floorY + Mathf.Abs(Mathf.Sin(Time.time * jumpSpeed)) * jumpHeight;

            ball.position = new Vector3(ball.position.x, newY, ball.position.z);

            yield return null;
        }
    }
}



