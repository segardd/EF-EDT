using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universite.Models
{
    public class Creneau:Cours
    {
        public double Width=0;
        public double Place=0;

        public Creneau(Cours cours, int FirstHour, int LastHour)
        {

                this.CoursID = cours.CoursID;
                this.salle = cours.salle;
                this.DHDebut = cours.DHDebut;
                this.DHFin = cours.DHFin;
                this.UEID = cours.UEID;

                this.LUE = cours.LUE;


            double HD = this.DHDebut.Hour;
            double MD= this.DHDebut.Minute;
            HD += MD/60;

            this.Place = ((HD - FirstHour) * 100) / (LastHour - FirstHour);

            TimeSpan gap = this.DHFin.Subtract(this.DHDebut);
            double floatGap = gap.Hours + (gap.Minutes / 60);

            this.Width = (floatGap * 100) / (LastHour - FirstHour);
        }

        public void UpdateCrenoShape(int FirstHour, int LastHour)
        {
            float HD = this.DHDebut.Hour;
            HD += this.DHDebut.Minute / 60;

            this.Place = (HD * 100) / (LastHour - FirstHour);

            TimeSpan gap = this.DHFin.Subtract(this.DHDebut);
            float floatGap = gap.Hours;
            floatGap += gap.Minutes / 60;

            this.Width = (floatGap * 100) / (LastHour - FirstHour);
        }
    }
}
