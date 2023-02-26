using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void LookAt();
    void StopLookAt();

    void ButtonInteract();
}

public class Interactable : MonoBehaviour, IInteractable
{
    private Color LookAtColor => Color.black;
    private Color DefaultColor => Color.white;


    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }


    public void LookAt()
    {
        if (_renderer == null)
        {
            return;
        }
        
        _renderer.material.SetColor("_RimColor", LookAtColor);
    }

    public void StopLookAt()
    {
        if (_renderer == null)
        {
            return;
        }
        
        _renderer.material.SetColor("_RimColor", DefaultColor);
    }

    public void ButtonInteract()
    {
        Player.OrbsCollected++;
        
        Destroy(gameObject);
    }
}
