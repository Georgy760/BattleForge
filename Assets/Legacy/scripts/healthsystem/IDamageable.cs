using System;

namespace Legacy.scripts.healthsystem
{
    public interface IDamageable
    {
        float MaxHealth { get; set; }
        float MinHealth { get; set; }
        float CurrentHealth { get; set; }

        float CurrentHealthNormalized { get; }

        event EventHandler HealthChanged;
        event EventHandler HealthDepleted;

        void ReduceHealthPoints(float amount);
        void RestoreHealthPoints(float amount);
    }
}