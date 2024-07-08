using System.Collections;

public interface IAttackable
{
    bool Attack(IDamagable target, float power, int numberOfAttacks);
}
public interface IDamagable
{

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