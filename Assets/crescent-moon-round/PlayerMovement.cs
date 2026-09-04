using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform mainCameraTransform;

    [Header("Dev Ölçek Matematiksel Hareket")]
    public float moveSpeed = 5000f; // Modelinizin devasa boyutuna uygun hız

    void Start()
    {
        // Sahnedeki ana kamerayı otomatik olarak bulur
        if (Camera.main != null)
        {
            mainCameraTransform = Camera.main.transform;
        }

        // Oyun başlarken fare imlecini ekrandan gizler
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // 1. Klavyeden W-A-S-D veya Yön Tuşları girdilerini al
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        // Hareket vektörünü oluştur
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // 2. Eğer bir yön tuşuna basılıyorsa hareketi başlat
        if (direction.magnitude >= 0.1f)
        {
            // Kameranın baktığı açıya göre gitmesi gereken yönün açısını hesapla
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + mainCameraTransform.eulerAngles.y;
            
            // Karakteri kameranın baktığı yöne doğru yumuşakça döndür
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            // Karakteri o yönde doğrudan (fiziksiz) ileri doğru yürüt
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}