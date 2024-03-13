// List
using System.Collections.Generic;
// Vector3
using UnityEngine;

// Classe pour le comportement de gestion de bord
public class Bord : Comportement
{

    // Attributs

    // constante de force de répulsion
    static public float kR = 1.0f;

    // Méthodes

    // Le comportement est construit par rapport à un proprietaire
    public Bord(Agent proprietaire) : base(proprietaire) {}

    // retourne le vecteur déplacement en réaction aux observations
    public override Vector3 reagir(List<Observation> observation) {
        List<Vector3> vectors = new List<Vector3>();
        foreach(Observation o in observation) {
            if (!o.objet.isAlive()) {
                vectors.Add(delta(o.distance) * answer(o)); 
            }
        }
        Vector3 res = Utils.meanVector(vectors);
        return res;
    }
    
    // force de répulsion en fonction de la distance d
    protected virtual float delta(Vector3 d) {
        return kR/Utils.pow(Utils.normVector(d),2);
    }

    // vecteur réponse à l'observation
    protected virtual Vector3 answer(Observation o) {
        return -proprietaire.deplacement;
    }

}
