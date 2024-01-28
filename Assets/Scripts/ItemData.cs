using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Flags]
public enum ItemPosition {
    none = 0,
    PetitObjet = 1 << 0,
    EnBas = 1 << 1,
    ObjetAManche = 1 << 2,
    Bouillote = 1 << 3,
    Gaz = 1 << 4,
    Telecommande = 1 << 5,
    Plumeau = 1 << 6,
    Parapluie = 1 << 7,
    Seau = 1 << 8,
    Chiffon = 1 << 9,
    Eponge = 1 << 10,
    LiquideVaisselle = 1 << 11,
}

[CreateAssetMenu()]
public class ItemData : ScriptableObject
{
    public Sprite sprite;
    public string description;

    public ItemPosition itemPosition;
}
