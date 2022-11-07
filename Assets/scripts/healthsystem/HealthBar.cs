using System;
using DG.Tweening;
using progressbar;
using UnityEngine;
using Zenject;

namespace healthsystem
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private SliderProgressBar _healthBarDisplay;
        [SerializeField] private SliderProgressBar _healthBarPreviewDisplay;
        private IDamageable _damageable = new HealthData(100, 0 , 100);

        [Inject]
        public void Construct(IDamageable damageable)
        {
            _damageable = damageable;

            _healthBarDisplay.MinFillAmount = damageable.MinHealth;
            _healthBarDisplay.MaxFillAmount = damageable.MaxHealth;
            _healthBarDisplay.CurrentFillAmount = damageable.CurrentHealth;

            _healthBarPreviewDisplay.MinFillAmount = damageable.MinHealth;
            _healthBarPreviewDisplay.MaxFillAmount = damageable.MaxHealth;
            _healthBarPreviewDisplay.CurrentFillAmount = damageable.CurrentHealth;

            _damageable.HealthChanged += (sender, args) => UpdateHealthDisplay();
        }

        private void UpdateHealthDisplay()
        {
            //healing
            if (_damageable.CurrentHealthNormalized > _healthBarDisplay.GetCurrentFillPercentage() / 100f)
            {
                _healthBarPreviewDisplay.SetFillAmountImmediate(_damageable.CurrentHealth);
                _healthBarDisplay.SetFillAmountTween(_damageable.CurrentHealth, 1, Ease.InOutCubic);
            }
            else
            {
                //taking damage
                _healthBarDisplay.SetFillAmountImmediate(_damageable.CurrentHealth);
                _healthBarPreviewDisplay.SetFillAmountTween(_damageable.CurrentHealth, 1, Ease.InOutCubic);
            }
        }

        public float MaxHealth { get; set; }
        public float MinHealth { get; set; }
        public float CurrentHealth { get; set; }
        public float CurrentHealthNormalized { get; }
        public event EventHandler HealthChanged;
        public event EventHandler HealthDepleted;
        public void ReduceHealthPoints(float amount)
        {
            throw new NotImplementedException();
        }

        public void RestoreHealthPoints(float amount)
        {
            throw new NotImplementedException();
        }
    }
}