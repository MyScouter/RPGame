
using UnityEngine;
using UnityEngine.AI;

public class CharactersAnimator : MonoBehaviour
{
    public AnimationClip replaceableAttackAnim;
    public AnimationClip[] deafultAttackAnimSet; 
    protected AnimationClip[] currentAttackAnimSet;
    const float locomationAnimationSmoothTime = .1f;
    NavMeshAgent agent;
    protected Animator animator;
    protected CharacterCombat combat;
    public AnimatorOverrideController overrideController;
    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        combat = GetComponent<CharacterCombat>();

        if (overrideController == null)
            overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = overrideController;

        currentAttackAnimSet = deafultAttackAnimSet;
        combat.OnAttack += OnAttack;
    }

    
    protected virtual void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, locomationAnimationSmoothTime, Time.deltaTime);

        animator.SetBool("inCombat", combat.inCombat);
    }

    protected virtual void OnAttack() {
        animator.SetTrigger("attack");
        int attackIndex = Random.Range(0, currentAttackAnimSet.Length);
        overrideController[replaceableAttackAnim.name] = currentAttackAnimSet[attackIndex];
    }
}
