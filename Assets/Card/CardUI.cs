using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public Image cardImage;
    private Transform targetParent;

    public void Init(Sprite sprite, Transform target)
    {
        cardImage.sprite = sprite;
        targetParent = target;
    }
   
    public void OnClick()
    {
        
        transform.SetParent(targetParent, false);
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
