using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact_Object : MonoBehaviour
{
    [SerializeField] private string interactionKey;
    public GameObject player;
    public GameObject buttonSprite;
    public SpriteRenderer sr;
    public GameObject startPos;
    public GameObject endPos;
    private Color shownColor;
    private Color transparentColor;
    [SerializeField] private bool canInteract = false;

    // Start is called before the first frame update
    void Start()
    {
        transparentColor = sr.color;
        shownColor = new Color(transparentColor.r,transparentColor.g,transparentColor.b, 1);
        buttonSprite.transform.position = startPos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(canInteract){
            if(Input.GetKeyDown(interactionKey)){
                Debug.Log("starting interaction");
                startInteraction();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            canInteract = true;
            StopAllCoroutines();
            StartCoroutine(MoveUp(0.3f));
        }
    }
    
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            canInteract = false;
            StopAllCoroutines();
            StartCoroutine(MoveDown(0.3f));
        }
    }

    private IEnumerator MoveUp(float time){
        Vector3 startingPos = buttonSprite.transform.position;
        Vector3 finalPos = endPos.transform.position;
        float elapsedTime = 0;
         
        while (elapsedTime < time)
        {
            sr.color = Color.Lerp(transparentColor, shownColor, (elapsedTime / time));
            buttonSprite.transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator MoveDown(float time){
        Vector3 startingPos = buttonSprite.transform.position;
        Vector3 finalPos = startPos.transform.position;
        float elapsedTime = 0;

        while (elapsedTime < time)
        {
            sr.color = Color.Lerp(shownColor, transparentColor, (elapsedTime / time));
            buttonSprite.transform.position = Vector3.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    public virtual void startInteraction(){

    } 
}
