using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float iframe;
    //[SerializeField] private bool isIframed;
    [SerializeField] private int pierceDamage;
    //private float iframeTime;
    public GameObject damageDisplay;
    public GameObject damage;
    public GameObject healthbar;
    public Rigidbody2D rb;
    public GameObject sprite;
    private Vector3 dir;
    private float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        // if(isIframed){
        //     if (Time.time > iframeTime){
        //         isIframed = false;
        //     }
        // }
        if(health <= 0){
            health = 0;
            Death();
        }
        healthbar.transform.localScale = new Vector3(health/maxHealth, 1, 1);

    }
    
    void OnTriggerEnter2D(Collider2D col){
        //if(isIframed == false){
            if(col.gameObject.tag == "Projectile"){
                dir = col.gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
                Debug.Log("hit");
                Projectile projectileScript = col.gameObject.GetComponent<Projectile>();
                health -= projectileScript.damage;
                projectileScript.pierce -= pierceDamage;
                //isIframed = true;
                //iframeTime = Time.time + iframe;
                KnockBack(projectileScript.kb);
                ShowDamage((int)projectileScript.damage);
            }
        //}
    }

    void Death(){
        Destroy(this.gameObject);
    }

    void KnockBack(float kb){
        Debug.Log("knock back"); 
        gameObject.GetComponent<EnemyMovement>().isKnockedBack = true;
        gameObject.GetComponent<EnemyMovement>().knockBackTime = Time.time + 0.1f;
        rb.velocity = (dir * kb); 
    }

    void ShowDamage(int dealtDamage){
        GameObject text = Instantiate(damage, damageDisplay.transform.position, Quaternion.identity);
        text.GetComponent<DamageText>().damageText = dealtDamage.ToString();
        text.GetComponent<DamageText>().TextColor = new Color(1, 0, 0, 1);
    }
}
