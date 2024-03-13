# **| public class Paper :** [**Comportement**](../Base/Comportement.md) **|** [**↩️ Accueil**](../../../doc.md) **|** [**⬅️ Reynolds**](./Reynolds.md) **|**


## **Descriptif**

Classe pour comportement amorçant les règles énoncés dans cet [article](../../../../../media/paper.pdf). Hérite de [Comportement](../Base/Comportement.md)

## **Attributs**

---

* private static List< Vector3 > moves : liste des vecteurs déplacements possibles
* private static float activeSeuil : Critical real distance at which the FSRs are activated
* private static float changeRate : Change rate (0 < P_C < 1) for increasing and decreasing ideal distances, and stagnation and exile tolerance times
* private static float stagnationTolerance : Initial value of the stagnation tolerance time
* private static float exileTolerance : Initial value of the exile tolerance time
* private List<[Memory](#a)> memories : liste des mémoires courantes


---

## **Méthodes**

---

> public Paper([Agent](../../Agent.md) proprietaire)

* param a : agent proprietaire du comportement
* return : instance de comportement

---

> public override Vector3 reagir(List<[Observation](../../Vision/Observation.md)> observation);

* param observation : liste d'observations effectuées par le propriétaire
* return : un vecteur déplacement 

---

> private List< Vector3 > getTheMoves(List<[Observation](../../Vision/Observation.md)> observation)

* param observation : observations effectuées par l'agent propriétaire
* return : liste de vecteur candidats pour réponse réaction

---

> private Vector3 getTheMove(List< Vector3 > candidatesVectors)

* param candidatesVectors : vecteurs qui pourraient être une réponse réaction (résultat de getTheMoves)
* return : le déplacement de mieux adapté

---

> private void assumeTheMove(Vector3 themove,List<[Observation](../../Vision/Observation.md)> observation)

* param themove : le déplacement choisi
* param observation : observations effectuées par l'agent propriétaire
* effect : change la mémoire du comportement en conséquence du choix effectué

---

> private bool isAgent([Observation](../../Vision/Observation.md) o)

* param o : observation effectué
* return : si l'objet observé est un agent ou non

---

> private float computeDisatisfaction(Vector3 move, List<[Observation](../../Vision/Observation.md)> observation)

* param move : déplacement testé
* param observation : observations effectuées par l'agent propriétaire
* return : la disatisfaction du déplacement

---

> private void addAgentInMemory([Agent](../../Agent.md) concerned,float dist,float max, float reachDist)

* param concerned : agent qu'on rajoute en mémoire
* param dist : la distance à laquelle il se situe
* param max : la distance maximale où ils pourraient se situer
* param reachDist : la distance prévu
* effect : ajoute l'agent en mémoire

---

> private float idealDistance([Agent](../../Agent.md) other)

* param other : l'agent avec qui on calcule la distance idéale
* return : la distance idéal entre le propriétaire et l'agent other

---

<h2 id="a"><strong>Classe Interne : Memory</strong></h2>

### Descriptifs

Classe interne correspondant à une mémoire dyadic entre le propriétaire et un autre agent

### Attributs

---

* public [Agent](../../Agent.md) agent : agent en mémoire
* public float idealDistance : la distance idéale courante
* public float predictDistance : la distance prévue
* public float predictAttempt :  l'intention de déplacement
* public float stagnation : la stagnation courante
* public float exilation : l'exilation courante

---

### Méthodes

---

> public Memory([Agent](../../Agent.md) a, float ideal, float predict, float attempt)

* param a : agent en mémoire
* param ideal : distance idéale entre propriétaire et agent
* param predict : ditances prévu au prochain calcul de distances
* param attempt : attention de rapprochement (+-1)
* return : instance de memory

---
