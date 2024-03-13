# **| public class Agent : MonoBehaviour,** [**Visible**](./Vision/Visible.md) **|** [**↩️ Accueil**](../doc.md) **|** [**⬅️ SMA**](SMA.md) **|** [**➡️ Visible**](./Vision/Visible.md) **|**

## **Descriptif**

Classe correspondant à un Agent Boïd de la simulation. Il hérite de MonoBehaviour car il évoluera et intéragira avec l'environnement et les autres agents. Il implémente l'interface Visible car un agent est un objet visible. 

## **Attributs**

---

* private [SMA](SMA.md) system : système auquel l'agent appartient
* private [Comportement](Comportement/Base/Comportement.md) comportement : comportement de l'agent
* private [Perception](Perception/Perception.md) perception : perception de l'agent
* public Vector3 deplacement : deplacement courant de l'agent
* private static int count : nombre d'Agents créés (pour identification des agents)
* private int id : identifiant de l'agent

---

## **Méthodes**

---

> public [SMA](SMA.md) getSystem() 

* return : le système auquel l'agent appartient

---

> public bool isAlive()

* return : s'il est un Visible mobile

---

> public void setPerception([Perception](Perception/Perception.md) p)

* param p : perception à donner à l'agent
* effect : utilise la perception p en tant que nouvelle perception de l'agent

---

> public void setComportement([Comportement](Comportement/Base/Comportement.md) c)

* param c : comportement à donner à l'agent
* effect : utilise le comportement c en tant que nouveau comportement de l'agent

---

> void Start()

* effect : dû à l'héritage de MonoBehaviour, est appelé avant la première image affichée de l'agent. Initialise l'agent.

---

> void Update()

* effect : dû à l'héritage de MonoBehaviour, est appelée à chaque affichage. Met à jour l'agent

---

> private List<[Observation](Vision/Observation.md)> voir()

* return : la liste des observations actuelles de l'agent

---

> private void reagir(List<[Observation](Vision/Observation.md)> observation)

* param observation : liste des observations effectuées
* effect : l'agent se déplace, réagis en conséquence

---
    
> private void move() 

* effect : déplacement de l'agent

---

> public override bool Equals(object obj)

* param obj : objet à comparer s'il est égal à l'agent
* return : si l'objet est égal à l'agent

---

> public override int GetHashCode()

* return le hashCode de l'agent

---
