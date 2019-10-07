using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace INOM.Entities
{
    public class Scheduler
    {
        [Key]
        public int SchedulerID { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime FinishedDate { get; set; }//si es nulo, es porque la ejecucion es Anual  se ejecuta 1 sola vez dada por la fehca StartedDate
        public string Period { get; set; }//(D/S/M/A/P) Diario/Semanal/Mensual/Anual(fecha de Started y Finished es la misma y se ejecuta 1 sola vez a futuro)
        //public int? Repetitions { get; set; }//si es nulo, es porque la ejecucion es Anual o Personal se ejecuta 1 sola vez dada por la fehca StartedDate
        public int? DatePeriod { get; set; }//cada cuentos dias se ejecuta (para Diario)
        public string  WeeklyPeriod { get; set; }//lista de los dias de la semana que se ejecuta (1 para domingos y 7 para sabado para Mensual y Semanal)
        public string MonthlyPeriod { get; set; }//lista de los dias del mes que se va a ejectuar. Para Periodo Mensual.
        public bool ExecuteWeekEnd { get; set; }//si se ejecuta los dias que caen en fines de semana
        public bool ExecuteHoliday{ get; set; }//si se ejecuta los dias que caen en feriado
        public bool ExecuteBefore { get; set; }//en caso que no se ejecute los fines de semana o feriado, se ejecuta el dia anterior
        public bool ExecuteAfter{ get; set; }//en caso que no se ejecute los fines de semana o feriado, se ejecuta el dia posterior

        //public virtual Instruction Instruction { get; set; }
        //public int InstructionID { get; set; }

        public static void Save(Scheduler instructionScheduled)
        {
            using (var db = new DBContext())
            {
                db.Schedulers.Add(instructionScheduled);
                db.SaveChanges();
            }
        }
       
        public static void Update(Scheduler instructionScheduled)
        {
            using (var db = new DBContext())
            {
                db.Schedulers.Attach(instructionScheduled);
                db.Entry(instructionScheduled).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
