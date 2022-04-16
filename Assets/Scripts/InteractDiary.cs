using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDiary : Interact_Object
{
    public GameObject DiaryMenu;
    [SerializeField] private bool MenuIsActive = false;
    [SerializeField] private bool bookIsAnimated = false;
    public override void startInteraction()
    {
        if(bookIsAnimated == false){
            if(MenuIsActive == false){
                StartCoroutine(openBook());
            }else{
                StartCoroutine(closeBook());
            }
        }
    }
    IEnumerator openBook(){
        bookIsAnimated = true;
        DiaryMenu.SetActive(true);
        MenuIsActive = true;
        DiaryMenu.GetComponent<Animator>().Play("diary_open");
        yield return new WaitForSeconds(0.7f);
        bookIsAnimated = false;
    }
    IEnumerator closeBook(){
        bookIsAnimated = true;
        DiaryMenu.GetComponent<Animator>().Play("diary_close");
        yield return new WaitForSeconds(0.7f);
        DiaryMenu.SetActive(false);
        MenuIsActive = false; 
        bookIsAnimated = false;
    }
}
