// Vector3
using UnityEngine;
// list
using System.Collections.Generic;

// 1ere classe pour comportement de bord qui répond en tangente 
public class TangenteBord1 : Bord
{

    // Le comportement est construit par rapport à un proprietaire
    public TangenteBord1(Agent proprietaire) : base(proprietaire) {}

    // retourne le vecteur déplacement en réaction aux observations
    public override Vector3 reagir(List<Observation> observation) {
        List<Vector3> vectors = new List<Vector3>();
        foreach(Observation o in observation) {
            if (!o.objet.isAlive()) {
                vectors.Add(delta(o.distance) * answer(o));
                vectors.Add(deltaTan(o.distance) * answerTan(o)); 
            }
        }
        Vector3 res = Utils.meanVector(vectors);
        return res;
    }
    
    // retourne l'intensité du vecteur réponse selon une distance
    protected virtual float deltaTan(Vector3 d) {
        return kR/Utils.normVector(d);
    }

    // retourne le vecteur en réponse à l'observation
    protected virtual Vector3 answerTan(Observation o) {
        Obstacle ob = (Obstacle) o.objet;
        List<Vector3> tan = ob.getTangentes(proprietaire);
        if(tan.Count == 0) return Vector3.zero;
        else {
            Vector3 res = tan[0];
            for(int i = 1; i<tan.Count;i++)
                if(Vector3.Angle(proprietaire.deplacement,tan[i]) < Vector3.Angle(proprietaire.deplacement,res))
                    res = tan[i];
            return res;
        } 

    }
    
}
