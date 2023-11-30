using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ufo : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb2d;
    private int count = 0;
    public Text score_1;
    [SerializeField] Text winText;
    private bool canLoadScene = true;
    public float cooldownTime = 5f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    private void OnTriggerEnter2D(Collider2D obiekt)
    {
        if (obiekt.gameObject.CompareTag("pickup"))
        {
            count++;
            score_1.text = count.ToString();
            Destroy(obiekt.gameObject);

            if (count >= 3 && canLoadScene)
            {
                winText.gameObject.SetActive(true);

                StartCoroutine(CooldownBeforeLoadingScene());
            }
        }
    }

    private IEnumerator CooldownBeforeLoadingScene()
    {
        canLoadScene = false; 

        yield return new WaitForSeconds(cooldownTime);

        winText.gameObject.SetActive(false);

        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }

        canLoadScene = true;
    }
}
