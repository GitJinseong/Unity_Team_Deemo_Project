using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewItem : MonoBehaviour
{
    public Image childImage;

    public void ChangeImage(Sprite image)
    {
        childImage.sprite = image;
    }
}
