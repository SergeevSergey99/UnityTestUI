using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlideView : MonoBehaviour
{
    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _descriptionText;
    [SerializeField] private AspectRatioFitter _aspectRatioFitter;
    public void SetSlideData(SlideData slideData)
    {
        _titleText.text = slideData.title;
        _image.sprite = slideData.sprite;
        _aspectRatioFitter.aspectRatio = slideData.sprite == null ? 1 : (float)slideData.sprite.texture.width / slideData.sprite.texture.height;
        _descriptionText.text = slideData.description;
    }
}
