//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Controls.inputactions
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

public partial class @Controls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""controls_proto"",
            ""id"": ""7530e711-cbf8-47f0-a09a-92241010946d"",
            ""actions"": [
                {
                    ""name"": ""LMB"",
                    ""type"": ""Button"",
                    ""id"": ""b97280a8-1842-431c-bd12-2ce2c6935abe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MousePos"",
                    ""type"": ""Value"",
                    ""id"": ""0ff8b3c8-41aa-4a3a-a295-bfc57beaaabd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Direction"",
                    ""type"": ""Value"",
                    ""id"": ""99446f37-2183-448d-aec6-8a38dd5a6acf"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9b9739ac-bcf0-4d34-aa7f-b6477948a39c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LMB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""2d7c8517-e3b1-4b98-aedc-b1702e596149"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""3c34f113-95c6-4885-ac54-27dc808d263b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""096efc28-7369-4041-951f-1349f8a2a928"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Direction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""05206414-999f-4a5a-a488-b887a676b58a"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // controls_proto
        m_controls_proto = asset.FindActionMap("controls_proto", throwIfNotFound: true);
        m_controls_proto_LMB = m_controls_proto.FindAction("LMB", throwIfNotFound: true);
        m_controls_proto_MousePos = m_controls_proto.FindAction("MousePos", throwIfNotFound: true);
        m_controls_proto_Direction = m_controls_proto.FindAction("Direction", throwIfNotFound: true);
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

    // controls_proto
    private readonly InputActionMap m_controls_proto;
    private IControls_protoActions m_Controls_protoActionsCallbackInterface;
    private readonly InputAction m_controls_proto_LMB;
    private readonly InputAction m_controls_proto_MousePos;
    private readonly InputAction m_controls_proto_Direction;
    public struct Controls_protoActions
    {
        private @Controls m_Wrapper;
        public Controls_protoActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LMB => m_Wrapper.m_controls_proto_LMB;
        public InputAction @MousePos => m_Wrapper.m_controls_proto_MousePos;
        public InputAction @Direction => m_Wrapper.m_controls_proto_Direction;
        public InputActionMap Get() { return m_Wrapper.m_controls_proto; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Controls_protoActions set) { return set.Get(); }
        public void SetCallbacks(IControls_protoActions instance)
        {
            if (m_Wrapper.m_Controls_protoActionsCallbackInterface != null)
            {
                @LMB.started -= m_Wrapper.m_Controls_protoActionsCallbackInterface.OnLMB;
                @LMB.performed -= m_Wrapper.m_Controls_protoActionsCallbackInterface.OnLMB;
                @LMB.canceled -= m_Wrapper.m_Controls_protoActionsCallbackInterface.OnLMB;
                @MousePos.started -= m_Wrapper.m_Controls_protoActionsCallbackInterface.OnMousePos;
                @MousePos.performed -= m_Wrapper.m_Controls_protoActionsCallbackInterface.OnMousePos;
                @MousePos.canceled -= m_Wrapper.m_Controls_protoActionsCallbackInterface.OnMousePos;
                @Direction.started -= m_Wrapper.m_Controls_protoActionsCallbackInterface.OnDirection;
                @Direction.performed -= m_Wrapper.m_Controls_protoActionsCallbackInterface.OnDirection;
                @Direction.canceled -= m_Wrapper.m_Controls_protoActionsCallbackInterface.OnDirection;
            }
            m_Wrapper.m_Controls_protoActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LMB.started += instance.OnLMB;
                @LMB.performed += instance.OnLMB;
                @LMB.canceled += instance.OnLMB;
                @MousePos.started += instance.OnMousePos;
                @MousePos.performed += instance.OnMousePos;
                @MousePos.canceled += instance.OnMousePos;
                @Direction.started += instance.OnDirection;
                @Direction.performed += instance.OnDirection;
                @Direction.canceled += instance.OnDirection;
            }
        }
    }
    public Controls_protoActions @controls_proto => new Controls_protoActions(this);
    public interface IControls_protoActions
    {
        void OnLMB(InputAction.CallbackContext context);
        void OnMousePos(InputAction.CallbackContext context);
        void OnDirection(InputAction.CallbackContext context);
    }
}
