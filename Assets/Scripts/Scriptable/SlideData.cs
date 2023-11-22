using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SlideData", menuName = "Scriptable/SlideData", order = 1)]
public class SlideData : ScriptableObject
{
    [SerializeField] private string _title;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _sprite;
    
    public string title { get => _title; }
    public string description { get => _description; }
    public Sprite sprite { get => _sprite; }
}
