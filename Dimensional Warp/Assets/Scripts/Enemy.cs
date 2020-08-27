using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HpBar healthBar;

    public GameObject cam;

    public AudioClip damageSound;
    public AudioClip deadSound;
    public AudioClip HitSound;
    private AudioSource audio;

    private Animator anim;
    public GameObject enemyModel;

    public GameObject GUI;
    private Animator animGUI;

    public bool alive = true;
    int i = 0;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        //GUI = GameObject.FindGameObjectWithTag("GUI");
        animGUI = GUI.GetComponent<Animator>();
        alive = true;
        anim =  enemyModel.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.collider != null)
                {
                    GameObject touchedObj = hit.transform.gameObject;
                    Debug.Log("touched " + touchedObj.transform.name);
                    if (touchedObj.tag == "enemy")
                    {
                        takeDamage(5);
                        if (alive == true)
                        {
                            audio.PlayOneShot(damageSound);
                        }
                    }
                }
            }
        }

        if (currentHealth <= 0)
        {
            alive = false;
            anim.SetBool("dead", true);
            
            audio.PlayOneShot(deadSound);
            StartCoroutine(ExecuteAfterTime(5.0f));
    
        }
        if(currentHealth > 0)
        {
            if (timer > i)
            {
                Debug.Log("hit");
                i += 3;
                audio.PlayOneShot(HitSound);
                anim.SetTrigger("Attack");
                GameManager.Instance.CurrentPlayer.takeDamage(10);
                //StartCoroutine(ExecuteAfterTimeDamage(2.0f));
            }
            if (GameManager.Instance.CurrentPlayer.currentHealth <= 0)
            {
                animGUI.SetTrigger("Dead");
                StartCoroutine(ExecuteAfterTimeDeath(2.0f));
            }
        }
 
    }

    void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
       
        GameManager.Instance.CurrentPlayer.AddXp(5);
        animGUI.SetTrigger("Fade");
        SceneTransitionManager.Instance.GoToScene("Map", new List<GameObject>());
        animGUI.SetTrigger("FadeIn");
        Destroy(cam);
    }
    IEnumerator ExecuteAfterTimeDeath(float time)
    {
        yield return new WaitForSeconds(time);
        SceneTransitionManager.Instance.GoToScene("Map", new List<GameObject>());
        GameManager.Instance.CurrentPlayer.Death();
    }
}
