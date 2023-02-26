using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MaterialSwapper : MonoBehaviour {
    [SerializeField] Material[] materials;
    Renderer renderer;

    ControlScheme controls;
    InputAction set1, set2, set3, set4;

    void Awake(){
        renderer = this.GetComponent<Renderer>();
        controls = new ControlScheme();

        //Initialize inputs
        set1 = controls.Materials.SetDiffuseWrap;
        set1.Enable();
        if(materials.Length >= 1){
            set1.performed += ctx => SetMaterial(materials[0]);
        }

        set2 = controls.Materials.SetSpecular;
        set2.Enable();
        if(materials.Length >= 2){
            set2.performed += ctx => SetMaterial(materials[1]);
        }

        set3 = controls.Materials.SetSpecial1;
        set3.Enable();
        if(materials.Length >= 3){
            set3.performed += ctx => SetMaterial(materials[2]);
        }

        set4 = controls.Materials.SetSpecial2;
        set4.Enable();
        if(materials.Length >= 4){
            set4.performed += ctx => SetMaterial(materials[3]);
        }
    }

    void SetMaterial(Material newMat){
        if(renderer != null){
            renderer.material = newMat;
        }
    }
}