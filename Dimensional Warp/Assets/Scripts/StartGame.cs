using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Animator m_animator;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = gameObject.GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            m_animator.SetBool("Fade", true);
            button.gameObject.SetActive(false);
            StartCoroutine(ExecuteAfterTime(1.2f));
        }
    }

    public void Startgame()
    {
        SceneManager.LoadScene("Map");
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Startgame();
    }
}
