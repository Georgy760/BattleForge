using System;
using DG.Tweening;
using progressbar;
using UnityEngine;
using Zenject;

namespace healthsystem
{
    public class HealthBar : MonoBehaviour, IDamageable
    {
        [SerializeField] private SliderProgressBar _healthBarDisplay;
        [SerializeField] private SliderProgressBar _healthBarPreviewDisplay;
        private IDamageable _damageable;

        public HealthBar(IDamageable damageable)
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


        public float MaxHealth
        {
            get => _damageable.MaxHealth;
            set => _damageable.MaxHealth = value;
        }

        public float MinHealth
        {
            get => _damageable.MinHealth;
            set => _damageable.MinHealth = value;
        }

        public float CurrentHealth
        {
            get => _damageable.CurrentHealth;
            set => _damageable.CurrentHealth = value;
        }

        public float CurrentHealthNormalized => _damageable.CurrentHealthNormalized;

        public event EventHandler HealthChanged
        {
            add => _damageable.HealthChanged += value;
            remove => _damageable.HealthChanged -= value;
        }

        public event EventHandler HealthDepleted
        {
            add => _damageable.HealthDepleted += value;
            remove => _damageable.HealthDepleted -= value;
        }

        public void ReduceHealthPoints(float amount)
        {
            _damageable.ReduceHealthPoints(amount);
        }

        public void RestoreHealthPoints(float amount)
        {
            _damageable.RestoreHealthPoints(amount);
        }
    }
}