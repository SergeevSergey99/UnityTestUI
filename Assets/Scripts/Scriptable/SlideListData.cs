using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SlideListData", menuName = "Scriptable/SlideListData", order = 1)]
public class SlideListData : ScriptableObject
{
    [SerializeField] private List<SlideData> slides;
    public int Count { get => slides.Count; }
    public SlideData this[int index] { get => slides[index]; }
}
