using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewDynamic : MonoBehaviour
{
    public Transform scrollViewContent;

    public GameObject prefab;

    public List<Sprite> listImg;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Sprite listImg_ in listImg)
        {
            GameObject newListImg = Instantiate(prefab, scrollViewContent);

            if (newListImg.TryGetComponent<ScrollViewItem>(out ScrollViewItem item))
            {
                item.ChangeImage(listImg_);
            }
        }
    }
}
