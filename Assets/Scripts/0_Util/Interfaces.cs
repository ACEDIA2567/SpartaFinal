using System.Collections;

public interface IAttackable
{
    string attackType { get; }
    float attackPower { get; }
    bool Attack(IDamagable target, float power, int numberOfAttacks);
}
public interface IDamagable
{
    string armorTypeName { get; }
    float armorValue { get; }

    IEnumerator ApplyDamage(float dmg);
}

public interface IState
{
    public void Enter();
    public void Exit();
//    public void HandleInput();
//    public void Update();
//    public void FixedUpdate();
}