using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using Common;
using Zenject;

public class PlayerController : MonoBehaviour
{
    public AttackDefinition demoAttack;
    public Aoe aoeStompAttack;

    Animator animator;
    NavMeshAgent agent;
    CharacterStats stats;

    private GameObject attackTarget;
    private IControllerService _controllerService;

    [Inject]
    private void Construct(IControllerService controllerService)
    {
        _controllerService = controllerService;

        _controllerService.OnControllerHold += SetDestination;
        _controllerService.OnAttackClicked += AttackTarget;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        stats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    private void OnDestroy()
    {
        _controllerService.OnControllerHold -= SetDestination;
        _controllerService.OnAttackClicked -= AttackTarget;
    }

    private void SetDestination(Vector2 input)
    {
        Debug.Log("Vector2: " + input);
        StopAllCoroutines();
        if (Mathf.Abs(input.y) > 0.01f)
        {
            Vector3 destination = transform.position + transform.right * input.x + transform.forward * input.y;
            agent.destination = destination;
        }
        else
        {
            agent.destination = transform.position;
            transform.Rotate(0, input.x * agent.angularSpeed * Time.deltaTime, 0);
        }
        agent.isStopped = false;
        
    }

    private void DoStomp(Vector3 destination)
    {
        StopAllCoroutines();
        agent.isStopped = false;
        StartCoroutine(GoToTargetAndStomp(destination));
    }

    private void AttackTarget(GameObject target)
    {
        var weapon = stats.GetCurrentWeapon();

        if(weapon != null)
        {
            StopAllCoroutines();

            agent.isStopped = false;
            attackTarget = target;
            StartCoroutine(PursueAndAttackTarget());
        }
    }

    private IEnumerator GoToTargetAndStomp(Vector3 destination)
    {
        while(Vector3.Distance(transform.position, destination) > aoeStompAttack.Range)
        {
            agent.destination = destination;
            yield return null;
        }
        agent.isStopped = true;
        animator.SetTrigger("Stomp");
    }

    private IEnumerator PursueAndAttackTarget()
    {
        agent.isStopped = false;
        var weapon = stats.GetCurrentWeapon();

        while(Vector3.Distance(transform.position, attackTarget.transform.position) > weapon.Range)
        {
            agent.destination = attackTarget.transform.position;
            yield return null;
        }

        agent.isStopped = true;

        transform.LookAt(attackTarget.transform);
        animator.SetTrigger("Attack");
    }

    public void Hit()
    {
        // Have our weapon attack the attack target
        if (attackTarget != null)
            stats.GetCurrentWeapon().ExecuteAttack(gameObject, attackTarget);
    }

    public void Stomp()
    {
        aoeStompAttack.Fire(gameObject, gameObject.transform.position, LayerMask.NameToLayer("PlayerSpells"));
    }
}