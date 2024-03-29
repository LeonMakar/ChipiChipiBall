//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/InputMap/DefaultActionMap.inputactions
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

public partial class @DefaultActionMap: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @DefaultActionMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DefaultActionMap"",
    ""maps"": [
        {
            ""name"": ""Simple"",
            ""id"": ""71fe35e4-f3b7-4a99-955b-b907c09f1bf0"",
            ""actions"": [
                {
                    ""name"": ""Mooving"",
                    ""type"": ""Value"",
                    ""id"": ""78116f96-0f12-43cb-a538-a52924e19d7e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""b5cffd3b-5426-467c-b103-1722d591adcf"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mooving"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""4a708d4b-4ce5-41e0-b9da-9e1aa24d42d8"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Mooving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""6c5b9ae8-c696-402e-bbdb-041c31010ff7"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Mooving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""1b5dcc2f-afe3-47c3-8f85-6650e50e0324"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mooving"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""878be1b4-ded7-491a-becb-7b07613d1720"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyBoard"",
                    ""action"": ""Mooving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""22a73095-2dd2-40bc-8b6c-72bb9bd8c60f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyBoard"",
                    ""action"": ""Mooving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""5a5aeeef-9970-44ec-bbe6-4f6639437ac1"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mooving"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""41069bcd-7918-42b7-9ae4-7bc75394f49d"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyBoard"",
                    ""action"": ""Mooving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""70f20108-079a-4da1-b43c-8a8c715fd9a4"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""MouseAndKeyBoard"",
                    ""action"": ""Mooving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""067c4807-1368-4e10-baab-8a3937d465d5"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mooving"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""MouseAndKeyBoard"",
            ""bindingGroup"": ""MouseAndKeyBoard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Simple
        m_Simple = asset.FindActionMap("Simple", throwIfNotFound: true);
        m_Simple_Mooving = m_Simple.FindAction("Mooving", throwIfNotFound: true);
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

    // Simple
    private readonly InputActionMap m_Simple;
    private List<ISimpleActions> m_SimpleActionsCallbackInterfaces = new List<ISimpleActions>();
    private readonly InputAction m_Simple_Mooving;
    public struct SimpleActions
    {
        private @DefaultActionMap m_Wrapper;
        public SimpleActions(@DefaultActionMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mooving => m_Wrapper.m_Simple_Mooving;
        public InputActionMap Get() { return m_Wrapper.m_Simple; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SimpleActions set) { return set.Get(); }
        public void AddCallbacks(ISimpleActions instance)
        {
            if (instance == null || m_Wrapper.m_SimpleActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_SimpleActionsCallbackInterfaces.Add(instance);
            @Mooving.started += instance.OnMooving;
            @Mooving.performed += instance.OnMooving;
            @Mooving.canceled += instance.OnMooving;
        }

        private void UnregisterCallbacks(ISimpleActions instance)
        {
            @Mooving.started -= instance.OnMooving;
            @Mooving.performed -= instance.OnMooving;
            @Mooving.canceled -= instance.OnMooving;
        }

        public void RemoveCallbacks(ISimpleActions instance)
        {
            if (m_Wrapper.m_SimpleActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ISimpleActions instance)
        {
            foreach (var item in m_Wrapper.m_SimpleActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_SimpleActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public SimpleActions @Simple => new SimpleActions(this);
    private int m_MouseAndKeyBoardSchemeIndex = -1;
    public InputControlScheme MouseAndKeyBoardScheme
    {
        get
        {
            if (m_MouseAndKeyBoardSchemeIndex == -1) m_MouseAndKeyBoardSchemeIndex = asset.FindControlSchemeIndex("MouseAndKeyBoard");
            return asset.controlSchemes[m_MouseAndKeyBoardSchemeIndex];
        }
    }
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    public interface ISimpleActions
    {
        void OnMooving(InputAction.CallbackContext context);
    }
}
