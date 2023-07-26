using System.Linq;
using _Strategy._Main.Abstractions;
using _Strategy._Main.UserControlSystem.UI.Model;
using UnityEngine;
using UnityEngine.EventSystems;


namespace _Strategy._Main.UserControlSystem.UI.Presenter
{
    
    internal sealed class MouseInteractionsPresenter : MonoBehaviour
    {

        [SerializeField] private EventSystem _eventSystem;
        [SerializeField] private Camera _camera;
        [SerializeField] private SelectableValue _selectedObject;
        
        [SerializeField] private Vector3Value _groundClicksRMB;
        [SerializeField] private AttackableValue _attackablesRMB;
        [SerializeField] private Transform _groundTransform;

        private Plane _groundPlane;


        private void Start()
        {
            _groundPlane = new Plane(_groundTransform.up, 0.0f);
        }


        private void Update()
        {
            HandleMouseButtonPressed();
        }

        
        private void HandleMouseButtonPressed()
        {
            if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
            {
                if (!_eventSystem.IsPointerOverGameObject())
                {
                    var ray = _camera.ScreenPointToRay(Input.mousePosition);

                    if (Input.GetMouseButtonUp(0))
                    {
                        var hits = Physics.RaycastAll(ray);
                        
                        if (HitByInterface<ISelectable>(hits, out var selectable))
                            _selectedObject.SetValue(selectable);
                        
                        if (HitByInterface<IAttackable>(hits, out var attackable))
                            _attackablesRMB.SetValue(attackable);
                    }
                    else
                    {
                        if (_groundPlane.Raycast(ray, out var enter))
                        {
                            _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
                        }
                    }
                }
            }
        }


        private bool HitByInterface<T>(RaycastHit[] hits, out T result) where T : class
        {
            result = default;
            
            if (hits.Length > 0)
            {
                result = hits
                    .Select(hit => hit.collider.GetComponentInParent<T>())
                    .FirstOrDefault(s => s != null);
            }
            return result != default;
        }
    
        
    }
}

