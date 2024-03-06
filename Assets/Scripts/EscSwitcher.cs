using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EscSwitcher : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject Esc;
    public Animator Anim;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Anim.SetTrigger("OpenEsc");
        Debug.Log("Working");
        //Esc.SetActive(true);

    }
    public void OnPointerExit(PointerEventData eventData)
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
