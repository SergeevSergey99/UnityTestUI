using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerPointManager : MonoBehaviour
{
    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _rightButton;
    [SerializeField] private SlideView _slideView;
    [Header("Слоты для слайдов")]
    [SerializeField] private Transform _slideSlotArea;
    [SerializeField] private Button _slideSlotPrefab;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _selectedColor;
    [Header("Данные слайдов")]
    [SerializeField] private SlideListData _slideListData;
    
    private int _currentSlideIndex = 0;
    private SlideData _currentSlideData => _slideListData[_currentSlideIndex];
    private List<Button> _slideSlots = new List<Button>();
    
    private void Awake()
    {
        _leftButton.onClick.AddListener(OnLeftButtonClicked);
        _rightButton.onClick.AddListener(OnRightButtonClicked);
        
        UpdateSlide();
        InitSlots();
    }

    void InitSlots()
    {
        foreach (Transform child in _slideSlotArea) Destroy(child.gameObject);
        
        _slideSlots = new List<Button>(_slideListData.Count);
        for (int i = 0; i < _slideListData.Count; i++)
        {
            var index = i;
            var slot = Instantiate(_slideSlotPrefab, _slideSlotArea);
            _slideSlots.Add(slot);
            slot.onClick.AddListener(() =>
            {
                _currentSlideIndex = index;
                UpdateSlideWithAnimation();
                UpdateSlotsColors();
            });
        }
        
        UpdateSlotsColors();
    }
    void UpdateSlotsColors()
    {
        for (int i = 0; i < _slideSlots.Count; i++)
        {
            _slideSlots[i].image.color = 
                i == _currentSlideIndex ? 
                    _selectedColor :
                    _defaultColor;
        }
    }
    void UpdateSlide()
    {
        CheckArrows();
        _slideView.SetSlideData(_currentSlideData);
    }
    void UpdateSlideWithAnimation()
    {
        CheckArrows();
        _slideView.SetSlideDataWithAnimation(_currentSlideData);
    }
    
    #region Arrow Buttons
    void OnLeftButtonClicked()
    {
        _currentSlideIndex--;
        UpdateSlideWithAnimation();
    }
    void OnRightButtonClicked()
    {
        _currentSlideIndex++;
        UpdateSlideWithAnimation();
    }

    public void CheckArrows()
    {
        _leftButton.interactable = _currentSlideIndex > 0;
        _rightButton.interactable = _currentSlideIndex < _slideListData.Count - 1;
    }
    #endregion
}

