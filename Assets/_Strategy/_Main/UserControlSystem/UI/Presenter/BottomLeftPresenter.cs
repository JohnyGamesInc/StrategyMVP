using _Strategy._Main.Abstractions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using _Strategy._Main.UserControlSystem.UI.Model;


namespace _Strategy._Main.UserControlSystem.UI.Presenter
{
    
    internal sealed class BottomLeftPresenter : MonoBehaviour
    {

        [SerializeField] private Image _selectedImage;
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private Image _sliderBackground;
        [SerializeField] private Image _sliderFillImage;
        [SerializeField] private Image _healthBackground;
        [SerializeField] private SelectableValue _selectableValue;

        
        
        private void Start()
        {

            _selectableValue.OnNewValueSubscription += OnNewValueSelectSubscribe;
            OnNewValueSelectSubscribe(_selectableValue.CurrentValue);
        }


        private void OnDestroy()
        {
            _selectableValue.OnNewValueSubscription -= OnNewValueSelectSubscribe;
        }


        private void OnNewValueSelectSubscribe(ISelectable selected)
        {
            _selectedImage.enabled = selected != null;
            _healthSlider.gameObject.SetActive(selected != null);
            _healthText.enabled = selected != null;
            _healthBackground.gameObject.SetActive(selected != null);

            if (selected != null)
            {
                _selectedImage.sprite = selected.Icon;
                _healthText.text = $"{selected.Health} / {selected.MaxHealth}";
                _healthSlider.minValue = 0;
                _healthSlider.maxValue = selected.MaxHealth;
                _healthSlider.value = selected.Health;

                var color = Color.Lerp(Color.red, Color.green, selected.Health / selected.MaxHealth);
                _sliderBackground.color = color * 0.5f;
                _sliderFillImage.color = color;
            }
        }
        
        

    }
}