using UnityEngine;

public class TemaslaYukariCik : MonoBehaviour
{
    [Header("Hareket Ayarları")]
    public float yukselmeMiktari = 5.0f; 
    public float hareketHizi = 3.0f;     

    private Vector3 baslangicPozisyonu;
    private Vector3 hedefPozisyonu;
    private Vector3 aktifHedef;

    void Start()
    {
        baslangicPozisyonu = transform.position;
        hedefPozisyonu = baslangicPozisyonu + Vector3.up * yukselmeMiktari;
        aktifHedef = baslangicPozisyonu;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, aktifHedef, hareketHizi * Time.deltaTime);
    }

    // Bir nesne girdiğinde tetiklenir
    private void OnTriggerEnter(Collider other)
    {
        // Sadece etiketi "Player" olan nesne girdiyse yukarı çık
        if (other.CompareTag("Player"))
        {
            aktifHedef = hedefPozisyonu;
        }
    }

    // Temas kesildiğinde tetiklenir
    private void OnTriggerExit(Collider other)
    {
        // Sadece etiketi "Player" olan nesne çıktıysa aşağı in
        if (other.CompareTag("Player"))
        {
            aktifHedef = baslangicPozisyonu;
        }
    }
}