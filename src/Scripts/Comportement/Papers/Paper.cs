// List
using System.Collections.Generic;
// Vector3
using UnityEngine;
// Serializable
using System;

// Classe pour le comportement du papier scientifique qu'on veut tester
public class Paper : Comportement
{

    // Classe interne correspondant à une mémoire dyadic
    [Serializable]
    public class Memory
    {
        // agent en mémoire
        public Agent agent;
        // la distance idéale courante
        public float idealDistance;
        // la distance prévue
        public float predictDistance;
        // l'intention de déplacement
        public float predictAttempt;
        // la stagnation courante
        public float stagnation;
        // l'exilation courante
        public float exilation;

        // la mémoire se contruit en fonction d'un agent, une distance idéale, une distance prévue et une attention
        public Memory(Agent a, float ideal, float predict, float attempt) {
            agent = a; idealDistance = ideal; predictDistance = predict; predictAttempt = attempt;
            stagnation = stagnationTolerance; exilation = exileTolerance;
        }
    };

    // Attributs

    // liste des vecteurs déplacements possibles
    private static List<Vector3> moves = new List<Vector3> 
    {
        (new Vector3(-1.0f,1.0f,0.0f)).normalized, (new Vector3(0.0f,1.0f,0.0f)).normalized, (new Vector3(1.0f,1.0f,0.0f)).normalized,
        (new Vector3(-1.0f,0.0f,0.0f)).normalized, (new Vector3(0.0f,0.0f,0.0f)).normalized, (new Vector3(1.0f,0.0f,0.0f)).normalized,
        (new Vector3(-1.0f,-1.0f,0.0f)).normalized, (new Vector3(0.0f,-1.0f,0.0f)).normalized, (new Vector3(1.0f,-1.0f,0.0f)).normalized,
        (new Vector3(-1.0f,1.0f,-1.0f)).normalized, (new Vector3(0.0f,1.0f,-1.0f)).normalized, (new Vector3(1.0f,1.0f,-1.0f)).normalized,
        (new Vector3(-1.0f,0.0f,-1.0f)).normalized, (new Vector3(0.0f,0.0f,-1.0f)).normalized, (new Vector3(1.0f,0.0f,-1.0f)).normalized,
        (new Vector3(-1.0f,-1.0f,-1.0f)).normalized, (new Vector3(0.0f,-1.0f,-1.0f)).normalized, (new Vector3(1.0f,-1.0f,-1.0f)).normalized,
        (new Vector3(-1.0f,1.0f,1.0f)).normalized, (new Vector3(0.0f,1.0f,1.0f)).normalized, (new Vector3(1.0f,1.0f,1.0f)).normalized,
        (new Vector3(-1.0f,0.0f,1.0f)).normalized, (new Vector3(0.0f,0.0f,1.0f)).normalized, (new Vector3(1.0f,0.0f,1.0f)).normalized,
        (new Vector3(-1.0f,-1.0f,1.0f)).normalized, (new Vector3(0.0f,-1.0f,1.0f)).normalized, (new Vector3(1.0f,-1.0f,1.0f)).normalized
    };

    // Critical real distance at which the FSRs are activated
    private static float activeSeuil = 10.0f;
    // Change rate (0 < P_C < 1) for increasing and decreasing ideal distances, and stagnation and exile tolerance times
    private static float changeRate = 0.2f;
    // Initial value of the stagnation tolerance time
    private static float stagnationTolerance = 15.0f;
    // Initial value of the exile tolerance time
    private static float exileTolerance = 30.0f;

    // liste des mémoires courantes
    private List<Memory> memories = new List<Memory>();

    // Le comportement est construit par rapport à un proprietaire
    public Paper(Agent proprietaire) : base(proprietaire) {}

    // retourne le vecteur déplacement en réaction aux observations
    public override Vector3 reagir(List<Observation> observation) {
        List<Vector3> candidatesVectors = getTheMoves(observation);
        Vector3 themove = getTheMove(candidatesVectors);
        assumeTheMove(themove,observation);
        return themove;
    }

    // retourne les déplacements à la dissatisfaction minimale selon les observations
    private List<Vector3> getTheMoves(List<Observation> observation) {
        List<Vector3> candidatesVectors = new List<Vector3>();
        float disatifaction = 1000.0f; float d;
        for(int i=0;i<moves.Count;i++) {
            d = computeDisatisfaction(moves[i],observation);
            if (d < disatifaction) {
                candidatesVectors.Clear(); 
                candidatesVectors.Add(moves[i]);
                disatifaction = d;
            }
            else if (d == disatifaction) candidatesVectors.Add(moves[i]);
        }
        return candidatesVectors;
    }

    // retourne le déplacement qui perturbe le moins la direction courante de l'agent parmi les déplacements candidats
    private Vector3 getTheMove(List<Vector3> candidatesVectors) {
        Vector3 themove = proprietaire.deplacement;
        float d = 1000.0f; float sum;
        for(int i=0;i<candidatesVectors.Count;i++) {
            sum = Utils.abs(proprietaire.deplacement.x - candidatesVectors[i].x);
            sum += Utils.abs(proprietaire.deplacement.y - candidatesVectors[i].y);
            sum += Utils.abs(proprietaire.deplacement.z - candidatesVectors[i].z);
            if (sum < d) {
                d = sum;
                themove = candidatesVectors[i];
            }
        }
        return themove;
    }

    // conséquence du choix du déplacement choisi
    private void assumeTheMove(Vector3 themove,List<Observation> observation) {
        Vector3 futurPos = proprietaire.transform.position + themove;
        List<Observation> agentObservations = observation.FindAll(isAgent);
        Agent concerned; Vector3 reachPoint; float reachDist;
        for(int i=0;i<agentObservations.Count;i++) {
            concerned = (Agent) agentObservations[i].objet;
            reachPoint = proprietaire.transform.position + agentObservations[i].distance;
            reachDist = Utils.normVector( reachPoint - futurPos );
            for(int j=0;j<memories.Count;j++) {
                if(memories[j].agent == concerned) {
                    memories[j].predictDistance = reachDist;
                    memories[j].predictAttempt = reachDist - Utils.normVector(agentObservations[i].distance);
                }
            }
        }
    }

    // retourne si l'objet observé est un agent
    private bool isAgent(Observation o) {return o.objet.isAlive();}

    // renvoie la dissatisfaction d'un déplacement selon les 
    private float computeDisatisfaction(Vector3 move, List<Observation> observation) {
        float d = 0.0f; int nb = 0;
        float m = proprietaire.getSystem().getEnvironnement().getMaxDistance();
        Vector3 possiblePos = proprietaire.transform.position + move;
        Vector3 reachPoint;
        float reachDist; Agent concerned; float dist;
        for(int i=0;i<observation.Count;i++) {
            if (observation[i].objet.isAlive()) {
                dist = Utils.normVector(observation[i].distance);
                if(dist <= activeSeuil) {
                    concerned = (Agent) observation[i].objet;
                    reachPoint = proprietaire.transform.position + observation[i].distance;
                    reachDist = Utils.normVector( reachPoint - possiblePos );
                    addAgentInMemory(concerned,dist,m,reachDist);
                    d += Utils.abs( reachDist - idealDistance((Agent) observation[i].objet));
                    nb += 1;
                }
            }
        }
        if (nb==0) return 1000.0f;
        else return d/(nb*m);
    }

    // ajout de l'agent dans la liste de mémoires
    private void addAgentInMemory(Agent concerned,float dist,float max, float reachDist) {
        bool hasToBeAdd = true;
        int i = 0;
        while (i < memories.Count && hasToBeAdd) {
            if(memories[i].agent == concerned) hasToBeAdd = false;
            i++;
        }
        if(hasToBeAdd) {
            Memory mem = new Memory(concerned,Utils.random(dist,max),reachDist,0.0f);
            memories.Add(mem);
        }
    }

    // calcul de la distance idéale
    private float idealDistance(Agent other) {
        int i = 0;
        while(memories[i].agent != other) i++;
        float dist = Utils.normVector(other.transform.position - proprietaire.transform.position);
        float c = memories[i].predictAttempt;
        float u = Utils.abs(dist - memories[i].idealDistance) - Utils.abs(memories[i].predictDistance - memories[i].idealDistance);
        int k = 0;
        if (u > 0) {
            if (c < 0) k = 1;
            else if (c > 0) k = -1;
            else k = Utils.randomPosOrNeg(1);
        }
        else if(u < 0) {
            if (c < 0) k = -1;
            else if (c > 0) k = 1;
            else k = Utils.randomPosOrNeg(1);
        }
        float ideal = (1 + k*changeRate) * memories[i].idealDistance;
        memories[i].idealDistance = ideal;
        return 5.0f;


        //return ideal;
        /*
        if(Utils.abs(ideal - memories[i].idealDistance) < changeRate && memories[i].stagnation > 1) {
            memories[i].stagnation -= 1;
            if(memories[i].stagnation <= 1) {
                ideal = memories[i].idealDistance + changeRate * stagnationTolerance;
            }
        }
        else if(memories[i].exilation > 1 && memories[i].stagnation <= 1) {
            memories[i].exilation -= 1;
            //memories[i].stagnation *= 1 + changeRate;
            if(memories[i].exilation == 1) {
                ideal = memories[i].idealDistance - (changeRate * stagnationTolerance + activeSeuil);
                memories[i].stagnation = stagnationTolerance * (1 + changeRate);
                memories[i].exilation = exileTolerance * (1 - changeRate);
            }
        }
        memories[i].idealDistance = ideal;
        return ideal;
        */
    }
    
}
