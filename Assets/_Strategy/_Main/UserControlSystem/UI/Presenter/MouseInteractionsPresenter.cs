using System.Linq;
using _Strategy._Main.Abstractions;
using _Strategy._Main.UserControlSystem.UI.Model;
using UnityEngine;


namespace _Strategy._Main.UserControlSystem.UI.Presenter
{
    
    internal sealed class MouseInteractionsPresenter : MonoBehaviour
    {

        [SerializeField] private Camera _camera;
        [SerializeField] private SelectableValue _selectedObject;

        private void Update()
        {
            HandleMouseButtonPressed();
        }

    
        private void HandleMouseButtonPressed()
        {
            if (Input.GetMouseButtonUp(0))
            {

                var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));
                if (hits.Length > 0)
                {
                    var selectable = hits
                        .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
                        .FirstOrDefault(s => s != null);

                    _selectedObject.SetValue(selectable);
                }
            }
        }
    
    }
}
