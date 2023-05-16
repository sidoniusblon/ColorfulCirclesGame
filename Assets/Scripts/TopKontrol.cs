using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TopKontrol : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float jumpForce = 3f;
    bool basildiMi;
    [SerializeField] Color turkuaz, sari, mor, pembe;
    string mevcutRenk;
    Color topunRengi = Color.white;
    [SerializeField] Text scoreText;
    int bestScore;
    public static int score = 0;
    [SerializeField] GameObject halka, renkTekeri;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");
        UIControllerSc.Instance.bestScoreUpdate(bestScore);
        score = 0;
        scoreText.text = "Score: " + score;
        RastgeleRenkBelirle();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            basildiMi = true;
        }
        
    }
    private void FixedUpdate()
    {
        if (basildiMi)
        {
            rb.velocity = Vector2.up * jumpForce;
            basildiMi = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "RenkTekeri")
        {
            RastgeleRenkBelirle();
            Destroy(collision.gameObject);
            Instantiate(renkTekeri, new Vector3(transform.position.x, transform.position.y + 8f, transform.position.z), Quaternion.identity);
            return;
        }
        if (collision.tag == "PuanArttirici")
        {
            score += 15;
            scoreText.text = "Score: " + score;
            Destroy(collision.gameObject);
            Instantiate(halka,new Vector3(transform.position.x, transform.position.y + 8f, transform.position.z),Quaternion.identity);
            return;
        }
        if (collision.tag != mevcutRenk)
        {
            if (score > bestScore) { bestScore = score; PlayerPrefs.SetInt("BestScore", bestScore); }
            SceneManager.LoadScene(0);
            
        }
    }
    void RastgeleRenkBelirle()
    {
        int rastgeleSayi = Random.Range(0, 4);
        switch (rastgeleSayi)
        {
            case 0:
                mevcutRenk = "Turkuaz";
                topunRengi = turkuaz;
                break;
            case 1:
                mevcutRenk = "Sari";
                topunRengi = sari;
                break;
            case 2:
                mevcutRenk = "Pembe";
                topunRengi = pembe;
                break;
            case 3:
                mevcutRenk = "Mor";
                topunRengi = mor;
                break;
            default:
                break;
        }
        if (topunRengi == GetComponent<SpriteRenderer>().color)
            RastgeleRenkBelirle();
        else
            GetComponent<SpriteRenderer>().color = topunRengi;
    }

}
