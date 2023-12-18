public interface IDamageDealer
{
    public int DamageValue { get; }
    public void DoDamage(IHealth healthSystem);
}
