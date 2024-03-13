// List
using System.Collections.Generic;
// Vector3
using UnityEngine;

// Classe pour le comportement composé et moyennant
public class CompositeMean : CompositeSum
{

    // Le comportement est construit par rapport à un proprietaire, une liste de comportement et une liste d'importance
    public CompositeMean(Agent proprietaire,List<Comportement> c,List<int> i) : base(proprietaire,c,i) {}

    // Le comportement est construit par rapport à un proprietaire
    public CompositeMean(Agent proprietaire) : base(proprietaire) {}

    // retourne le vecteur déplacement en réaction aux observations
    public override Vector3 reagir(List<Observation> observation) {
        List<Vector3> vectors = new List<Vector3>();
        Vector3 add;
        for(int i=0;i<comportements.Count;i++) {
            add = comportements[i].reagir(observation);
            for(int j=0; j<importances[i];j++) vectors.Add(add);
        }
        return Utils.meanVector(vectors);
    }

}
