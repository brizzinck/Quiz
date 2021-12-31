using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cells/Cell", fileName = "New Cell")]
public class CellData : ScriptableObject
{
    [SerializeField] private string _identifier;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private float _rotationSprite = 0;
    [SerializeField] private float _sizeSprite = 2.5f;
    public string Identifier { get => _identifier; }
    public Sprite Sprite { get => _sprite; }
    public float RotationSprite { get => _rotationSprite; }
    public float SizeSprite { get => _sizeSprite; }
}