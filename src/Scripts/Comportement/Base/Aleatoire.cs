// List
using System.Collections.Generic;
// Vector3
using UnityEngine;

// Classe pour le comportement aleatoire
public class Aleatoire : Comportement
{

    // Le comportement est construit par rapport à un proprietaire
    public Aleatoire(Agent proprietaire) : base(proprietaire) {}

    // retourne le vecteur déplacement en réaction aux observations
    public override Vector3 reagir(List<Observation> observation) {
        return Utils.randomDirection();
    }

}
