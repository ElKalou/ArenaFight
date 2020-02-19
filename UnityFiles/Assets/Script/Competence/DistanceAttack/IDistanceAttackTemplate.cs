public interface IDistanceAttackTemplate : ICompetenceTemplate
{
    Projectile projectile { get; }
    float damage { get; }
    ProjectilePool projectilePool { get; }
}