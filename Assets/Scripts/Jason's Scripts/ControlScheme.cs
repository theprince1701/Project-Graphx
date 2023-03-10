//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Jason's Scripts/ControlScheme.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @ControlScheme : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @ControlScheme()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ControlScheme"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""c6763a80-b2e2-449b-a09e-04bc9ad90241"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""f605799d-e609-48fc-a03e-dc1eaa1b8109"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Button"",
                    ""id"": ""ea9a612d-7da0-407f-b8e4-cba363344a30"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""4d6c5575-87b4-413a-a74b-f5ec3ad02bfc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""ae89dd4a-a543-4dd8-ac63-93f25ee7d4f7"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6c216392-0e3f-4677-8c85-deacfcb2160c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""15359be5-f4c3-40a5-be3b-185bc408b603"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""23aa3957-d448-46e8-bd21-08b6bd353c52"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""bfdf2f1d-a449-441c-9eac-3151817ca8c7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8681339b-c18d-44d5-9e64-7d6f5b73c72f"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b52bfbfb-9ae3-4077-9158-62b1dd942420"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Materials"",
            ""id"": ""c373ffc8-110f-4250-9e0a-ba1d9029935d"",
            ""actions"": [
                {
                    ""name"": ""SetDiffuseWrap"",
                    ""type"": ""Button"",
                    ""id"": ""282aa859-2c99-43c0-a29d-12237a718335"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SetSpecular"",
                    ""type"": ""Button"",
                    ""id"": ""43a400a1-4266-479e-843c-370b93488b4e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SetSpecial1"",
                    ""type"": ""Button"",
                    ""id"": ""02402fce-7409-4d36-a223-737adb4fb0a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SetSpecial2"",
                    ""type"": ""Button"",
                    ""id"": ""5c4b19a0-5436-4088-a89d-64c0143e49cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7d7671da-db78-4e6c-9a7c-2acaf8bb27a9"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SetDiffuseWrap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""437b5b99-a00f-4338-b737-b66ae2dae32c"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SetSpecular"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be4e403b-0c91-461a-9577-5868d41458d0"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SetSpecial1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54dd211d-2bd7-40a8-bcae-609cdc00d6e0"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SetSpecial2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
        m_Player_Shoot = m_Player.FindAction("Shoot", throwIfNotFound: true);
        // Materials
        m_Materials = asset.FindActionMap("Materials", throwIfNotFound: true);
        m_Materials_SetDiffuseWrap = m_Materials.FindAction("SetDiffuseWrap", throwIfNotFound: true);
        m_Materials_SetSpecular = m_Materials.FindAction("SetSpecular", throwIfNotFound: true);
        m_Materials_SetSpecial1 = m_Materials.FindAction("SetSpecial1", throwIfNotFound: true);
        m_Materials_SetSpecial2 = m_Materials.FindAction("SetSpecial2", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Look;
    private readonly InputAction m_Player_Shoot;
    public struct PlayerActions
    {
        private @ControlScheme m_Wrapper;
        public PlayerActions(@ControlScheme wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Look => m_Wrapper.m_Player_Look;
        public InputAction @Shoot => m_Wrapper.m_Player_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Look.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Shoot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Materials
    private readonly InputActionMap m_Materials;
    private IMaterialsActions m_MaterialsActionsCallbackInterface;
    private readonly InputAction m_Materials_SetDiffuseWrap;
    private readonly InputAction m_Materials_SetSpecular;
    private readonly InputAction m_Materials_SetSpecial1;
    private readonly InputAction m_Materials_SetSpecial2;
    public struct MaterialsActions
    {
        private @ControlScheme m_Wrapper;
        public MaterialsActions(@ControlScheme wrapper) { m_Wrapper = wrapper; }
        public InputAction @SetDiffuseWrap => m_Wrapper.m_Materials_SetDiffuseWrap;
        public InputAction @SetSpecular => m_Wrapper.m_Materials_SetSpecular;
        public InputAction @SetSpecial1 => m_Wrapper.m_Materials_SetSpecial1;
        public InputAction @SetSpecial2 => m_Wrapper.m_Materials_SetSpecial2;
        public InputActionMap Get() { return m_Wrapper.m_Materials; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MaterialsActions set) { return set.Get(); }
        public void SetCallbacks(IMaterialsActions instance)
        {
            if (m_Wrapper.m_MaterialsActionsCallbackInterface != null)
            {
                @SetDiffuseWrap.started -= m_Wrapper.m_MaterialsActionsCallbackInterface.OnSetDiffuseWrap;
                @SetDiffuseWrap.performed -= m_Wrapper.m_MaterialsActionsCallbackInterface.OnSetDiffuseWrap;
                @SetDiffuseWrap.canceled -= m_Wrapper.m_MaterialsActionsCallbackInterface.OnSetDiffuseWrap;
                @SetSpecular.started -= m_Wrapper.m_MaterialsActionsCallbackInterface.OnSetSpecular;
                @SetSpecular.performed -= m_Wrapper.m_MaterialsActionsCallbackInterface.OnSetSpecular;
                @SetSpecular.canceled -= m_Wrapper.m_MaterialsActionsCallbackInterface.OnSetSpecular;
                @SetSpecial1.started -= m_Wrapper.m_MaterialsActionsCallbackInterface.OnSetSpecial1;
                @SetSpecial1.performed -= m_Wrapper.m_MaterialsActionsCallbackInterface.OnSetSpecial1;
                @SetSpecial1.canceled -= m_Wrapper.m_MaterialsActionsCallbackInterface.OnSetSpecial1;
                @SetSpecial2.started -= m_Wrapper.m_MaterialsActionsCallbackInterface.OnSetSpecial2;
                @SetSpecial2.performed -= m_Wrapper.m_MaterialsActionsCallbackInterface.OnSetSpecial2;
                @SetSpecial2.canceled -= m_Wrapper.m_MaterialsActionsCallbackInterface.OnSetSpecial2;
            }
            m_Wrapper.m_MaterialsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SetDiffuseWrap.started += instance.OnSetDiffuseWrap;
                @SetDiffuseWrap.performed += instance.OnSetDiffuseWrap;
                @SetDiffuseWrap.canceled += instance.OnSetDiffuseWrap;
                @SetSpecular.started += instance.OnSetSpecular;
                @SetSpecular.performed += instance.OnSetSpecular;
                @SetSpecular.canceled += instance.OnSetSpecular;
                @SetSpecial1.started += instance.OnSetSpecial1;
                @SetSpecial1.performed += instance.OnSetSpecial1;
                @SetSpecial1.canceled += instance.OnSetSpecial1;
                @SetSpecial2.started += instance.OnSetSpecial2;
                @SetSpecial2.performed += instance.OnSetSpecial2;
                @SetSpecial2.canceled += instance.OnSetSpecial2;
            }
        }
    }
    public MaterialsActions @Materials => new MaterialsActions(this);
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
    public interface IMaterialsActions
    {
        void OnSetDiffuseWrap(InputAction.CallbackContext context);
        void OnSetSpecular(InputAction.CallbackContext context);
        void OnSetSpecial1(InputAction.CallbackContext context);
        void OnSetSpecial2(InputAction.CallbackContext context);
    }
}
