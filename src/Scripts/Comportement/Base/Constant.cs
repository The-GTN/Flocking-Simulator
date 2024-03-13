// List
using System.Collections.Generic;
// Vector3
using UnityEngine;

// Classe pour le comportement constant
public class Constant : Comportement
{
    // Le comportement est construit par rapport à un proprietaire
    public Constant(Agent proprietaire) : base(proprietaire) {}

    // retourne le vecteur déplacement en réaction aux observations
    public override Vector3 reagir(List<Observation> observation) {
        return proprietaire.deplacement;
    }
}
