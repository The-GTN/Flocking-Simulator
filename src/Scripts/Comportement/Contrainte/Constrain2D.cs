// List
using System.Collections.Generic;
// Vector3
using UnityEngine;

// Classe pour le comportement qui contraint en 2D
public class Constrain2D : Comportement
{

    // Attributs

    // le comportement qui est contraint
    protected Comportement comportement;

    // Méthodes

    // Le comportement est construit par rapport à un proprietaire et un comportement à contraindre
    public Constrain2D(Agent proprietaire,Comportement c) : base(proprietaire) {
        comportement = c;
    }

    // retourne le vecteur déplacement en réaction aux observations
    public override Vector3 reagir(List<Observation> observation) {
        Vector3 res = comportement.reagir(observation);
        res.z = 0.0f;
        return res;
    }

}
