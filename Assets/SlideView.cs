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
    [SerializeField] private Transform _slideArea;
    [SerializeField] private float _animationTime = 0.2f;
    PowerPointManager _powerPointManager;
    public void Init(SlideData slideData, PowerPointManager powerPointManager)
    {
        _powerPointManager = powerPointManager;
        SetSlideData(slideData);
    }
    private void SetSlideData(SlideData slideData)
    {
        _titleText.text = slideData.title;
        _image.sprite = slideData.sprite;
        _aspectRatioFitter.aspectRatio = slideData.sprite == null ? 1 : (float)slideData.sprite.texture.width / slideData.sprite.texture.height;
        _descriptionText.text = slideData.description;
        _powerPointManager.UpdateSlotsColors();
    }
    
    // Не хочу портировать DOTween в этот проект, поэтому просто корутина
    Coroutine _coroutine;
    public void SetSlideDataWithAnimation(SlideData slideData)
    {
        if (_coroutine != null) StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(SettingWithAnimation(slideData));
    }
    IEnumerator SettingWithAnimation(SlideData slideData)
    {
        float time = 0;
        var startRotation = _slideArea.localRotation.eulerAngles;
        while (time < _animationTime / 2)
        {
            _slideArea.localRotation = Quaternion.Euler(Vector3.Lerp(startRotation, Vector3.back*180, time / (_animationTime / 2)));
            time += Time.deltaTime;
            yield return null;
        }
        
        SetSlideData(slideData);

        while (time < _animationTime)
        {
            _slideArea.localRotation = Quaternion.Euler(Vector3.Lerp(Vector3.forward*180, Vector3.zero, (time - _animationTime / 2) / (_animationTime / 2)));
            time += Time.deltaTime;
            yield return null;
        }
        _slideArea.localRotation = Quaternion.Euler(Vector3.zero);
    }
}
